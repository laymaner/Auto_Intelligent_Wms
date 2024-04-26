using Auto_Intelligent_Wms.Core.Common.Enum;
using Auto_Intelligent_Wms.Core.Common.Utils;
using Auto_Intelligent_Wms.Core.Extensions.Attri;
using Auto_Intelligent_Wms.Core.IServices.IServices;
using Auto_Intelligent_Wms.Core.Model.BaseModel;
using Auto_Intelligent_Wms.Core.Model.Entities;
using Auto_Intelligent_Wms.Core.Model.ImExportTemplate.Location;
using Auto_Intelligent_Wms.Core.Model.ImExportTemplate.Shelf;
using Auto_Intelligent_Wms.Core.Model.RequestDTO.Location;
using Auto_Intelligent_Wms.Core.Model.RequestDTO.Shelf;
using Mapster;
using Mask_STK.Core.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Xml.Linq;

namespace Auto_Intelligent_Wms.Core.Services.Services
{
    public class ShelfService : IShelfService
    {
        private readonly Auto_Inteligent_Wms_DbContext _db;
        private readonly ILogger<ShelfService> _log;
        private readonly IAreaService _areaService;

        public ShelfService(Auto_Inteligent_Wms_DbContext db, ILogger<ShelfService> logger, IAreaService areaService)
        {
            _db = db;
            _log = logger;
            _areaService = areaService;
        }

        /// <summary>
        /// 创建货架
        /// </summary>
        /// <param name="createOrUpdateFactoryDTO"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<long> CreateAsync([FromBody] CreateShelfDTO createOrUpdateFactoryDTO, long currentUserId)
        {
            if (string.IsNullOrWhiteSpace(createOrUpdateFactoryDTO.Code))
            {
                throw new Exception("The shelf code parameter is empty");
            }
            if (string.IsNullOrWhiteSpace(createOrUpdateFactoryDTO.Name))
            {
                throw new Exception("The shelf name parameter is empty");
            }
            if (string.IsNullOrWhiteSpace(createOrUpdateFactoryDTO.AreaCode))
            {
                throw new Exception("The AreaCode parameter is empty");
            }
            var area = await _areaService.GetAreaByCodeAsync(createOrUpdateFactoryDTO.AreaCode);
            if (area == null)
            {
                throw new Exception("The AreaCode does not exist");
            }
            if (await IsExistAsync(createOrUpdateFactoryDTO.Code))
            {
                throw new Exception("The shelf already exists");
            }
            Shelf shelf = new Shelf();
            shelf.Code = createOrUpdateFactoryDTO.Code;
            shelf.Name = createOrUpdateFactoryDTO.Name;
            shelf.AreaId = area.Id;
            shelf.AreaCode = createOrUpdateFactoryDTO.AreaCode;
            shelf.AreaName = area.Name;
            shelf.RoadWay = createOrUpdateFactoryDTO.RoadWay;
            shelf.ShelfRows = createOrUpdateFactoryDTO.ShelfRows;
            shelf.ShelfColumns = createOrUpdateFactoryDTO.ShelfColumns;
            shelf.ShelfLayers = createOrUpdateFactoryDTO.ShelfLayers;
            shelf.CreateTime = DateTime.Now;
            shelf.Creator = currentUserId;
            shelf.Remark = createOrUpdateFactoryDTO.Remark;
            shelf.Status = (int)DataStatus.Normal;
            var result = await _db.Shelfs.AddAsync(shelf);
            await _db.SaveChangesAsync();
            return result.Entity.Id;
        }

        /// <summary>
        /// 根据id删除货架信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [Transation]
        public async Task<long> DelAsync(long id, long currentUserId)
        {
            if (id <= 0)
            {
                throw new Exception("The shelf id parameter is empty");
            }
            var shelf = await _db.Shelfs.Where(m => m.Id == id && m.Status == (int)DataStatus.Normal).SingleOrDefaultAsync();
            if (shelf == null)
            {
                throw new Exception($"No information found for shelf,id is {id}");
            }
            if (await _db.Locations.AnyAsync(m => m.ShelfId == id && m.Status == (int)DataStatus.Normal))
            {
                throw new Exception("The area is in use and cannot be deleted");
            }
            if (await _db.StockInventories.AnyAsync(m => m.ShelfCode.Equals(shelf.Code) && m.Status == (int)DataStatus.Normal))
            {
                throw new Exception("The shelf is in use and cannot be deleted");
            }
            shelf.Status = (int)DataStatus.Delete;
            shelf.UpdateTime = DateTime.Now;
            shelf.Updator = currentUserId;
            return await _db.SaveChangesAsync();
        }

        /// <summary>
        /// 下载货架模板
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult<string>> DownloadTemplateAsync()
        {
            List<ShelfDownloadTemplate> list = new List<ShelfDownloadTemplate>();
            return await MiniExcelUtil.ExportAsync("下载货架模板", list);
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="shelfParamsDTO"></param>
        /// <returns></returns>
        public async Task<ActionResult<string>> ExportAsync([FromQuery] ShelfParamsDTO shelfParamsDTO)
        {
            var items = _db.Shelfs.Where(m => m.Status == (int)DataStatus.Normal).AsNoTracking();
            if (!string.IsNullOrWhiteSpace(shelfParamsDTO.Code))
            {
                items = items.Where(m => m.Code.StartsWith(shelfParamsDTO.Code));
            }
            if (!string.IsNullOrWhiteSpace(shelfParamsDTO.Name))
            {
                items = items.Where(m => m.Name.StartsWith(shelfParamsDTO.Name));
            }
            var result = items.Adapt<List<ShelfExportTemplate>>();
            return await MiniExcelUtil.ExportAsync("货架信息", result);
        }

        /// <summary>
        /// 获取货架信息
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<List<Shelf>> GetListAsync([FromQuery] ShelfParamsDTO shelfParamsDTO)
        {
            var items = _db.Shelfs.Where(m => m.Status == (int)DataStatus.Normal).AsNoTracking();
            if (!string.IsNullOrWhiteSpace(shelfParamsDTO.Code))
            {
                items = items.Where(m => m.Code.StartsWith(shelfParamsDTO.Code));
            }
            if (!string.IsNullOrWhiteSpace(shelfParamsDTO.Name))
            {
                items = items.Where(m => m.Name.StartsWith(shelfParamsDTO.Name));
            }
            return await items.ToListAsync();
        }

        /// <summary>
        /// 获取货架分页信息
        /// </summary>
        /// <param name="shelfParamsDTO"></param>
        /// <returns></returns>
        public async Task<BasePagination<Shelf>> GetPaginationAsync([FromQuery] ShelfParamsDTO shelfParamsDTO)
        {
            var items = _db.Shelfs.Where(m => m.Status == (int)DataStatus.Normal).AsNoTracking();
            if (!string.IsNullOrWhiteSpace(shelfParamsDTO.Code))
            {
                items = items.Where(m => m.Code.StartsWith(shelfParamsDTO.Code));
            }
            if (!string.IsNullOrWhiteSpace(shelfParamsDTO.Name))
            {
                items = items.Where(m => m.Name.StartsWith(shelfParamsDTO.Name));
            }
            return await PaginationService.PaginateAsync(items, shelfParamsDTO.PageIndex, shelfParamsDTO.PageSize);
        }

        /// <summary>
        /// 根据货架code获取货架信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<Shelf> GetShelfByCodeAsync(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new Exception("The shelf code parameter is empty");
            }
            var shelf = await _db.Shelfs.Where(m => m.Code.Equals(code) && m.Status == (int)DataStatus.Normal).SingleOrDefaultAsync();
            if (shelf == null)
            {
                throw new Exception($"No information found for shelf,code is {code}");
            }
            return shelf;
        }

        /// <summary>
        /// 根据codes集合获取货架信息
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        public async Task<List<Shelf>> GetShelfByCodesAsync(string codes)
        {
            var list = new List<Shelf>();
            if (!string.IsNullOrWhiteSpace(codes))
            {
                var codeList = codes.Split(',').ToList();
                list = await _db.Shelfs.Where(m => codeList.Contains(m.Code) && m.Status == (int)DataStatus.Normal).ToListAsync();
            }
            return list;
        }

        /// <summary>
        /// 根据货架id获取货架信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Shelf> GetShelfByIdAsync(long id)
        {
            if (id <= 0)
            {
                throw new Exception("The shelf id parameter is empty");
            }
            var shelf = await _db.Shelfs.Where(m => m.Id == id && m.Status == (int)DataStatus.Normal).SingleOrDefaultAsync();
            if (shelf == null)
            {
                throw new Exception($"No information found for shelf,id is {id}");
            }
            return shelf;
        }

        /// <summary>
        /// 根据ids集合获取货架信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public async Task<List<Shelf>> GetShelfByIdsAsync(string ids)
        {
            var list = new List<Shelf>();
            if (!string.IsNullOrWhiteSpace(ids))
            {
                var items = ids.Split(',').ToList();
                List<long> idList = items.Select(s => long.Parse(s)).ToList();
                list = await _db.Shelfs.Where(m => idList.Contains(m.Id) && m.Status == (int)DataStatus.Normal).ToListAsync();
            }
            return list;
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="path"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [Transation]
        public async Task<string> ImportAsync(string path, long currentUserId)
        {
            var result = MiniExcelUtil.Import<ShelfDownloadTemplate>(path).ToList();
            if (result == null || result.Count <= 0)
            {
                throw new Exception("Import data is empty");
            }
            //判断货架编码有没有空值
            if (result.Any(m => string.IsNullOrWhiteSpace(m.Code)))
            {
                throw new Exception("There is a null value in the imported shelf code");
            }
            //判断货架名称有没有空值
            if (result.Any(m => string.IsNullOrWhiteSpace(m.Name)))
            {
                throw new Exception("There is a null value in the imported shelf name");
            }
            //判断库区编码有没有空值
            if (result.Any(m => string.IsNullOrWhiteSpace(m.AreaCode)))
            {
                throw new Exception("There is a null value in the imported shelf AreaCode");
            }
            //判断货架编码是否有重复
            if (result.GroupBy(m => m.Code).Any(group => group.Count() > 1))
            {
                throw new Exception("shelf code duplication");
            }
            //判断货架是否存在
            var shelfCodeList = result.Select(m => m.Code).ToList();
            var shelfItems = await _db.Shelfs.Where(m => shelfCodeList.Contains(m.Code) && m.Status == (int)DataStatus.Normal).ToListAsync();
            if (shelfItems != null && shelfItems.Count > 0)
            {
                throw new Exception("shelf code already exists");
            }

            //判断库区是否存在
            var areaCodeList = result.Select(m => m.AreaCode).Distinct().ToList();
            var areaitems = await _db.Locations.Where(m => areaCodeList.Contains(m.Code) && m.Status == (int)DataStatus.Normal).Select(x => new { x.Id, x.Code,x.Name }).ToListAsync();
            if (areaitems == null || areaitems.Count < areaCodeList.Count)
            {
                throw new Exception("area code does not  exists");
            }
            var data = result.Join(areaitems, i => i.AreaCode, o => o.Code, (i, o) => new { i, o }).Select(m => new Shelf
            {
                Name = m.i.Name,
                Code = m.i.Code,
                Status = (int)DataStatus.Normal,
                AreaId = m.o.Id,
                AreaCode = m.i.AreaCode,
                AreaName = m.o.Name,
                RoadWay = m.i.RoadWay,
                ShelfRows = m.i.ShelfRows,
                ShelfColumns = m.i.ShelfColumns,
                ShelfLayers = m.i.ShelfLayers,
                Creator = currentUserId,
                Remark = m.i.Remark,
                CreateTime = DateTime.Now,
            });
            await _db.BulkInsertAsync(data);
            await _db.SaveChangesAsync();
            return "Import shelf successful";
        }

        /// <summary>
        /// 根据货架code判断该货架是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<bool> IsExistAsync(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new Exception("The shelf code parameter is empty");
            }
            var shelf = await _db.Shelfs.Where(m => m.Code.Equals(code) && m.Status == (int)DataStatus.Normal).SingleOrDefaultAsync();
            if (shelf == null)
            {
                return false;
            }
            return true;
        }
    }
}

using Auto_Intelligent_Wms.Core.Common.Enum;
using Auto_Intelligent_Wms.Core.Common.Utils;
using Auto_Intelligent_Wms.Core.IServices.IServices;
using Auto_Intelligent_Wms.Core.Model.BaseModel;
using Auto_Intelligent_Wms.Core.Model.Entities;
using Auto_Intelligent_Wms.Core.Model.ImExportTemplate.Area;
using Auto_Intelligent_Wms.Core.Model.ImExportTemplate.WareHouse;
using Auto_Intelligent_Wms.Core.Model.RequestDTO.Area;
using Auto_Intelligent_Wms.Core.Model.RequestDTO.WareHouse;
using Mapster;
using Mask_STK.Core.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Auto_Intelligent_Wms.Core.Services.Services
{
    public class AreaService : IAreaService
    {

        private readonly Auto_Inteligent_Wms_DbContext _db;
        private readonly ILogger<AreaService> _log;
        public readonly IWareHouseService _wareHouseService;

        public AreaService(Auto_Inteligent_Wms_DbContext db, ILogger<AreaService> logger,IWareHouseService wareHouseService)
        {
            _db = db;
            _log = logger;
            _wareHouseService = wareHouseService;
        }
        
        /// <summary>
        /// 创建库区信息
        /// </summary>
        /// <param name="createAreaDTO"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<long> CreateAsync([FromBody] CreateAreaDTO createAreaDTO, long currentUserId)
        {
            if (string.IsNullOrWhiteSpace(createAreaDTO.Code))
            {
                throw new Exception("The area code parameter is empty");
            }
            if (string.IsNullOrWhiteSpace(createAreaDTO.Name))
            {
                throw new Exception("The area name parameter is empty");
            }
            if (string.IsNullOrWhiteSpace(createAreaDTO.WareHouseCode))
            {
                throw new Exception("The WareHouseCode parameter is empty");
            }
            var warehouse = await _wareHouseService.GetWareHouseByCodeAsync(createAreaDTO.WareHouseCode);
            if (warehouse == null)
            {
                throw new Exception("The WareHouseCode does not exist");
            }
            if (await IsExistAsync(createAreaDTO.Code))
            {
                throw new Exception("The area already exists");
            }
            Area area = new Area();
            area.Code = createAreaDTO.Code;
            area.Name = createAreaDTO.Name;
            area.WareHouseId = warehouse.Id;
            area.WareHouseCode = createAreaDTO.WareHouseCode;
            area.WareHouseName = warehouse.Name;
            area.CreateTime = DateTime.Now;
            area.Creator = currentUserId;
            area.Remark = createAreaDTO.Remark;
            area.Status = (int)DataStatus.Normal;
            var result = await _db.Areas.AddAsync(area);
            await _db.SaveChangesAsync();
            return result.Entity.Id;
        }

        /// <summary>
        /// 根据库区id删除库区信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<long> DelAsync(long id, long currentUserId)
        {
            if (id <= 0)
            {
                throw new Exception("The area id parameter is empty");
            }
            var area = await _db.Areas.Where(m => m.Id == id && m.Status == (int)DataStatus.Normal).SingleOrDefaultAsync();
            if (area == null)
            {
                throw new Exception($"No information found for area,id is {id}");
            }
            if (await _db.StockInventories.AnyAsync(m => m.AreaCode.Equals(area.Code) && m.Status == (int)DataStatus.Normal))
            {
                throw new Exception("The area is in use and cannot be deleted");
            }
            if (await _db.Shelfs.AnyAsync(m => m.AreaId == id && m.Status == (int)DataStatus.Normal))
            {
                throw new Exception("The area is in use and cannot be deleted");
            }
            area.Status = (int)DataStatus.Delete;
            area.UpdateTime = DateTime.Now;
            area.Updator = currentUserId;
            return await _db.SaveChangesAsync();
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult<string>> DownloadTemplateAsync()
        {
            List<AreaDownloadTemplate> list = new List<AreaDownloadTemplate>();
            return await MiniExcelUtil.ExportAsync("下载库区模板", list);
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="areaParamsDTO"></param>
        /// <returns></returns>
        public async Task<ActionResult<string>> ExportAsync([FromQuery] AreaParamsDTO areaParamsDTO)
        {
            var items = _db.Areas.Where(m => m.Status == (int)DataStatus.Normal).AsNoTracking();
            if (!string.IsNullOrWhiteSpace(areaParamsDTO.Code))
            {
                items = items.Where(m => m.Code.StartsWith(areaParamsDTO.Code));
            }
            if (!string.IsNullOrWhiteSpace(areaParamsDTO.Name))
            {
                items = items.Where(m => m.Name.StartsWith(areaParamsDTO.Name));
            }
            var result = items.Adapt<List<AreaExportTemplate>>();
            return await MiniExcelUtil.ExportAsync("库区信息", result);
        }

        /// <summary>
        /// 根据库区code获取库区信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Area> GetAreaByCodeAsync(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new Exception("The area code parameter is empty");
            }
            var area = await _db.Areas.Where(m => m.Code.Equals(code) && m.Status == (int)DataStatus.Normal).SingleOrDefaultAsync();
            if (area == null)
            {
                throw new Exception($"No information found for area,code is {code}");
            }
            return area;
        }

        /// <summary>
        /// 根据codes集合获取库区信息
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        public async Task<List<Area>> GetAreaByCodesAsync(string codes)
        {
            var list = new List<Area>();
            if (!string.IsNullOrWhiteSpace(codes))
            {
                var codeList = codes.Split(',').ToList();
                list = await _db.Areas.Where(m => codeList.Contains(m.Code) && m.Status == (int)DataStatus.Normal).ToListAsync();
            }
            return list;
        }

        /// <summary>
        /// 根据库区id获取库区信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Area> GetAreaByIdAsync(long id)
        {
            if (id <= 0)
            {
                throw new Exception("The area id parameter is empty");
            }
            var area = await _db.Areas.Where(m => m.Id == id && m.Status == (int)DataStatus.Normal).SingleOrDefaultAsync();
            if (area == null)
            {
                throw new Exception($"No information found for area,id is {id}");
            }
            return area;
        }

        /// <summary>
        /// 根据ids获取库区信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public async Task<List<Area>> GetAreaByIdsAsync(string ids)
        {
            var list = new List<Area>();
            if (!string.IsNullOrWhiteSpace(ids))
            {
                var items = ids.Split(',').ToList();
                List<long> idList = items.Select(s => long.Parse(s)).ToList();
                list = await _db.Areas.Where(m => idList.Contains(m.Id) && m.Status == (int)DataStatus.Normal).ToListAsync();
            }
            return list;
        }

        /// <summary>
        /// 查询库区信息
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<List<Area>> GetListAsync([FromQuery] AreaParamsDTO areaParamsDTO)
        {
            var items = _db.Areas.Where(m => m.Status == (int)DataStatus.Normal).AsNoTracking();
            if (!string.IsNullOrWhiteSpace(areaParamsDTO.Code))
            {
                items = items.Where(m => m.Code.StartsWith(areaParamsDTO.Code));
            }
            if (!string.IsNullOrWhiteSpace(areaParamsDTO.Name))
            {
                items = items.Where(m => m.Name.StartsWith(areaParamsDTO.Name));
            }
            return await items.ToListAsync();
        }

        /// <summary>
        /// 查询库区分页信息
        /// </summary>
        /// <param name="areaParamsDTO"></param>
        /// <returns></returns>
        public async  Task<BasePagination<Area>> GetPaginationAsync([FromQuery] AreaParamsDTO areaParamsDTO)
        {
            var items = _db.Areas.Where(m => m.Status == (int)DataStatus.Normal).AsNoTracking();
            if (!string.IsNullOrWhiteSpace(areaParamsDTO.Code))
            {
                items = items.Where(m => m.Code.StartsWith(areaParamsDTO.Code));
            }
            if (!string.IsNullOrWhiteSpace(areaParamsDTO.Name))
            {
                items = items.Where(m => m.Name.StartsWith(areaParamsDTO.Name));
            }
            return await PaginationService.PaginateAsync(items, areaParamsDTO.PageIndex, areaParamsDTO.PageSize);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="path"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<string> ImportAsync(string path, long currentUserId)
        {
            var result = MiniExcelUtil.Import<AreaDownloadTemplate>(path).ToList();
            if (result == null || result.Count <= 0)
            {
                throw new Exception("Import data is empty");
            }
            //判断库区编码有没有空值
            if (result.Any(m => string.IsNullOrWhiteSpace(m.Code)))
            {
                throw new Exception("There is a null value in the imported area code");
            }
            //判断库区名称有没有空值
            if (result.Any(m => string.IsNullOrWhiteSpace(m.Name)))
            {
                throw new Exception("There is a null value in the imported area name");
            }
            //判断仓库编码有没有空值
            if (result.Any(m => string.IsNullOrWhiteSpace(m.WareHouseCode)))
            {
                throw new Exception("There is a null value in the imported area wareHouseCode");
            }
            //判断库区编码是否有重复
            if (result.GroupBy(m => m.Code).Any(group => group.Count() > 1))
            {
                throw new Exception("area code duplication");
            }
            //判断库区是否存在
            var areaCodeList = result.Select(m => m.Code).ToList();
            var areaItems = await _db.Areas.Where(m => areaCodeList.Contains(m.Code) && m.Status == (int)DataStatus.Normal).ToListAsync();
            if (areaItems != null && areaItems.Count > 0)
            {
                throw new Exception("area code already exists");
            }

            //判断仓库编码是否存在
            var wareHouseCodeList = result.Select(m => m.WareHouseCode).Distinct().ToList();
            var wareHouseitems = await _db.WareHouses.Where(m => wareHouseCodeList.Contains(m.Code) && m.Status == (int)DataStatus.Normal).Select(x => new { x.Id, x.Code ,x.Name}).ToListAsync();
            if (wareHouseitems == null || wareHouseitems.Count < wareHouseCodeList.Count)
            {
                throw new Exception("wareHouse code does not  exists");
            }
            var data = result.Join(wareHouseitems, i => i.WareHouseCode, o => o.Code, (i, o) => new { i, o }).Select(m => new Area
            {
                Name = m.i.Name,
                Code = m.i.Code,
                Status = (int)DataStatus.Normal,
                WareHouseCode = m.i.WareHouseCode,
                WareHouseId = m.o.Id,
                WareHouseName = m.o.Name,
                Creator = currentUserId,
                Remark = m.i.Remark,
                CreateTime = DateTime.Now,
            });
            await _db.BulkInsertAsync(data);
            await _db.SaveChangesAsync();
            return "Import Area successful";
        }

        /// <summary>
        /// 根据库区编码判断 该库区是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<bool> IsExistAsync(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new Exception("The area code parameter is empty");
            }
            var area = await _db.Areas.Where(m => m.Code.Equals(code) && m.Status == (int)DataStatus.Normal).SingleOrDefaultAsync();
            if (area == null)
            {
                return false;
            }
            return true;
        }
    }
}

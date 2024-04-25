using Auto_Intelligent_Wms.Core.Common.Enum;
using Auto_Intelligent_Wms.Core.Common.Utils;
using Auto_Intelligent_Wms.Core.IServices.IServices;
using Auto_Intelligent_Wms.Core.Model.BaseModel;
using Auto_Intelligent_Wms.Core.Model.Entities;
using Auto_Intelligent_Wms.Core.Model.ImExportTemplate.Area;
using Auto_Intelligent_Wms.Core.Model.ImExportTemplate.Location;
using Auto_Intelligent_Wms.Core.Model.RequestDTO.Area;
using Auto_Intelligent_Wms.Core.Model.RequestDTO.Location;
using Mapster;
using Mask_STK.Core.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Auto_Intelligent_Wms.Core.Services.Services
{
    public class LocationService : ILocationService
    {

        private readonly Auto_Inteligent_Wms_DbContext _db;
        private readonly ILogger<LocationService> _log;
        private readonly IShelfService _shelfService;

        public LocationService(Auto_Inteligent_Wms_DbContext db, ILogger<LocationService> logger, IShelfService shelfService)
        {
            _db = db;
            _log = logger;
            _shelfService = shelfService;
        }

        /// <summary>
        /// 创建货位信息
        /// </summary>
        /// <param name="createLocationDTO"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<long> CreateAsync([FromBody] CreateLocationDTO createLocationDTO, long currentUserId)
        {
            if (string.IsNullOrWhiteSpace(createLocationDTO.Code))
            {
                throw new Exception("The location code parameter is empty");
            }
            if (string.IsNullOrWhiteSpace(createLocationDTO.Name))
            {
                throw new Exception("The location name parameter is empty");
            }
            if (string.IsNullOrWhiteSpace(createLocationDTO.ShelfCode))
            {
                throw new Exception("The areacode parameter is empty");
            }
            var shelf = await _shelfService.GetShelfByCodeAsync(createLocationDTO.ShelfCode);
            if (shelf == null)
            {
                throw new Exception("The shelfcode does not exist");
            }
            if (await IsExistAsync(createLocationDTO.Code))
            {
                throw new Exception("The location already exists");
            }
            Location location = new Location();
            location.Code = createLocationDTO.Code;
            location.Name = createLocationDTO.Name;
            location.ShelfId = shelf.Id;
            location.ShelfCode = createLocationDTO.ShelfCode;
            location.ShelfName = shelf.Name;
            location.RoadWay = createLocationDTO.RoadWay;
            location.LRow = createLocationDTO.LRow;
            location.LColumn = createLocationDTO.LColumn;
            location.Layer = createLocationDTO.Layer;
            location.CreateTime = DateTime.Now;
            location.Creator = currentUserId;
            location.Remark = createLocationDTO.Remark;
            location.Status = (int)DataStatus.Normal;
            var result = await _db.Locations.AddAsync(location);
            await _db.SaveChangesAsync();
            return result.Entity.Id;
        }

        /// <summary>
        /// 根据货位id删除货位信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<long> DelAsync(long id, long currentUserId)
        {
            if (id <= 0)
            {
                throw new Exception("The location id parameter is empty");
            }
            var location = await _db.Locations.Where(m => m.Id == id && m.Status == (int)DataStatus.Normal).SingleOrDefaultAsync();
            if (location == null)
            {
                throw new Exception($"No information found for location,id is {id}");
            }
            if (await _db.StockInventories.AnyAsync(m => m.LocationCode.Equals(location.Code) && m.Status == (int)DataStatus.Normal))
            {
                throw new Exception("The location is in use and cannot be deleted");
            }
            location.Status = (int)DataStatus.Delete;
            location.UpdateTime = DateTime.Now;
            location.Updator = currentUserId;
            return await _db.SaveChangesAsync();
        }

        /// <summary>
        /// 下载货位模板
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult<string>> DownloadTemplateAsync()
        {
            List<LocationDownloadTemplate> list = new List<LocationDownloadTemplate>();
            return await MiniExcelUtil.ExportAsync("下载货位模板", list);
        }

        /// <summary>
        /// 导出货位信息
        /// </summary>
        /// <param name="locationParamsDTO"></param>
        /// <returns></returns>
        public async Task<ActionResult<string>> ExportAsync([FromQuery] LocationParamsDTO locationParamsDTO)
        {
            var items = _db.Locations.Where(m => m.Status == (int)DataStatus.Normal).AsNoTracking();
            if (!string.IsNullOrWhiteSpace(locationParamsDTO.Code))
            {
                items = items.Where(m => m.Code.StartsWith(locationParamsDTO.Code));
            }
            if (!string.IsNullOrWhiteSpace(locationParamsDTO.Name))
            {
                items = items.Where(m => m.Name.StartsWith(locationParamsDTO.Name));
            }
            var result = items.Adapt<List<LocationExportTemplate>>();
            return await MiniExcelUtil.ExportAsync("货位信息", result);
        }

        /// <summary>
        /// 查询货位信息
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<List<Location>> GetListAsync([FromQuery] LocationParamsDTO locationParamsDTO)
        {
            var items = _db.Locations.Where(m => m.Status == (int)DataStatus.Normal).AsNoTracking();
            if (!string.IsNullOrWhiteSpace(locationParamsDTO.Code))
            {
                items = items.Where(m => m.Code.StartsWith(locationParamsDTO.Code));
            }
            if (!string.IsNullOrWhiteSpace(locationParamsDTO.Name))
            {
                items = items.Where(m => m.Name.StartsWith(locationParamsDTO.Name));
            }
            return await items.ToListAsync();
        }

        /// <summary>
        /// 根据货位code获取货位信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Location> GetLocationByCodeAsync(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new Exception("The location code parameter is empty");
            }
            var location = await _db.Locations.Where(m => m.Code.Equals(code) && m.Status == (int)DataStatus.Normal).SingleOrDefaultAsync();
            if (location == null)
            {
                throw new Exception($"No information found for location,code is {code}");
            }
            return location;
        }

        /// <summary>
        /// 根据集合codes获取货位信息
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        public async Task<List<Location>> GetLocationByCodesAsync(string codes)
        {
            var list = new List<Location>();
            if (!string.IsNullOrWhiteSpace(codes))
            {
                var codeList = codes.Split(',').ToList();
                list = await _db.Locations.Where(m => codeList.Contains(m.Code) && m.Status == (int)DataStatus.Normal).ToListAsync();
            }
            return list;
        }

        /// <summary>
        /// 根据货位id查询货位信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Location> GetLocationByIdAsync(long id)
        {
            if (id <= 0)
            {
                throw new Exception("The location id parameter is empty");
            }
            var location = await _db.Locations.Where(m => m.Id == id && m.Status == (int)DataStatus.Normal).SingleOrDefaultAsync();
            if (location == null)
            {
                throw new Exception($"No information found for location,id is {id}");
            }
            return location;
        }

        /// <summary>
        /// 根据集合ids查询货位信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public async Task<List<Location>> GetLocationByIdsAsync(string ids)
        {
            var list = new List<Location>();
            if (!string.IsNullOrWhiteSpace(ids))
            {
                var items = ids.Split(',').ToList();
                List<long> idList = items.Select(s => long.Parse(s)).ToList();
                list = await _db.Locations.Where(m => idList.Contains(m.Id) && m.Status == (int)DataStatus.Normal).ToListAsync();
            }
            return list;
        }

        /// <summary>
        /// 查询货位分页信息
        /// </summary>
        /// <param name="locationParamsDTO"></param>
        /// <returns></returns>
        public async Task<BasePagination<Location>> GetPaginationAsync([FromQuery] LocationParamsDTO locationParamsDTO)
        {
            var items = _db.Locations.Where(m => m.Status == (int)DataStatus.Normal).AsNoTracking();
            if (!string.IsNullOrWhiteSpace(locationParamsDTO.Code))
            {
                items = items.Where(m => m.Code.StartsWith(locationParamsDTO.Code));
            }
            if (!string.IsNullOrWhiteSpace(locationParamsDTO.Name))
            {
                items = items.Where(m => m.Name.StartsWith(locationParamsDTO.Name));
            }
            return await PaginationService.PaginateAsync(items, locationParamsDTO.PageIndex, locationParamsDTO.PageSize);
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
            var result = MiniExcelUtil.Import<LocationDownloadTemplate>(path).ToList();
            if (result == null || result.Count <= 0)
            {
                throw new Exception("Import data is empty");
            }
            //判断货位编码有没有空值
            if (result.Any(m => string.IsNullOrWhiteSpace(m.Code)))
            {
                throw new Exception("There is a null value in the imported location code");
            }
            //判断货位名称有没有空值
            if (result.Any(m => string.IsNullOrWhiteSpace(m.Name)))
            {
                throw new Exception("There is a null value in the imported location name");
            }
            //判断货架编码有没有空值
            if (result.Any(m => string.IsNullOrWhiteSpace(m.ShelfCode)))
            {
                throw new Exception("There is a null value in the imported location ShelfCode");
            }
            //判断货位编码是否有重复
            if (result.GroupBy(m => m.Code).Any(group => group.Count() > 1))
            {
                throw new Exception("location code duplication");
            }
            //判断货位是否存在
            var locationCodeList = result.Select(m => m.Code).ToList();
            var locationItems = await _db.Locations.Where(m => locationCodeList.Contains(m.Code) && m.Status == (int)DataStatus.Normal).ToListAsync();
            if (locationItems != null && locationItems.Count > 0)
            {
                throw new Exception("location code already exists");
            }

            //判断货架是否存在
            var shelfCodeList = result.Select(m => m.ShelfCode).Distinct().ToList();
            var shelfitems = await _db.Areas.Where(m => shelfCodeList.Contains(m.Code) && m.Status == (int)DataStatus.Normal).Select(x => new { x.Id, x.Code ,x.Name}).ToListAsync();
            if (shelfitems == null || shelfitems.Count < shelfCodeList.Count)
            {
                throw new Exception("shelf code does not  exists");
            }
            var data = result.Join(shelfitems, i => i.ShelfCode, o => o.Code, (i, o) => new { i, o }).Select(m => new Location
            {
                Name = m.i.Name,
                Code = m.i.Code,
                Status = (int)DataStatus.Normal,
                ShelfId = m.o.Id,
                ShelfCode = m.i.ShelfCode,
                ShelfName = m.o.Name,
                RoadWay = m.i.RoadWay,
                LRow = m.i.LRow,
                LColumn = m.i.LColumn,
                Layer = m.i.Layer,
                Creator = currentUserId,
                Remark = m.i.Remark,
                CreateTime = DateTime.Now,
            });
            await _db.BulkInsertAsync(data);
            await _db.SaveChangesAsync();
            return "Import location successful";
        }

        /// <summary>
        /// 根据货位编码判断 该货位是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> IsExistAsync(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new Exception("The location code parameter is empty");
            }
            var area = await _db.Locations.Where(m => m.Code.Equals(code) && m.Status == (int)DataStatus.Normal).SingleOrDefaultAsync();
            if (area == null)
            {
                return false;
            }
            return true;
        }
    }
}

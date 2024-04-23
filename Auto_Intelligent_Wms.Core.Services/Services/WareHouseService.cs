using Auto_Intelligent_Wms.Core.Common.Enum;
using Auto_Intelligent_Wms.Core.Common.Utils;
using Auto_Intelligent_Wms.Core.IServices.IServices;
using Auto_Intelligent_Wms.Core.Model.BaseModel;
using Auto_Intelligent_Wms.Core.Model.Entities;
using Auto_Intelligent_Wms.Core.Model.ImExportTemplate.WareHouse;
using Auto_Intelligent_Wms.Core.Model.RequestDTO.WareHouse;
using Mapster;
using Mask_STK.Core.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Auto_Intelligent_Wms.Core.Services.Services
{
    public class WareHouseService : IWareHouseService
    {
        private readonly Auto_Inteligent_Wms_DbContext _db;
        private readonly ILogger<WareHouseService> _log;

        public WareHouseService(Auto_Inteligent_Wms_DbContext db, ILogger<WareHouseService> logger)
        {
            _db = db;
            _log = logger;
        }

        /// <summary>
        /// 创建仓库
        /// </summary>
        /// <param name="createWareHouseDTO"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        public async Task<long> CreateAsync([FromBody] CreateWareHouseDTO createWareHouseDTO, long currentUserId)
        {
            if (string.IsNullOrWhiteSpace(createWareHouseDTO.Code))
            {
                throw new Exception("The warehouse code parameter is empty");
            }
            if (string.IsNullOrWhiteSpace(createWareHouseDTO.Name))
            {
                throw new Exception("The warehouse name parameter is empty");
            }
            if (string.IsNullOrWhiteSpace(createWareHouseDTO.Type))
            {
                throw new Exception("The warehouse name parameter is empty");
            }

            if (await IsExistAsync(createWareHouseDTO.Code))
            {
                throw new Exception("The warehouse already exists");
            }
            WareHouse wareHouse = new WareHouse();
            wareHouse.Code = createWareHouseDTO.Code;
            wareHouse.Name = createWareHouseDTO.Name;
            wareHouse.CreateTime = DateTime.Now;
            wareHouse.Creator = currentUserId;
            wareHouse.Type = createWareHouseDTO.Type;
            wareHouse.Remark = createWareHouseDTO.Remark;
            wareHouse.Status = (int)DataStatus.Normal;
            var result = await _db.WareHouses.AddAsync(wareHouse);
            await _db.SaveChangesAsync();
            return result.Entity.Id;
        }

        /// <summary>
        /// 根据仓库id删除仓库信息 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        public async Task<long> DelAsync(long id, long currentUserId)
        {
            if (id <= 0)
            {
                throw new Exception("The warehouse id parameter is empty");
            }
            var wareHouse = await _db.WareHouses.Where(m => m.Id == id && m.Status == (int)DataStatus.Normal).SingleOrDefaultAsync();
            if (wareHouse == null)
            {
                throw new Exception($"No information found for Warehouse,id is {id}");
            }
            if (await _db.StockInventories.AnyAsync(m => m.WareHouseCode.Equals(wareHouse.Code) && m.Status == (int)DataStatus.Normal))
            {
                throw new Exception("The warehouse is in use and cannot be deleted");
            }
            if (await _db.Areas.AnyAsync(m => m.WareHouseId == id && m.Status == (int)DataStatus.Normal))
            {
                throw new Exception("The warehouse is in use and cannot be deleted");
            }
            wareHouse.Status = (int)DataStatus.Delete;
            wareHouse.UpdateTime = DateTime.Now;
            wareHouse.Updator = currentUserId;
            return await _db.SaveChangesAsync();
        }

        /// <summary>
        /// 下载仓库模板
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult<string>> DownloadTemplateAsync()
        {
            List<WareHouseDownloadTemplate> list = new List<WareHouseDownloadTemplate>();
            return await MiniExcelUtil.ExportAsync("下载仓库模板", list);
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="wareHouseParamsDTO"></param>
        /// <returns></returns>
        public async Task<ActionResult<string>> ExportAsync([FromQuery] WareHouseParamsDTO wareHouseParamsDTO)
        {
            var items = _db.WareHouses.Where(m => m.Status == (int)DataStatus.Normal).AsNoTracking();
            if (!string.IsNullOrWhiteSpace(wareHouseParamsDTO.Code))
            {
                items = items.Where(m => m.Code.StartsWith(wareHouseParamsDTO.Code));
            }
            if (!string.IsNullOrWhiteSpace(wareHouseParamsDTO.Name))
            {
                items = items.Where(m => m.Name.StartsWith(wareHouseParamsDTO.Name));
            }
            if (!string.IsNullOrWhiteSpace(wareHouseParamsDTO.WareHouseType))
            {
                items = items.Where(m => m.Type.StartsWith(wareHouseParamsDTO.WareHouseType));
            }
            var result = items.Adapt<List<WareHouseExportTemplate>>();
            return await MiniExcelUtil.ExportAsync("仓库信息", result);
        }

        /// <summary>
        /// 查询仓库信息
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<List<WareHouse>> GetListAsync([FromQuery] WareHouseParamsDTO wareHouseParamsDTO)
        {
            var items = _db.WareHouses.Where(m => m.Status == (int)DataStatus.Normal).AsNoTracking();
            if (!string.IsNullOrWhiteSpace(wareHouseParamsDTO.Code))
            {
                items = items.Where(m => m.Code.StartsWith(wareHouseParamsDTO.Code));
            }
            if (!string.IsNullOrWhiteSpace(wareHouseParamsDTO.Name))
            {
                items = items.Where(m => m.Name.StartsWith(wareHouseParamsDTO.Name));
            }
            if (!string.IsNullOrWhiteSpace(wareHouseParamsDTO.WareHouseType))
            {
                items = items.Where(m => m.Type.StartsWith(wareHouseParamsDTO.WareHouseType));
            }
            return await items.ToListAsync();
        }

        /// <summary>
        /// 查询仓库信息分页
        /// </summary>
        /// <param name="wareHouseParamsDTO"></param>
        /// <returns></returns>
        public async Task<BasePagination<WareHouse>> GetPaginationAsync([FromQuery] WareHouseParamsDTO wareHouseParamsDTO)
        {
            var items = _db.WareHouses.Where(m => m.Status == (int)DataStatus.Normal).AsNoTracking();
            if (!string.IsNullOrWhiteSpace(wareHouseParamsDTO.Code))
            {
                items = items.Where(m => m.Code.StartsWith(wareHouseParamsDTO.Code));
            }
            if (!string.IsNullOrWhiteSpace(wareHouseParamsDTO.Name))
            {
                items = items.Where(m => m.Name.StartsWith(wareHouseParamsDTO.Name));
            }
            if (!string.IsNullOrWhiteSpace(wareHouseParamsDTO.WareHouseType))
            {
                items = items.Where(m => m.Type.StartsWith(wareHouseParamsDTO.WareHouseType));
            }
            return await PaginationService.PaginateAsync(items, wareHouseParamsDTO.PageIndex, wareHouseParamsDTO.PageSize);
        }

        /// <summary>
        /// 根据仓库编码查询仓库信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<WareHouse> GetWareHouseByCodeAsync(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new Exception("The warehouse code parameter is empty");
            }
            var wareHouse = await _db.WareHouses.Where(m => m.Code.Equals(code) && m.Status == (int)DataStatus.Normal).SingleOrDefaultAsync();
            if (wareHouse == null)
            {
                throw new Exception($"No information found for Warehouse,code is {code}");
            }
            return wareHouse;
        }

        /// <summary>
        /// 根据codes集合获取用户数据
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        public async Task<List<WareHouse>> GetWareHouseByCodesAsync(string codes)
        {
            var list = new List<WareHouse>();
            if (!string.IsNullOrWhiteSpace(codes))
            {
                var codeList = codes.Split(',').ToList();
                list = await _db.WareHouses.Where(m => codeList.Contains(m.Code) && m.Status == (int)DataStatus.Normal).ToListAsync();
            }
            return list;
        }

        /// <summary>
        /// 根据仓库id查询仓库信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<WareHouse> GetWareHouseByIdAsync(long id)
        {
            if (id <= 0)
            {
                throw new Exception("The warehouse id parameter is empty");
            }
            var wareHouse = await _db.WareHouses.Where(m => m.Id == id && m.Status == (int)DataStatus.Normal).SingleOrDefaultAsync();
            if (wareHouse == null)
            {
                throw new Exception($"No information found for Warehouse,id is {id}");
            }
            return wareHouse;
        }

        /// <summary>
        /// 根据ids集合获取仓库数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public async Task<List<WareHouse>> GetWareHouseByIdsAsync(string ids)
        {
            var list = new List<WareHouse>();
            if (!string.IsNullOrWhiteSpace(ids))
            {
                var items = ids.Split(',').ToList();
                List<long> idList = items.Select(s => long.Parse(s)).ToList();
                list = await _db.WareHouses.Where(m => idList.Contains(m.Id) && m.Status == (int)DataStatus.Normal).ToListAsync();
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
        public async Task<string> ImportAsync(string path, long currentUserId)
        {
            var result = MiniExcelUtil.Import<WareHouseDownloadTemplate>(path).ToList();
            if (result == null || result.Count <= 0)
            {
                throw new Exception("Import data is empty");
            }
            //判断仓库编码有没有空值
            if (result.Any(m => string.IsNullOrWhiteSpace(m.Code)))
            {
                throw new Exception("There is a null value in the imported warehouse code");
            }
            //判断仓库名称有没有空值
            if (result.Any(m => string.IsNullOrWhiteSpace(m.Name)))
            {
                throw new Exception("There is a null value in the imported warehouse name");
            }
            //判断仓库类型有没有空值
            if (result.Any(m => string.IsNullOrWhiteSpace(m.Type)))
            {
                throw new Exception("There is a null value in the imported warehouse type");
            }
            //判断仓库编码是否有重复
            if (result.GroupBy(m => m.Code).Any(group => group.Count() > 1))
            {
                throw new Exception("warehouse code duplication");
            }
            //判断仓库是否存在
            var wareCodeList = result.Select(m => m.Code).ToList();
            var wareHouseItems = await _db.WareHouses.Where(m => wareCodeList.Contains(m.Code) && m.Status == (int)DataStatus.Normal).ToListAsync();
            if (wareHouseItems != null && wareHouseItems.Count > 0)
            {
                throw new Exception("warehouse code already exists");
            }

            var data = result.Select(m => new WareHouse 
            {
                Name = m.Name,
                Code = m.Code,
                Type = m.Type,
                Status = (int)DataStatus.Normal,
                Creator = currentUserId,
                Remark = m.Remark,
                CreateTime = DateTime.Now,

            });
            await _db.BulkInsertAsync(data);
            await _db.SaveChangesAsync();
            return "Import Warehouse successful";
        }

        /// <summary>
        /// 根据code判断仓库是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> IsExistAsync(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new Exception("The warehouse code parameter is empty");
            }
            var wareHouse = await _db.WareHouses.Where(m => m.Code.Equals(code) && m.Status == (int)DataStatus.Normal).SingleOrDefaultAsync();
            if (wareHouse == null)
            {
                return false;
            }
            return true;
        }
    }
}

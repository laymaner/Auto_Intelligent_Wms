using Auto_Intelligent_Wms.Core.Common.Enum;
using Auto_Intelligent_Wms.Core.Common.Utils;
using Auto_Intelligent_Wms.Core.IServices.IServices;
using Auto_Intelligent_Wms.Core.Model.BaseModel;
using Auto_Intelligent_Wms.Core.Model.Entities;
using Auto_Intelligent_Wms.Core.Model.ImExportTemplate.Factory;
using Auto_Intelligent_Wms.Core.Model.ImExportTemplate.Role;
using Auto_Intelligent_Wms.Core.Model.RequestDTO.Factory;
using Mapster;
using Mask_STK.Core.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Xml.Linq;

namespace Auto_Intelligent_Wms.Core.Services.Services
{
    public class FactoryService : IFactoryService
    {
        private readonly Auto_Inteligent_Wms_DbContext _db;
        private readonly ILogger<FactoryService> _log;

        public FactoryService(Auto_Inteligent_Wms_DbContext db,ILogger<FactoryService> logger)
        {
            _db = db;
            _log = logger;
        }

        /// <summary>
        /// 创建工厂
        /// </summary>
        /// <param name="createOrUpdateFactoryDTO"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<long> CreateAsync([FromBody] CreateFactoryDTO createOrUpdateFactoryDTO, long currentUserId)
        {
            if (string.IsNullOrWhiteSpace(createOrUpdateFactoryDTO.Code))
            {
                throw new Exception("The factory code parameter is empty");
            }
            if (string.IsNullOrWhiteSpace(createOrUpdateFactoryDTO.Name))
            {
                throw new Exception("The factory name parameter is empty");
            }
            if (await IsExistAsync(createOrUpdateFactoryDTO.Code))
            {
                throw new Exception("The factory already exists");
            }
            Factory factory = new Factory();
            factory.Code= createOrUpdateFactoryDTO.Code;
            factory.Name= createOrUpdateFactoryDTO.Name;
            factory.Remark= createOrUpdateFactoryDTO.Remark;
            factory.Status = (int)DataStatus.Normal;
            factory.CreateTime = DateTime.Now;
            factory.Creator = currentUserId;
            var result = await _db.Factorys.AddAsync(factory);
            await _db.SaveChangesAsync();
            return result.Entity.Id;
        }

        /// <summary>
        /// 根据工厂id删除工厂信息 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<long> DelAsync(long id, long currentUserId)
        {
            if (id <= 0)
            {
                throw new Exception("The factory id parameter is empty");
            }
            var factory = await _db.Factorys.Where(m => m.Id == id && m.Status == (int)DataStatus.Normal).SingleOrDefaultAsync();
            if (factory == null)
            {
                throw new Exception($"No information found for Factory,id is {id}");
            }
            if (await _db.MaterialStocks.AnyAsync(m => m.FactoryId == id && m.Status == (int)DataStatus.Normal))
            {
                throw new Exception("The factory is in use and cannot be deleted");
            }
            if (await _db.WareHouses.AnyAsync(m => m.FactoryId == id && m.Status == (int)DataStatus.Normal))
            {
                throw new Exception("The factory is in use and cannot be deleted");
            }
            factory.Status = (int)DataStatus.Delete;
            factory.UpdateTime = DateTime.Now;
            factory.Updator = currentUserId;
            return await _db.SaveChangesAsync();
        }

        /// <summary>
        /// 下载工厂模板
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ActionResult<string>> DownloadTemplateAsync()
        {
            List<FactoryDownloadTemplate> list = new List<FactoryDownloadTemplate>();
            return await MiniExcelUtil.ExportAsync("下载工厂模板", list);
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ActionResult<string>> ExportAsync([FromQuery] FactoryParamsDTO factoryParamsDTO)
        {
            var items = _db.Factorys.Where(m => m.Status == (int)DataStatus.Normal).AsNoTracking();
            if (!string.IsNullOrWhiteSpace(factoryParamsDTO.Code))
            {
                items = items.Where(m => m.Code.StartsWith(factoryParamsDTO.Code));
            }
            if (!string.IsNullOrWhiteSpace(factoryParamsDTO.Name))
            {
                items = items.Where(m => m.Name.StartsWith(factoryParamsDTO.Name));
            }
            var result = items.Adapt<List<FactoryExportTemplate>>();
            return await MiniExcelUtil.ExportAsync("工厂信息",result);
        }

        /// <summary>
        /// 根据工厂编码获取工厂信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Factory> GetFactoryByCodeAsync(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new Exception("The factory code parameter is empty");
            }
            var factory = await _db.Factorys.Where(m => m.Code.Equals(code) && m.Status == (int)DataStatus.Normal).SingleOrDefaultAsync();
            if (factory == null)
            {
                throw new Exception($"No information found for Factory,code is {code}");
            }
            return factory;
        }

        /// <summary>
        /// 根据codes集合获取工厂数据
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        public async Task<List<Factory>> GetFactoryByCodesAsync(string codes)
        {
            var list = new List<Factory>();
            if (!string.IsNullOrWhiteSpace(codes))
            {
                var codeList = codes.Split(',').ToList();
                list = await _db.Factorys.Where(m => codeList.Contains(m.Code) && m.Status == (int)DataStatus.Normal).ToListAsync();
            }
            return list;
        }

        /// <summary>
        /// 根据工厂id获取工厂信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Factory> GetFactoryByIdAsync(long id)
        {
            if (id<=0)
            {
                throw new Exception("The factory id parameter is empty");
            }
            var factory = await _db.Factorys.Where(m => m.Id == id && m.Status == (int)DataStatus.Normal).SingleOrDefaultAsync();
            if (factory == null)
            {
                throw new Exception($"No information found for Factory,id is {id}");
            }
            return factory;
        }

        /// <summary>
        /// 根据ids集合获取工厂数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public async Task<List<Factory>> GetFactoryByIdsAsync(string ids)
        {
            var list = new List<Factory>();
            if (!string.IsNullOrWhiteSpace(ids))
            {
                var items = ids.Split(',').ToList();
                List<long> idList = items.Select(s => long.Parse(s)).ToList();
                list = await _db.Factorys.Where(m => idList.Contains(m.Id) && m.Status == (int)DataStatus.Normal).ToListAsync();
            }
            return list;
        }

        /// <summary>
        /// 查询工厂数据信息
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<List<Factory>> GetListAsync([FromQuery] FactoryParamsDTO factoryParamsDTO)
        {
            var items = _db.Factorys.Where(m => m.Status == (int)DataStatus.Normal).AsNoTracking();
            if (!string.IsNullOrWhiteSpace(factoryParamsDTO.Code))
            {
                items = items.Where(m => m.Code.StartsWith(factoryParamsDTO.Code));
            }
            if (!string.IsNullOrWhiteSpace(factoryParamsDTO.Name))
            {
                items = items.Where(m => m.Name.StartsWith(factoryParamsDTO.Name));
            }
            return await items.ToListAsync();
        }

        /// <summary>
        /// 分页查询工厂信息
        /// </summary>
        /// <param name="factoryParamsDTO"></param>
        /// <returns></returns>
        public async Task<BasePagination<Factory>> GetPaginationAsync([FromQuery] FactoryParamsDTO factoryParamsDTO)
        {
            var items = _db.Factorys.Where(m => m.Status == (int)DataStatus.Normal).AsNoTracking();
            if (!string.IsNullOrWhiteSpace(factoryParamsDTO.Code))
            {
                items = items.Where(m => m.Code.StartsWith(factoryParamsDTO.Code));
            }
            if (!string.IsNullOrWhiteSpace(factoryParamsDTO.Name))
            {
                items = items.Where(m => m.Name.StartsWith(factoryParamsDTO.Name));
            }
            return await PaginationService.PaginateAsync(items, factoryParamsDTO.PageIndex, factoryParamsDTO.PageSize);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="path"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<string> ImportAsync(string path, long currentUserId)
        {
            var result = MiniExcelUtil.Import<FactoryDownloadTemplate>(path).ToList();
            if (result == null || result.Count <= 0)
            {
                throw new Exception("Import data is empty");
            }
            //判断工厂编码有没有空值
            if (result.Any(m => string.IsNullOrWhiteSpace(m.Code)))
            {
                throw new Exception("There is a null value in the imported factory code");
            }
            //判断工厂姓名有没有空值
            if (result.Any(m => string.IsNullOrWhiteSpace(m.Name)))
            {
                throw new Exception("There is a null value in the imported factory name");
            }
            //判断工厂编码是否有重复
            if (result.GroupBy(m => m.Code).Any(group => group.Count() > 1))
            {
                throw new Exception("factory code duplication");
            }
            var codeList = result.Select(m => m.Code).ToList();
            var items = await _db.Factorys.Where(m => codeList.Contains(m.Code) && m.Status == (int)DataStatus.Normal).ToListAsync();
            if (items != null && items.Count > 0)
            {
                throw new Exception("factory code already exists");
            }

            var data = result.Select(m => new Factory
            {
                Name = m.Name,
                Code = m.Code,
                Status = (int)DataStatus.Normal,
                Creator = currentUserId,
                Remark = m.Remark,
                CreateTime = DateTime.Now,
            });
            await _db.BulkInsertAsync(data);
            await _db.SaveChangesAsync();
            return "Import Factory successful";
        }

        /// <summary>
        /// 根据code判断工厂是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<bool> IsExistAsync(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new Exception("The factory code parameter is empty");
            }
            var factory = await _db.Factorys.Where(m => m.Code.Equals(code) && m.Status == (int)DataStatus.Normal).SingleOrDefaultAsync();
            if (factory == null)
            {
                return false;
            }
            return true;
        }
    }
}

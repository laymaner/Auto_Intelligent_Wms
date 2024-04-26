using Auto_Intelligent_Wms.Core.Common.Enum;
using Auto_Intelligent_Wms.Core.Common.Utils;
using Auto_Intelligent_Wms.Core.Extensions.Attri;
using Auto_Intelligent_Wms.Core.IServices.IServices;
using Auto_Intelligent_Wms.Core.Model.BaseModel;
using Auto_Intelligent_Wms.Core.Model.Entities;
using Auto_Intelligent_Wms.Core.Model.ImExportTemplate.Material;
using Auto_Intelligent_Wms.Core.Model.RequestDTO.Material;
using Mapster;
using Mask_STK.Core.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Intelligent_Wms.Core.Services.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly Auto_Inteligent_Wms_DbContext _db;
        private readonly ILogger<MaterialService> _log;
        public MaterialService(Auto_Inteligent_Wms_DbContext auto_Inteligent_Wms_DbContext,ILogger<MaterialService> logger) 
        {
            _db = auto_Inteligent_Wms_DbContext;
            _log = logger;
        }

        /// <summary>
        /// 创建物料信息
        /// </summary>
        /// <param name="createMaterialDTO"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<long> CreateAsync([FromBody] CreateMaterialDTO createMaterialDTO, long currentUserId)
        {
            //判断物料编码有没有空值
            if (string.IsNullOrWhiteSpace(createMaterialDTO.Code))
            {
                throw new Exception("There is a null value in the imported material code");
            }
            //判断物料名称有没有空值
            if (string.IsNullOrWhiteSpace(createMaterialDTO.Name))
            {
                throw new Exception("There is a null value in the imported material name");
            }
            //判断物料类型有没有空值
            if (string.IsNullOrWhiteSpace(createMaterialDTO.Type))
            {
                throw new Exception("There is a null value in the imported materila type");
            }
            //判断基本单位有没有空值
            if (string.IsNullOrWhiteSpace(createMaterialDTO.Unit))
            {
                throw new Exception("There is a null value in the imported materila unit");
            }
            //判断价格单位有没有空值
            if (string.IsNullOrWhiteSpace(createMaterialDTO.PriceUint))
            {
                throw new Exception("There is a null value in the imported materila priceunit");
            }
            //判断基本数量
            if (createMaterialDTO.Quantity <=0)
            {
                throw new Exception("There is a null value in the imported materila Quantity");
            }
            //判断最小包装数
            if (createMaterialDTO.MinimumPackagingQuantity <= 0)
            {
                throw new Exception("There is a null value in the imported materila MinimumPackagingQuantity");
            }
            //判断价格
            if (createMaterialDTO.Price <= 0)
            {
                throw new Exception("There is a null value in the imported materila Price");
            }
            //判断有效期
            if (createMaterialDTO.ValidityPeriod <= DateTime.Now)
            {
                throw new Exception("Validity format error");
            }
            //判断是否存在
            if (await IsExistAsync(createMaterialDTO.Code))
            {
                throw new Exception("The materila already exists");
            }
            var material =createMaterialDTO.Adapt<Material>();
            material.CreateTime = DateTime.Now;
            material.Creator = currentUserId;
            material.Status = (int)DataStatus.Normal;

            var result = await _db.Materials.AddAsync(material);
            await _db.SaveChangesAsync();
            return result.Entity.Id;

        }

        /// <summary>
        /// 根据物料id删除物料信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [Transation]
        public async Task<long> DelAsync(long id, long currentUserId)
        {
            if (id <= 0)
            {
                throw new Exception("The material id parameter is empty");
            }
            var material = await _db.Materials.Where(m => m.Id == id && m.Status == (int)DataStatus.Normal).SingleOrDefaultAsync();
            if (material == null)
            {
                throw new Exception($"No information found for material,id is {id}");
            }
            if (await _db.Material_Supplier_RelationShips.AnyAsync(m => m.MaterialId == id && m.Status == (int)DataStatus.Normal))
            {
                throw new Exception("The material is in use and cannot be deleted");
            }
            if (await _db.StockInventories.AnyAsync(m => m.MaterialCode.Equals(material.Code) && m.Status == (int)DataStatus.Normal))
            {
                throw new Exception("The material is in use and cannot be deleted");
            }
            material.Status = (int)DataStatus.Delete;
            material.UpdateTime = DateTime.Now;
            material.Updator = currentUserId;
            return await _db.SaveChangesAsync();
        }

        /// <summary>
        /// 下载物料模板
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult<string>> DownloadTemplateAsync()
        {
            List<MaterialDownloadTemplate> list = new List<MaterialDownloadTemplate>();
            return await MiniExcelUtil.ExportAsync("下载物料模板", list);
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="materialParamsDTO"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ActionResult<string>> ExportAsync([FromQuery] MaterialParamsDTO materialParamsDTO)
        {
            var items = _db.Materials.Where(m => m.Status == (int)DataStatus.Normal).AsNoTracking();
            if (!string.IsNullOrWhiteSpace(materialParamsDTO.Code))
            {
                items = items.Where(m => m.Code.StartsWith(materialParamsDTO.Code));
            }
            if (!string.IsNullOrWhiteSpace(materialParamsDTO.Name))
            {
                items = items.Where(m => m.Name.StartsWith(materialParamsDTO.Name));
            }
            if (!string.IsNullOrWhiteSpace(materialParamsDTO.Type))
            {
                items = items.Where(m => m.Name.Equals(materialParamsDTO.Type));
            }
            var result = items.Adapt<List<MaterialExportTemplate>>();
            return await MiniExcelUtil.ExportAsync("物料信息", result);
        }

        /// <summary>
        /// 查询物料信息
        /// </summary>
        /// <param name="materialParamsDTO"></param>
        /// <returns></returns>
        public async Task<List<Material>> GetListAsync([FromQuery] MaterialParamsDTO materialParamsDTO)
        {
            var items = _db.Materials.Where(m => m.Status == (int)DataStatus.Normal).AsNoTracking();
            if (!string.IsNullOrWhiteSpace(materialParamsDTO.Code))
            {
                items = items.Where(m => m.Code.StartsWith(materialParamsDTO.Code));
            }
            if (!string.IsNullOrWhiteSpace(materialParamsDTO.Name))
            {
                items = items.Where(m => m.Name.StartsWith(materialParamsDTO.Name));
            }
            if (!string.IsNullOrWhiteSpace(materialParamsDTO.Type))
            {
                items = items.Where(m => m.Name.Equals(materialParamsDTO.Type));
            }
            return await items.ToListAsync();
        }

        /// <summary>
        /// 根据物料编码获取物料信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Material> GetMaterialByCodeAsync(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new Exception("The Material code parameter is empty");
            }
            var material = await _db.Materials.Where(m => m.Code.Equals(code) && m.Status == (int)DataStatus.Normal).SingleOrDefaultAsync();
            if (material == null)
            {
                throw new Exception($"No information found for Material,code is {code}");
            }
            return material;
        }

        /// <summary>
        /// 根据物料code集合获取物料信息
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        public async Task<List<Material>> GetMaterialByCodesAsync(string codes)
        {
            var list = new List<Material>();
            if (!string.IsNullOrWhiteSpace(codes))
            {
                var codeList = codes.Split(',').ToList();
                list = await _db.Materials.Where(m => codeList.Contains(m.Code) && m.Status == (int)DataStatus.Normal).ToListAsync();
            }
            return list;
        }

        /// <summary>
        /// 根据物料id获取物料信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Material> GetMaterialByIdAsync(long id)
        {
            if (id <= 0)
            {
                throw new Exception("The Material id parameter is empty");
            }
            var material = await _db.Materials.Where(m => m.Id == id && m.Status == (int)DataStatus.Normal).SingleOrDefaultAsync();
            if (material == null)
            {
                throw new Exception($"No information found for Material,id is {id}");
            }
            return material;
        }

        /// <summary>
        /// 根据物料ids集合获取物料信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public async Task<List<Material>> GetMaterialByIdsAsync(string ids)
        {
            var list = new List<Material>();
            if (!string.IsNullOrWhiteSpace(ids))
            {
                var items = ids.Split(',').ToList();
                List<long> idList = items.Select(s => long.Parse(s)).ToList();
                list = await _db.Materials.Where(m => idList.Contains(m.Id) && m.Status == (int)DataStatus.Normal).ToListAsync();
            }
            return list;
        }

        /// <summary>
        /// 查询物料信息分页
        /// </summary>
        /// <param name="materialParamsDTO"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<BasePagination<Material>> GetPaginationAsync([FromQuery] MaterialParamsDTO materialParamsDTO)
        {
            var items = _db.Materials.Where(m => m.Status == (int)DataStatus.Normal).AsNoTracking();
            if (!string.IsNullOrWhiteSpace(materialParamsDTO.Code))
            {
                items = items.Where(m => m.Code.StartsWith(materialParamsDTO.Code));
            }
            if (!string.IsNullOrWhiteSpace(materialParamsDTO.Name))
            {
                items = items.Where(m => m.Name.StartsWith(materialParamsDTO.Name));
            }
            if (!string.IsNullOrWhiteSpace(materialParamsDTO.Type))
            {
                items = items.Where(m => m.Name.Equals(materialParamsDTO.Type));
            }
            return await PaginationService.PaginateAsync(items,materialParamsDTO.PageIndex,materialParamsDTO.PageSize);

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
            var result = MiniExcelUtil.Import<MaterialDownloadTemplate>(path).ToList();
            if (result == null || result.Count <= 0)
            {
                throw new Exception("Import data is empty");
            }
            //判断物料编码有没有空值
            if (result.Any(m => string.IsNullOrWhiteSpace(m.Code)))
            {
                throw new Exception("There is a null value in the imported material code");
            }
            //判断物料名称有没有空值
            if (result.Any(m => string.IsNullOrWhiteSpace(m.Name)))
            {
                throw new Exception("There is a null value in the imported material name");
            }
            //判断物料类型有没有空值
            if (result.Any(m => string.IsNullOrWhiteSpace(m.Type)))
            {
                throw new Exception("There is a null value in the imported materila type");
            }
            //判断基本单位有没有空值
            if (result.Any(m => string.IsNullOrWhiteSpace(m.Unit)))
            {
                throw new Exception("There is a null value in the imported materila unit");
            }
            //判断价格单位有没有空值
            if (result.Any(m => string.IsNullOrWhiteSpace(m.PriceUint)))
            {
                throw new Exception("There is a null value in the imported materila priceunit");
            }
            //判断基本数量
            if (result.Any(m => m.Quantity <=0))
            {
                throw new Exception("There is a null value in the imported materila Quantity");
            }
            //判断最小包装数
            if (result.Any(m => m.MinimumPackagingQuantity <= 0))
            {
                throw new Exception("There is a null value in the imported materila MinimumPackagingQuantity");
            }
            //判断价格
            if (result.Any(m => m.Price <= 0))
            {
                throw new Exception("There is a null value in the imported materila Price");
            }
            //判断有效期
            if (result.Any(m => m.ValidityPeriod <= DateTime.Now))
            {
                throw new Exception("Validity format error");
            }
            //判断物料编码是否有重复
            if (result.GroupBy(m => m.Code).Any(group => group.Count() > 1))
            {
                throw new Exception("material code duplication");
            }
            //判断物料是否存在
            var materialCodeList = result.Select(m => m.Code).ToList();
            var materialItems = await _db.Materials.Where(m => materialCodeList.Contains(m.Code) && m.Status == (int)DataStatus.Normal).ToListAsync();
            if (materialItems != null && materialItems.Count > 0)
            {
                throw new Exception("material code already exists");
            }
         
            var data = result.Select(m => new Material
            {
                Name = m.Name,
                Code = m.Code,
                Unit = m.Unit,
                Price = m.Price,
                Description = m.Description,
                Version = m.Version,
                ValidityPeriod = m.ValidityPeriod,
                MinimumPackagingQuantity = m.MinimumPackagingQuantity,
                Quantity = m.Quantity,
                PriceUint = m.PriceUint,
                Type = m.Type,
                Status = (int)DataStatus.Normal,
                Creator = currentUserId,
                Remark = m.Remark,
                CreateTime = DateTime.Now,
            });
            await _db.BulkInsertAsync(data);
            await _db.SaveChangesAsync();
            return "Import material successful";
        }

        /// <summary>
        /// 根据物料code判断物料是存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> IsExistAsync(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new Exception("The material code parameter is empty");
            }
            var material = await _db.Materials.Where(m => m.Code.Equals(code) && m.Status == (int)DataStatus.Normal).SingleOrDefaultAsync();
            if (material == null)
            {
                return false;
            }
            return true;
        }
    }
}

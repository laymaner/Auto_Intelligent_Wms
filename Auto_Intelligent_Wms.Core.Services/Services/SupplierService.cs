using Auto_Intelligent_Wms.Core.Common.Enum;
using Auto_Intelligent_Wms.Core.Common.Utils;
using Auto_Intelligent_Wms.Core.IServices.IServices;
using Auto_Intelligent_Wms.Core.Model.BaseModel;
using Auto_Intelligent_Wms.Core.Model.Entities;
using Auto_Intelligent_Wms.Core.Model.ImExportTemplate.Material;
using Auto_Intelligent_Wms.Core.Model.ImExportTemplate.Supplier;
using Auto_Intelligent_Wms.Core.Model.RequestDTO.Material;
using Auto_Intelligent_Wms.Core.Model.RequestDTO.Supplier;
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
    public class SupplierService : ISupplierService
    {
        private readonly Auto_Inteligent_Wms_DbContext _db;
        private readonly ILogger<SupplierService> _log;

        public SupplierService(Auto_Inteligent_Wms_DbContext db, ILogger<SupplierService> log)
        {
            _db = db;
            _log = log;
        }

        /// <summary>
        /// 创建供应商信息
        /// </summary>
        /// <param name="createSupplierDTO"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<long> CreateAsync([FromBody] CreateSupplierDTO createSupplierDTO, long currentUserId)
        {
            //判断供应商编码有没有空值
            if (string.IsNullOrWhiteSpace(createSupplierDTO.Code))
            {
                throw new Exception("There is a null value in the imported Supplier code");
            }
            //判断供应商名称有没有空值
            if (string.IsNullOrWhiteSpace(createSupplierDTO.Name))
            {
                throw new Exception("There is a null value in the imported Supplier name");
            }
            if (await IsExistAsync(createSupplierDTO.Code))
            {
                throw new Exception("The Supplier already exists");
            }
            var supplier = createSupplierDTO.Adapt<Supplier>();
            supplier.CreateTime = DateTime.Now;
            supplier.Creator = currentUserId;
            supplier.Status = (int)DataStatus.Normal;

            var result = await _db.Suppliers.AddAsync(supplier);
            await _db.SaveChangesAsync();
            return result.Entity.Id;
        }

        /// <summary>
        /// 根据供应商id删除供应商信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<long> DelAsync(long id, long currentUserId)
        {
            if (id <= 0)
            {
                throw new Exception("The Supplier id parameter is empty");
            }
            var supplier = await _db.Suppliers.Where(m => m.Id == id && m.Status == (int)DataStatus.Normal).SingleOrDefaultAsync();
            if (supplier == null)
            {
                throw new Exception($"No information found for Supplier,id is {id}");
            }
            if (await _db.Material_Supplier_RelationShips.AnyAsync(m => m.SupplierId == id && m.Status == (int)DataStatus.Normal))
            {
                throw new Exception("The Supplier is in use and cannot be deleted");
            }
            if (await _db.StockInventories.AnyAsync(m => m.SupplierCode.Equals(supplier.Code) && m.Status == (int)DataStatus.Normal))
            {
                throw new Exception("The Supplier is in use and cannot be deleted");
            }
            supplier.Status = (int)DataStatus.Delete;
            supplier.UpdateTime = DateTime.Now;
            supplier.Updator = currentUserId;
            return await _db.SaveChangesAsync();
        }

        /// <summary>
        /// 下载供应商模板
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult<string>> DownloadTemplateAsync()
        {
            List<SupplierDownloadTemplate> list = new List<SupplierDownloadTemplate>();
            return await MiniExcelUtil.ExportAsync("下载供应商模板", list);
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="supplierParamsDTO"></param>
        /// <returns></returns>
        public async Task<ActionResult<string>> ExportAsync([FromQuery] SupplierParamsDTO supplierParamsDTO)
        {
            var items = _db.Suppliers.Where(m => m.Status == (int)DataStatus.Normal).AsNoTracking();
            if (!string.IsNullOrWhiteSpace(supplierParamsDTO.Code))
            {
                items = items.Where(m => m.Code.StartsWith(supplierParamsDTO.Code));
            }
            if (!string.IsNullOrWhiteSpace(supplierParamsDTO.Name))
            {
                items = items.Where(m => m.Name.StartsWith(supplierParamsDTO.Name));
            }
            var result = items.Adapt<List<SupplierExportTemplate>>();
            return await MiniExcelUtil.ExportAsync("供应商信息", result);
        }
        
        /// <summary>
        /// 查询供应商信息
        /// </summary>
        /// <param name="supplierParamsDTO"></param>
        /// <returns></returns>
        public async Task<List<Supplier>> GetListAsync([FromQuery] SupplierParamsDTO supplierParamsDTO)
        {
            var items = _db.Suppliers.Where(m => m.Status == (int)DataStatus.Normal).AsNoTracking();
            if (!string.IsNullOrWhiteSpace(supplierParamsDTO.Code))
            {
                items = items.Where(m => m.Code.StartsWith(supplierParamsDTO.Code));
            }
            if (!string.IsNullOrWhiteSpace(supplierParamsDTO.Name))
            {
                items = items.Where(m => m.Name.StartsWith(supplierParamsDTO.Name));
            }
            return await items.ToListAsync();
        }

        /// <summary>
        /// 查询供应商分页信息
        /// </summary>
        /// <param name="supplierParamsDTO"></param>
        /// <returns></returns>
        public async Task<BasePagination<Supplier>> GetPaginationAsync([FromQuery] SupplierParamsDTO supplierParamsDTO)
        {
            var items = _db.Suppliers.Where(m => m.Status == (int)DataStatus.Normal).AsNoTracking();
            if (!string.IsNullOrWhiteSpace(supplierParamsDTO.Code))
            {
                items = items.Where(m => m.Code.StartsWith(supplierParamsDTO.Code));
            }
            if (!string.IsNullOrWhiteSpace(supplierParamsDTO.Name))
            {
                items = items.Where(m => m.Name.StartsWith(supplierParamsDTO.Name));
            }
            return await PaginationService.PaginateAsync(items,supplierParamsDTO.PageIndex,supplierParamsDTO.PageSize);
        }

        /// <summary>
        /// 根据供应商编码获取供应商信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Supplier> GetSupplierByCodeAsync(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new Exception("The Supplier code parameter is empty");
            }
            var supplier = await _db.Suppliers.Where(m => m.Code.Equals(code) && m.Status == (int)DataStatus.Normal).SingleOrDefaultAsync();
            if (supplier == null)
            {
                throw new Exception($"No information found for supplier,code is {code}");
            }
            return supplier;
        }

        /// <summary>
        /// 根据供应商集合codes获取供应商信息
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<Supplier>> GetSupplierByCodesAsync(string codes)
        {
            var list = new List<Supplier>();
            if (!string.IsNullOrWhiteSpace(codes))
            {
                var codeList = codes.Split(',').ToList();
                list = await _db.Suppliers.Where(m => codeList.Contains(m.Code) && m.Status == (int)DataStatus.Normal).ToListAsync();
            }
            return list;
        }

        /// <summary>
        /// 根据供应商id获取供应商信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Supplier> GetSupplierByIdAsync(long id)
        {
            if (id <= 0)
            {
                throw new Exception("The supplier id parameter is empty");
            }
            var supplier = await _db.Suppliers.Where(m => m.Id == id && m.Status == (int)DataStatus.Normal).SingleOrDefaultAsync();
            if (supplier == null)
            {
                throw new Exception($"No information found for supplier,id is {id}");
            }
            return supplier;
        }

        /// <summary>
        /// 根据供应商ids集合获取供应商信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public async Task<List<Supplier>> GetSupplierByIdsAsync(string ids)
        {
            var list = new List<Supplier>();
            if (!string.IsNullOrWhiteSpace(ids))
            {
                var items = ids.Split(',').ToList();
                List<long> idList = items.Select(s => long.Parse(s)).ToList();
                list = await _db.Suppliers.Where(m => idList.Contains(m.Id) && m.Status == (int)DataStatus.Normal).ToListAsync();
            }
            return list;
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="path"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        public async Task<string> ImportAsync(string path, long currentUserId)
        {
            var result = MiniExcelUtil.Import<SupplierDownloadTemplate>(path).ToList();
            if (result == null || result.Count <= 0)
            {
                throw new Exception("Import data is empty");
            }
            //判断供应商编码有没有空值
            if (result.Any(m => string.IsNullOrWhiteSpace(m.Code)))
            {
                throw new Exception("There is a null value in the imported supplier code");
            }
            //判断供应商名称有没有空值
            if (result.Any(m => string.IsNullOrWhiteSpace(m.Name)))
            {
                throw new Exception("There is a null value in the imported supplier name");
            }
           
            //判断物料编码是否有重复
            if (result.GroupBy(m => m.Code).Any(group => group.Count() > 1))
            {
                throw new Exception("supplier code duplication");
            }
            //判断物料是否存在
            var supplierCodeList = result.Select(m => m.Code).ToList();
            var supplierItems = await _db.Suppliers.Where(m => supplierCodeList.Contains(m.Code) && m.Status == (int)DataStatus.Normal).ToListAsync();
            if (supplierItems != null && supplierItems.Count > 0)
            {
                throw new Exception("supplier code already exists");
            }

            var data = result.Select(m => new Supplier
            {
                Name = m.Name,
                Code = m.Code,
                Address = m.Address,
                Telephone = m.Telephone,
                Email = m.Email,
                Status = (int)DataStatus.Normal,
                Creator = currentUserId,
                Remark = m.Remark,
                CreateTime = DateTime.Now,
            });
            await _db.BulkInsertAsync(data);
            await _db.SaveChangesAsync();
            return "Import supplier successful";
        }

        /// <summary>
        /// 根据供应商编码判断供应商是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<bool> IsExistAsync(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new Exception("The supplier code parameter is empty");
            }
            var supplier = await _db.Suppliers.Where(m => m.Code.Equals(code) && m.Status == (int)DataStatus.Normal).SingleOrDefaultAsync();
            if (supplier == null)
            {
                return false;
            }
            return true;
        }
    }
}

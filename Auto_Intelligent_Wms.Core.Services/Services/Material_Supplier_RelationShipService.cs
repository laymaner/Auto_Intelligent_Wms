using Auto_Intelligent_Wms.Core.Common.Enum;
using Auto_Intelligent_Wms.Core.IServices.IServices;
using Auto_Intelligent_Wms.Core.Model.BaseModel;
using Auto_Intelligent_Wms.Core.Model.Entities;
using Auto_Intelligent_Wms.Core.Model.RequestDTO.Material_Supplier_RelationShip;
using Auto_Intelligent_Wms.Core.Model.RequestDTO.User_Role_RelationShip;
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
    public class Material_Supplier_RelationShipService : IMaterial_Supplier_RelationShipService
    {
        private readonly Auto_Inteligent_Wms_DbContext _db;
        private readonly ILogger<Material_Supplier_RelationShipService> _log;

        public Material_Supplier_RelationShipService(Auto_Inteligent_Wms_DbContext db, ILogger<Material_Supplier_RelationShipService> log)
        {
            _db = db;
            _log = log;
        }

        /// <summary>
        /// 创建物料供应商关系
        /// </summary>
        /// <param name="materialId"></param>
        /// <param name="supplierId"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        public async Task<long> CreateAsync(long materialId, long supplierId, long currentUserId)
        {
            var material = await _db.Materials.Where(m => m.Id == materialId && m.Status == (int)DataStatus.Normal).SingleOrDefaultAsync();
            if (material == null)
            {
                throw new Exception($"No information found for Material,materialId is {materialId}");
            }
            var supplier = await _db.Suppliers.Where(m => m.Id == supplierId && m.Status == (int)DataStatus.Normal).SingleOrDefaultAsync();
            if (supplier == null)
            {
                throw new Exception($"No information found for Supplier,supplierId is {supplierId}");
            }
            var result = await _db.Material_Supplier_RelationShips.Where(m => m.MaterialId == materialId && m.SupplierId == supplierId && m.Status == (int)DataStatus.Normal).ToListAsync();
            if (result != null && result.Count > 0)
            {
                throw new Exception("The Material Supplier relationship already exists");
            }
            Material_Supplier_RelationShip ship = new Material_Supplier_RelationShip();
            ship.MaterialId = materialId;
            ship.SupplierId = supplierId;
            ship.SupplierCode = supplier.Code;
            ship.MaterialCode = material.Code;
            ship.Status = (int)DataStatus.Normal;
            ship.CreateTime = DateTime.Now;
            ship.Creator = currentUserId;
            var entity = await _db.Material_Supplier_RelationShips.AddAsync(ship);
            await _db.SaveChangesAsync();
            return entity.Entity.Id;
        }

        /// <summary>
        /// 根据id删除物料供应商关系
        /// </summary>
        /// <param name="id"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        public async Task<long> DelAsync(long id, long currentUserId)
        {
            if (id <= 0)
            {
                throw new Exception("Material_Supplier_RelationShip ID does not exist");
            }
            var item = await _db.Material_Supplier_RelationShips.Where(m => m.Id == id && m.Status == (int)DataStatus.Normal).SingleOrDefaultAsync();
            if (item == null)
            {
                throw new Exception($"No information found for Material_Supplier_RelationShip,Id is {id}");
            }
            item.Status = (int)DataStatus.Delete;
            item.UpdateTime = DateTime.Now;
            item.Updator = currentUserId;
            return await _db.SaveChangesAsync();
        }

        /// <summary>
        /// 查询物料供应商关系
        /// </summary>
        /// <param name="materialSupplierRelationShipParamsDTO"></param>
        /// <returns></returns>
        public async Task<List<Material_Supplier_RelationShip>> GetListAsync([FromQuery] MaterialSupplierRelationShipParamsDTO materialSupplierRelationShipParamsDTO)
        {
            var result = _db.Material_Supplier_RelationShips.Where(m => m.Status == (int)DataStatus.Normal).AsNoTracking();
            if (!String.IsNullOrWhiteSpace(materialSupplierRelationShipParamsDTO.MaterialCode))
            {
                result = result.Where(m => m.MaterialCode.StartsWith(materialSupplierRelationShipParamsDTO.MaterialCode));
            }
            if (!String.IsNullOrWhiteSpace(materialSupplierRelationShipParamsDTO.SupplierCode))
            {
                result = result.Where(m => m.SupplierCode.StartsWith(materialSupplierRelationShipParamsDTO.SupplierCode));
            }
            
            return await result.ToListAsync();
        }

        /// <summary>
        /// 分页查询物料供应商关系
        /// </summary>
        /// <param name="materialSupplierRelationShipParamsDTO"></param>
        /// <returns></returns>
        public async Task<BasePagination<Material_Supplier_RelationShip>> GetPaginationAsync([FromQuery] MaterialSupplierRelationShipParamsDTO materialSupplierRelationShipParamsDTO)
        {
            var result = _db.Material_Supplier_RelationShips.Where(m => m.Status == (int)DataStatus.Normal).AsNoTracking();
            if (!String.IsNullOrWhiteSpace(materialSupplierRelationShipParamsDTO.MaterialCode))
            {
                result = result.Where(m => m.MaterialCode.StartsWith(materialSupplierRelationShipParamsDTO.MaterialCode));
            }
            if (!String.IsNullOrWhiteSpace(materialSupplierRelationShipParamsDTO.SupplierCode))
            {
                result = result.Where(m => m.SupplierCode.StartsWith(materialSupplierRelationShipParamsDTO.SupplierCode));
            }

            return await PaginationService.PaginateAsync(result, materialSupplierRelationShipParamsDTO.PageIndex, materialSupplierRelationShipParamsDTO.PageSize);
        }
    }
}

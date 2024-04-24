using Auto_Intelligent_Wms.Core.Model.BaseModel;
using Auto_Intelligent_Wms.Core.Model.Entities;
using Auto_Intelligent_Wms.Core.Model.RequestDTO.Material_Supplier_RelationShip;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Intelligent_Wms.Core.IServices.IServices
{
    public interface IMaterial_Supplier_RelationShipService
    {
        /// <summary>
        /// 创建物料供应商关系
        /// </summary>
        /// <param name="materialId"></param>
        /// <param name="supplierId"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        public Task<long> CreateAsync(long materialId, long supplierId, long currentUserId);

        /// <summary>
        /// 查询物料供应商关系信息
        /// </summary>
        /// <param name="materialSupplierRelationShipParamsDTO"></param>
        /// <returns></returns>
        public Task<List<IMaterial_Supplier_RelationShipService>> GetListAsync([FromQuery] MaterialSupplierRelationShipParamsDTO materialSupplierRelationShipParamsDTO);

        /// <summary>
        /// 分页查询物料供应商关系信息
        /// </summary>
        /// <param name="materialSupplierRelationShipParamsDTO"></param>
        /// <returns></returns>
        public Task<BasePagination<IMaterial_Supplier_RelationShipService>> GetPaginationAsync([FromQuery] MaterialSupplierRelationShipParamsDTO materialSupplierRelationShipParamsDTO);

        /// <summary>
        /// 删除用户角色关系
        /// </summary>
        /// <param name="id"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        public Task<long> DelAsync(long id, long currentUserId);
    }
}

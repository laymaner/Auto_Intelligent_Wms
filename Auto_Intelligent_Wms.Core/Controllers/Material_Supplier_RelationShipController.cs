using Auto_Intelligent_Wms.Core.IServices.IServices;
using Auto_Intelligent_Wms.Core.Model.BaseModel;
using Auto_Intelligent_Wms.Core.Model.Entities;
using Auto_Intelligent_Wms.Core.Model.RequestDTO.Material_Supplier_RelationShip;
using Auto_Intelligent_Wms.Core.WebApi.Controller;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Auto_Intelligent_Wms.Core.WebApi.Controllers
{
    /// <summary>
    /// 物料供应商关系
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class Material_Supplier_RelationShipController : ApiControllerBase
    {

        private readonly IMaterial_Supplier_RelationShipService  _material_Supplier_RelationShipService;

        public Material_Supplier_RelationShipController(IMaterial_Supplier_RelationShipService material_Supplier_RelationShipService)
        {
            _material_Supplier_RelationShipService = material_Supplier_RelationShipService;
        }

        /// <summary>
        /// 创建物料供应商关系
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiResult<long>> CreateAsync(long userId, long roleId)
        {
            var currentUserId = long.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            var result = await _material_Supplier_RelationShipService.CreateAsync(userId, roleId, currentUserId);
            return SuccessResult(result);
        }

        /// <summary>
        /// 查询物料供应商关系
        /// </summary>
        /// <param name="materialSupplierRelationShipParamsDTO"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<List<Material_Supplier_RelationShip>>> GetListAsync([FromQuery] MaterialSupplierRelationShipParamsDTO materialSupplierRelationShipParamsDTO)
        {
            var result = await _material_Supplier_RelationShipService.GetListAsync(materialSupplierRelationShipParamsDTO);
            return SuccessResult(result);
        }

        /// <summary>
        /// 分页查询物料供应商关系
        /// </summary>
        /// <param name="materialSupplierRelationShipParamsDTO"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<BasePagination<Material_Supplier_RelationShip>>> GetPaginationAsync([FromQuery] MaterialSupplierRelationShipParamsDTO materialSupplierRelationShipParamsDTO)
        {
            var result = await _material_Supplier_RelationShipService.GetPaginationAsync(materialSupplierRelationShipParamsDTO);
            return SuccessResult(result);
        }

        /// <summary>
        /// 删除物料供应商关系
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ApiResult<long>> DelAsync(long id)
        {
            var currentUserId = long.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            var result = await _material_Supplier_RelationShipService.DelAsync(id, currentUserId);
            return SuccessResult(result);
        }
    }
}

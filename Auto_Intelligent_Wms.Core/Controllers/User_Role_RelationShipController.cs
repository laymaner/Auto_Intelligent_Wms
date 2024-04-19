using Auto_Intelligent_Wms.Core.IServices.IServices;
using Auto_Intelligent_Wms.Core.Model.BaseModel;
using Auto_Intelligent_Wms.Core.Model.Entities;
using Auto_Intelligent_Wms.Core.Model.RequestDTO.User_Role_RelationShip;
using Auto_Intelligent_Wms.Core.WebApi.Controller;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Mask_STK.Controllers
{
    /// <summary>
    /// 用户关系
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class User_Role_RelationShipController : ApiControllerBase
    {
        private readonly IUser_Role_RelationShipService _iuser_Role_RelationShipService;

        public User_Role_RelationShipController(IUser_Role_RelationShipService user_Role_RelationShipService)
        {
            _iuser_Role_RelationShipService = user_Role_RelationShipService;
        }

        /// <summary>
        /// 创建用户角色关系
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiResult<long>> CreateAsync(long userId, long roleId)
        {
            var currentUserId = long.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            var result = await _iuser_Role_RelationShipService.CreateAsync(userId,roleId,currentUserId);
            return SuccessResult(result);
        }

        /// <summary>
        /// 查询用户角色关系
        /// </summary>
        /// <param name="userRoleRelationShipParamsDTO"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<List<User_Role_RelationShip>>> GetListAsync([FromQuery] UserRoleRelationShipParamsDTO userRoleRelationShipParamsDTO)
        {
            var result = await _iuser_Role_RelationShipService.GetListAsync(userRoleRelationShipParamsDTO);
            return SuccessResult(result);
        }

        /// <summary>
        /// 分页查询用户角色关系
        /// </summary>
        /// <param name="userRoleRelationShipParamsDTO"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<BasePagination<User_Role_RelationShip>>> GetPaginationAsync([FromQuery] UserRoleRelationShipParamsDTO userRoleRelationShipParamsDTO)
        {
            var result = await _iuser_Role_RelationShipService.GetPaginationAsync(userRoleRelationShipParamsDTO);
            return SuccessResult(result);
        }

        /// <summary>
        /// 删除用户角色关系
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ApiResult<long>> DelAsync(long id)
        {
            var currentUserId = long.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            var result = await _iuser_Role_RelationShipService.DelAsync(id, currentUserId);
            return SuccessResult(result);
        }
    }
}

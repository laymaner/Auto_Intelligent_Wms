using Auto_Intelligent_Wms.Core.IServices.IServices;
using Auto_Intelligent_Wms.Core.Model.BaseModel;
using Auto_Intelligent_Wms.Core.Model.Entities;
using Auto_Intelligent_Wms.Core.Model.RequestDTO.Role;
using Auto_Intelligent_Wms.Core.Services.Services;
using Auto_Intelligent_Wms.Core.WebApi.Controller;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Security.Claims;

namespace Mask_STK.Controllers
{
    /// <summary>
    /// 角色
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class RoleController : ApiControllerBase
    {
        private readonly IRoleService _iroleService;
        
        public RoleController(IRoleService iroleService)
        {
            _iroleService = iroleService;
        }

        /// <summary>
        /// 查询角色信息
        /// </summary>
        /// <param name="roleParamsDto"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<List<Role>>> GetRolesAsync([FromQuery] RoleParamsDto roleParamsDto)
        {
            var result = await _iroleService.GetRolesAsync(roleParamsDto);
            return SuccessResult(result);
        }

        /// <summary>
        /// 根据id获取角色信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<Role>> GetRoleInfoByIdAsync(long id)
        {
            var result = await _iroleService.GetRoleInfoByIdAsync(id);
            return SuccessResult(result);
        }

        /// <summary>
        /// 根据编码获取角色信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<Role>> GetRoleInfoByCodeAsync(string code)
        {
            var result = await _iroleService.GetRoleInfoByCodeAsync(code);
            return SuccessResult(result);
        }

        /// <summary>
        /// 根据ids集合获取用户数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<List<Role>>> GetRoleByIdsAsync(string ids)
        {
            var result = await _iroleService.GetRoleByIdsAsync(ids);
            return SuccessResult(result);
        }

        /// <summary>
        /// 根据codes集合获取用户数据
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<List<Role>>> GetUserByCodesAsync(string codes)
        {
            var result = await _iroleService.GetRoleByCodesAsync(codes);
            return SuccessResult(result);
        }

        /// <summary>
        /// 判断角色是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<bool>> IsExistAsync(string code)
        {
            var result = await _iroleService.IsExistAsync(code);
            return SuccessResult(result);
        }

        /// <summary>
        /// 分页查询角色信息
        /// </summary>
        /// <param name="roleParamsDto"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<BasePagination<Role>>> GetRolePaginationAsync([FromQuery] RoleParamsDto roleParamsDto)
        {
            var result = await _iroleService.GetRolePaginationAsync(roleParamsDto);
            return SuccessResult(result);
        }

        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="createOrUpdateRoleDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiResult<long>> CreateRoleAsync([FromBody] CreateOrUpdateRoleDTO createOrUpdateRoleDTO)
        {
            var currentUserId = long.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            var result = await _iroleService.CreateRoleAsync(createOrUpdateRoleDTO, currentUserId);
            return SuccessResult(result);
        }

        /// <summary>
        /// 更新角色信息
        /// </summary>
        /// <param name="createOrUpdateRoleDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiResult<string>> UpdateRoleAsync([FromBody] CreateOrUpdateRoleDTO createOrUpdateRoleDTO)
        {
            var currentUserId = long.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            var result = await _iroleService.UpdateRoleAsync(createOrUpdateRoleDTO, currentUserId);
            return SuccessResult(result);
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ApiResult<long>> DelRoleAsync(long id)
        {
            var currentUserId = long.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            var result = await _iroleService.DelRoleAsync(id, currentUserId);
            return SuccessResult(result);
        }

        /// <summary>
        /// 下载Excel模板
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> DownloadTemplateAsync()
        {
            return await _iroleService.DownloadTemplateAsync();
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="roleParamsDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> ExportAsync([FromQuery] RoleParamsDto roleParamsDto)
        {
            return await _iroleService.ExportAsync(roleParamsDto);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiResult<string>> ImportAsync(string path)
        {
            var currentUserId = long.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            var result = await _iroleService.ImportAsync(path, currentUserId);
            return SuccessResult(result);
        }

    }
}

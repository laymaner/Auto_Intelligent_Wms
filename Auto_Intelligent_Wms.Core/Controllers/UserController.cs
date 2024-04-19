using Auto_Intelligent_Wms.Core.IServices.IServices;
using Auto_Intelligent_Wms.Core.Model.BaseModel;
using Auto_Intelligent_Wms.Core.Model.Entities;
using Auto_Intelligent_Wms.Core.Model.RequestDTO.User;
using Auto_Intelligent_Wms.Core.WebApi.Controller;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Mask_STK.Controllers
{
    /// <summary>
    /// 用户
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UserController : ApiControllerBase
    {
        private readonly IUserService _iuserService;

        public UserController(IUserService service)
        {
            _iuserService = service;
        }
        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <param name="userParams"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<List<User>>> GetUserAsync([FromQuery] UserParamsDTO userParams)
        {
            var result = await _iuserService.GetUserAsync(userParams);
            return SuccessResult(result);
        }

        /// <summary>
        ///  根据用户id查询用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<User>> GetUserByIdAsync(long id)
        {
            var result = await _iuserService.GetUserByIdAsync(id);
            return SuccessResult(result);
        }

        /// <summary>
        ///  根据用户code查询用户信息
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<User>> GetUserByCodeAsync(string userCode)
        {
            var result = await _iuserService.GetUserByCodeAsync(userCode);
            return SuccessResult(result);
        }

        /// <summary>
        /// 根据ids集合获取用户数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<List<User>>> GetUserByIdsAsync(string ids)
        {
            var result = await _iuserService.GetUserByIdsAsync(ids);
            return SuccessResult(result);
        }

        /// <summary>
        /// 根据codes集合获取用户数据
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<List<User>>> GetUserByCodesAsync(string codes)
        {
            var result = await _iuserService.GetUserByCodesAsync(codes);
            return SuccessResult(result);
        }

        /// <summary>
        /// 判断用户是否存在
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<bool>> IsExistAsync(string userCode)
        {
            var result = await _iuserService.IsExistAsync(userCode);
            return SuccessResult(result);
        }

        /// <summary>
        /// 分页查询用户信息
        /// </summary>
        /// <param name="userParams"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResult<BasePagination<User>>> GetUserPaginationAsync([FromQuery] UserParamsDTO userParams)
        {
            var result = await _iuserService.GetUserPaginationAsync(userParams);
            return SuccessResult(result);
        }

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="createOrUpdateUserDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiResult<long>> CreateUserAsync([FromBody] CreateOrUpdateUserDTO createOrUpdateUserDTO)
        {
            var currentUserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var result = await _iuserService.CreateUserAsync(createOrUpdateUserDTO, currentUserId);
            return SuccessResult(result);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ApiResult<long>> DelUserAsync(long id)
        {
            var currentUserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var result = await _iuserService.DelUserAsync(id, currentUserId);
            return SuccessResult(result);
        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="createOrUpdateUserDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async  Task<ApiResult<string>> UpdateUserAsync([FromBody] CreateOrUpdateUserDTO createOrUpdateUserDTO)
        {
            var currentUserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var result = await _iuserService.UpdateUserAsync(createOrUpdateUserDTO, currentUserId);
            return SuccessResult(result);
        }

        /// <summary>
        /// 用户登陆
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiResult<string>> LoginAsync(string userCode, string password)
        {
            var result = await _iuserService.LoginAsync(userCode, password);
            return SuccessResult(result);
        }

        /// <summary>
        /// 重置用户密码
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="password"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiResult<string>> ReSetPasswordAsync(string userCode, string password, string newPassword)
        {
            var currentUserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var result = await _iuserService.ReSetPasswordAsync(userCode,password,newPassword, currentUserId);
            return SuccessResult(result);
        }

        /// <summary>
        /// 获取jwt
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async  Task<ApiResult<string>> GetJwtDataAsync(string userCode)
        {
            var result = await _iuserService.GetJwtDataAsync(userCode);
            return SuccessResult(result);
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="userParams"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> ExportAsync([FromQuery] UserParamsDTO userParams)
        {
            return await _iuserService.ExportAsync(userParams);
        }

        /// <summary>
        /// 下载用户模板
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public  async Task<ActionResult<string>> DownloadTemplateAsync()
        {
            return await _iuserService.DownloadTemplateAsync();
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiResult<string>> ImportAsync(string path)
        {
            var currentUserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var result = await _iuserService.ImportAsync(path, currentUserId);
            return SuccessResult(result);
        }
    }
}

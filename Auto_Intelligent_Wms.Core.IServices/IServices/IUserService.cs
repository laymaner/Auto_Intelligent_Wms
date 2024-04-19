using Auto_Intelligent_Wms.Core.Model.BaseModel;
using Auto_Intelligent_Wms.Core.Model.Entities;
using Auto_Intelligent_Wms.Core.Model.RequestDTO.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Intelligent_Wms.Core.IServices.IServices
{
    public interface IUserService
    {
        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <param name="userParams"></param>
        /// <returns></returns>
        public Task<List<User>> GetUserAsync([FromQuery] UserParamsDTO userParams);

        /// <summary>
        ///  根据用户id查询用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<User> GetUserByIdAsync(long id);

        /// <summary>
        ///  根据用户id查询用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<User> GetUserByCodeAsync(string userCode);

        /// <summary>
        /// 判断用户是否存在
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public Task<bool> IsExistAsync(string userCode);

        /// <summary>
        /// 分页查询用户信息
        /// </summary>
        /// <param name="userParams"></param>
        /// <returns></returns>
        public Task<BasePagination<User>> GetUserPaginationAsync([FromQuery] UserParamsDTO userParams);

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="createOrUpdateUserDTO"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        public Task<long> CreateUserAsync([FromBody] CreateOrUpdateUserDTO createOrUpdateUserDTO, string currentUserId);

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        public Task<long> DelUserAsync(long id, string currentUserId);

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="createOrUpdateUserDTO"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        public Task<string> UpdateUserAsync([FromBody] CreateOrUpdateUserDTO createOrUpdateUserDTO, string currentUserId);

        /// <summary>
        /// 用户登陆
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Task<string> LoginAsync(string userCode, string password);

        /// <summary>
        /// 重置用户密码
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="password"></param>
        /// <param name="newPassword"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        public Task<string> ReSetPasswordAsync(string userCode, string password, string newPassword, string currentUserId);

        /// <summary>
        /// 获取jwt
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public Task<string> GetJwtDataAsync(string userCode);

        /// <summary>
        /// 下载Excel模板
        /// </summary>
        /// <returns></returns>
        public Task<ActionResult<string>> DownloadTemplateAsync();

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="userParams"></param>
        /// <returns></returns>
        public Task<ActionResult<string>> ExportAsync([FromQuery] UserParamsDTO userParams);

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="path"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        public Task<string> ImportAsync(string path, string currentUserId);

        /// <summary>
        /// 根据ids集合获取用户数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public Task<List<User>> GetUserByIdsAsync(string ids);

        /// <summary>
        /// 根据codes集合获取用户数据
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        public Task<List<User>> GetUserByCodesAsync(string codes);


    }
}

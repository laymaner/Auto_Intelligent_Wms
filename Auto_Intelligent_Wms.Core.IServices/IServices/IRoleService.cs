using Auto_Intelligent_Wms.Core.Model.BaseModel;
using Auto_Intelligent_Wms.Core.Model.Entities;
using Auto_Intelligent_Wms.Core.Model.RequestDTO.Role;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Intelligent_Wms.Core.IServices.IServices
{
    public interface IRoleService
    {
        /// <summary>
        /// 查询角色信息
        /// </summary>
        /// <param name="roleParamsDto"></param>
        /// <returns></returns>
        public Task<List<Role>> GetRolesAsync([FromQuery] RoleParamsDto roleParamsDto);

        /// <summary>
        /// 根据id获取角色信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Role> GetRoleInfoByIdAsync(long id);

        /// <summary>
        /// 根据编码获取角色信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Task<Role> GetRoleInfoByCodeAsync(string code);

        /// <summary>
        /// 判断角色是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Task<bool> IsExistAsync(string code);

        /// <summary>
        /// 分页查询角色信息
        /// </summary>
        /// <param name="roleParamsDto"></param>
        /// <returns></returns>
        public Task<BasePagination<Role>> GetRolePaginationAsync([FromQuery] RoleParamsDto roleParamsDto);

        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="createOrUpdateRoleDTO"></param>
        /// <returns></returns>
        public Task<long> CreateRoleAsync([FromBody] CreateOrUpdateRoleDTO createOrUpdateRoleDTO, long currentUserId);

        /// <summary>
        /// 更新角色信息
        /// </summary>
        /// <param name="createOrUpdateRoleDTO"></param>
        /// <returns></returns>
        public Task<string> UpdateRoleAsync([FromBody] CreateOrUpdateRoleDTO createOrUpdateRoleDTO, long currentUserId);

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<long> DelRoleAsync(long id, long currentUserId);

        /// <summary>
        /// 下载Excel模板
        /// </summary>
        /// <returns></returns>
        public Task<ActionResult<string>> DownloadTemplateAsync();

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="roleParamsDto"></param>
        /// <returns></returns>
        public Task<ActionResult<string>> ExportAsync([FromQuery] RoleParamsDto roleParamsDto);

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="path"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        public Task<string> ImportAsync(string path, long currentUserId);

        /// <summary>
        /// 根据ids集合获取角色数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public Task<List<Role>> GetRoleByIdsAsync(string ids);

        /// <summary>
        /// 根据codes集合获取角色数据
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        public Task<List<Role>> GetRoleByCodesAsync(string codes);
    }
}

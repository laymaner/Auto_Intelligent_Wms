using Auto_Intelligent_Wms.Core.Common.Enum;
using Auto_Intelligent_Wms.Core.Common.Utils;
using Auto_Intelligent_Wms.Core.Extensions.Attri;
using Auto_Intelligent_Wms.Core.IServices.IServices;
using Auto_Intelligent_Wms.Core.Model.BaseModel;
using Auto_Intelligent_Wms.Core.Model.Entities;
using Auto_Intelligent_Wms.Core.Model.ImExportTemplate.Role;
using Auto_Intelligent_Wms.Core.Model.RequestDTO.Role;
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
    public class RoleService : IRoleService
    {
        private readonly Auto_Inteligent_Wms_DbContext _db;
        private readonly ILogger<RoleService> _log;

        public RoleService(Auto_Inteligent_Wms_DbContext dbContext, ILogger<RoleService> logger)
        {
            _db = dbContext;
            _log = logger;
        }
        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="createOrUpdateRoleDTO"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        public async Task<long> CreateRoleAsync([FromBody] CreateOrUpdateRoleDTO createOrUpdateRoleDTO, long currentUserId)
        {
            Role role = new Role();
            if (!string.IsNullOrWhiteSpace(createOrUpdateRoleDTO.Code))
            {
                if (await IsExistAsync(createOrUpdateRoleDTO.Code))
                {
                    throw new Exception($"Role code {createOrUpdateRoleDTO.Code} already exists, duplicate creation is not allowed");
                }
                role.Code = createOrUpdateRoleDTO.Code;
            }
            else
            {
                throw new Exception("Role code cannot be empty");
            }
            if (string.IsNullOrWhiteSpace(createOrUpdateRoleDTO.Name))
            {
                throw new Exception("Role name cannot be empty");
            }
            role.Name = createOrUpdateRoleDTO.Name;
            role.Description = createOrUpdateRoleDTO.Description;
            role.Remark = createOrUpdateRoleDTO.Remark;
            role.Status = (int)DataStatus.Normal;
            role.Creator = currentUserId;
            role.CreateTime = DateTime.Now;
            var result = await _db.Roles.AddAsync(role);
            await _db.SaveChangesAsync();
            return result.Entity.Id;
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        [Transation]
        public async Task<long> DelRoleAsync(long id, long currentUserId)
        {
            if (id <= 0)
            {
                throw new Exception("Role ID does not exist");
            }
            var role = await _db.Roles.Where(m => m.Id == id && m.Status == (int)DataStatus.Normal).SingleOrDefaultAsync();
            if (role == null)
            {
                throw new Exception($"No information found for role,roleId is {id}");
            }

            var items = await _db.User_Role_RelationShips.Where(m => m.RoleId == role.Id && m.Status == (int)DataStatus.Normal).ToListAsync();
            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    item.Status = (int)DataStatus.Delete;
                    item.UpdateTime = DateTime.Now;
                    item.Updator = currentUserId;
                }
            }
            role.Status = (int)DataStatus.Delete;
            role.UpdateTime = DateTime.Now;
            role.Updator = currentUserId;
            return await _db.SaveChangesAsync();

        }

        /// <summary>
        /// 下载角色模板
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ActionResult<string>> DownloadTemplateAsync()
        {
            List<RoleDownloadTemplate> list = new List<RoleDownloadTemplate>();
            return await MiniExcelUtil.ExportAsync("下载角色模板", list);
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="roleParamsDto"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ActionResult<string>> ExportAsync([FromQuery] RoleParamsDto roleParamsDto)
        {

            var result = _db.Roles.Where(m => m.Status == (int)DataStatus.Normal).AsNoTracking().Select(m => new RoleExportTemplate
            {
                Id = m.Id,
                Name = m.Name,
                Code = m.Code,
                Remark = m.Remark,
                Description = m.Description,
                CreateTime = m.CreateTime,
            });
            if (!String.IsNullOrWhiteSpace(roleParamsDto.Name))
            {
                result = result.Where(m => m.Name.StartsWith(roleParamsDto.Name));
            }
            if (!String.IsNullOrWhiteSpace(roleParamsDto.Code))
            {
                result = result.Where(m => m.Name.StartsWith(roleParamsDto.Code));
            }

            return await MiniExcelUtil.ExportAsync("角色信息", result);
        }

        /// <summary>
        /// 根据编码获取角色信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<Role> GetRoleInfoByCodeAsync(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new Exception("Query parameter code is empty");
            }
            var role = await _db.Roles.Where(m => m.Code.Equals(code) && m.Status == (int)DataStatus.Normal).SingleOrDefaultAsync();
            if (role == null) 
            {
                throw new Exception($"No information found for Role,code is {code}");
            }
            return role;
        }

        /// <summary>
        /// 根据id获取角色信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Role> GetRoleInfoByIdAsync(long id)
        {
            if (id <= 0)
            {
                throw new Exception("Query parameter RoleId is empty");
            }
            var role = await _db.Roles.Where(m => m.Id == id && m.Status == (int)DataStatus.Normal).SingleOrDefaultAsync();
            if (role == null)
            {
                throw new Exception($"No information found for Role,id is {id}");
            }
            return role;
        }

        /// <summary>
        /// 查询角色信息
        /// </summary>
        /// <param name="roleParamsDto"></param>
        /// <returns></returns>
        public async Task<List<Role>> GetRolesAsync([FromQuery] RoleParamsDto roleParamsDto)
        {
            var result = _db.Roles.Where(m => m.Status == (int)DataStatus.Normal).AsNoTracking();
            if (!String.IsNullOrWhiteSpace(roleParamsDto.Name))
            {
                result = result.Where(m => m.Name.StartsWith(roleParamsDto.Name));
            }
            if (!String.IsNullOrWhiteSpace(roleParamsDto.Code))
            {
                result = result.Where(m => m.Name.StartsWith(roleParamsDto.Code));
            }
            return await result.ToListAsync();
        }

        /// <summary>
        /// 分页查询角色信息
        /// </summary>
        /// <param name="roleParamsDto"></param>
        /// <returns></returns>
        public async Task<BasePagination<Role>> GetRolePaginationAsync([FromQuery] RoleParamsDto roleParamsDto)
        {
            var result = _db.Roles.Where(m => m.Status == (int)DataStatus.Normal).AsNoTracking();
            if (!String.IsNullOrWhiteSpace(roleParamsDto.Name))
            {
                result = result.Where(m => m.Name.StartsWith(roleParamsDto.Name));
            }
            if (!String.IsNullOrWhiteSpace(roleParamsDto.Code))
            {
                result = result.Where(m => m.Name.StartsWith(roleParamsDto.Code));
            }
            return await PaginationService.PaginateAsync(result, roleParamsDto.PageIndex, roleParamsDto.PageSize);
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="path"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [Transation]
        public async Task<string> ImportAsync(string path, long currentUserId)
        {
            var result = MiniExcelUtil.Import<RoleDownloadTemplate>(path).ToList();
            if (result == null || result.Count <= 0)
            {
                throw new Exception("Import data is empty");
            }
            //判断角色编码有没有空值
            if (result.Any(m => string.IsNullOrWhiteSpace(m.Code)))
            {
                throw new Exception("There is a null value in the imported role code");
            }
            //判断角色姓名有没有空值
            if (result.Any(m => string.IsNullOrWhiteSpace(m.Name)))
            {
                throw new Exception("There is a null value in the imported role name");
            }
            //判断角色编码是否有重复
            if (result.GroupBy(m => m.Code).Any(group => group.Count() > 1))
            {
                throw new Exception("Role code duplication");
            }

            var codeList = result.Select(m => m.Code).ToList();
            var items = await _db.Roles.Where(m => codeList.Contains(m.Code) && m.Status == (int)DataStatus.Normal).ToListAsync();
            if (items != null && items.Count > 0)
            {
                throw new Exception("Role code already exists");
            }

            var data = result.Select(m => new Role
            {
                Name = m.Name,
                Code = m.Code,
                Description = m.Description,
                Status = (int)DataStatus.Normal,
                Creator = currentUserId,
                Remark = m.Remark,
                CreateTime = DateTime.Now,
            });
            await _db.BulkInsertAsync(data);
            await _db.SaveChangesAsync();
            return "Import Roles successful";
        }

        /// <summary>
        /// 判断角色是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<bool> IsExistAsync(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new Exception("Query parameter code is empty");
            }
            var role = await _db.Roles.Where(m => m.Code.Equals(code) && m.Status == (int)DataStatus.Normal).SingleOrDefaultAsync();
            if (role != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 更新角色信息
        /// </summary>
        /// <param name="createOrUpdateRoleDTO"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        [Transation]
        public async Task<string> UpdateRoleAsync([FromBody] CreateOrUpdateRoleDTO createOrUpdateRoleDTO, long currentUserId)
        {
            if (createOrUpdateRoleDTO.Id <= 0)
            {
                throw new Exception("Role ID does not exist");
            }
            var role = await _db.Roles.Where(m => m.Id == createOrUpdateRoleDTO.Id).SingleOrDefaultAsync();
            if (role == null)
            {
                throw new Exception($"No information found for role,roleId is {createOrUpdateRoleDTO.Id}");
            }
            if (role.Status != (int)DataStatus.Normal)
            {
                throw new Exception("Abnormal role status");
            }
            if (!string.IsNullOrWhiteSpace(createOrUpdateRoleDTO.Code))
            {
                if (await IsExistAsync(createOrUpdateRoleDTO.Code))
                {
                    throw new Exception($"Role code {createOrUpdateRoleDTO.Code} already exists, duplicate creation is not allowed");
                }

                var items = await _db.User_Role_RelationShips.Where(m => m.RoleId == role.Id && m.Status == (int)DataStatus.Normal).ToListAsync();
                if (items != null && items.Count > 0)
                {
                    foreach (var item in items)
                    {
                        item.RoleCode = createOrUpdateRoleDTO.Code;
                        item.RoleName = string.IsNullOrWhiteSpace(createOrUpdateRoleDTO.Name) ? role.Name : createOrUpdateRoleDTO.Name;
                        item.Updator = currentUserId;
                    }
                }
                role.Code = createOrUpdateRoleDTO.Code;
            }

            //基础信息更新
            role.Name = string.IsNullOrWhiteSpace(createOrUpdateRoleDTO.Name) ? role.Name : createOrUpdateRoleDTO.Name;
            role.Description = string.IsNullOrWhiteSpace(createOrUpdateRoleDTO.Description) ? role.Description : createOrUpdateRoleDTO.Description;
            role.Remark = string.IsNullOrWhiteSpace(createOrUpdateRoleDTO.Remark) ? role.Remark : createOrUpdateRoleDTO.Remark;
            role.Updator = currentUserId;
            role.UpdateTime = DateTime.Now;
            await _db.SaveChangesAsync();
            return "Successfully updated role information";
        }

        /// <summary>
        /// 根据codes集合获取角色数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public async Task<List<Role>> GetRoleByIdsAsync(string ids)
        {
            var list = new List<Role>();
            if (!string.IsNullOrWhiteSpace(ids))
            {
                var items = ids.Split(',').ToList();
                List<long> idList = items.Select(s => long.Parse(s)).ToList();
                list = await _db.Roles.Where(m => idList.Contains(m.Id) && m.Status == (int)DataStatus.Normal).ToListAsync();
            }
            return list;
        }

        /// <summary>
        /// 根据codes集合获取角色数据
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        public async Task<List<Role>> GetRoleByCodesAsync(string codes)
        {
            var list = new List<Role>();
            if (!string.IsNullOrWhiteSpace(codes))
            {
                var codeList = codes.Split(',').ToList();
                list = await _db.Roles.Where(m => codeList.Contains(m.Code) && m.Status == (int)DataStatus.Normal).ToListAsync();
            }
            return list;
        }
    }
}

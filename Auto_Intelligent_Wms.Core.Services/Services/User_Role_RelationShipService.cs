using Auto_Intelligent_Wms.Core.Common.Enum;
using Auto_Intelligent_Wms.Core.Extensions.Attri;
using Auto_Intelligent_Wms.Core.IServices.IServices;
using Auto_Intelligent_Wms.Core.Model.BaseModel;
using Auto_Intelligent_Wms.Core.Model.Entities;
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
    public class User_Role_RelationShipService : IUser_Role_RelationShipService
    {
        private readonly Auto_Inteligent_Wms_DbContext _db;
        private readonly ILogger<User_Role_RelationShipService> _log;

        public User_Role_RelationShipService(Auto_Inteligent_Wms_DbContext dbContext, ILogger<User_Role_RelationShipService> logger)
        {
            _db = dbContext;
            _log = logger;
        }
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        public async Task<long> CreateAsync(long userId, long roleId, long currentUserId)
        {
            var user = await _db.Users.Where(m => m.Id == userId && m.Status == (int)DataStatus.Normal).SingleOrDefaultAsync();
            if (user == null)
            {
                throw new Exception($"No information found for user,userId is {userId}");
            }
            var role = await _db.Roles.Where(m => m.Id == roleId && m.Status == (int)DataStatus.Normal).SingleOrDefaultAsync();
            if (role == null)
            {
                throw new Exception($"No information found for role,roleId is {roleId}");
            }
            var result = await _db.User_Role_RelationShips.Where(m => m.UserId == userId && m.RoleId == roleId && m.Status == (int)DataStatus.Normal).ToListAsync();
            if (result != null && result.Count > 0)
            {
                throw new Exception("The user role relationship already exists");
            }
            User_Role_RelationShip ship = new User_Role_RelationShip();
            ship.UserId = userId;
            ship.UserCode = user.Code;
            ship.UserName = user.Name;
            ship.RoleId = roleId;
            ship.RoleCode = role.Code;
            ship.RoleName = user.Name;
            ship.Status = (int)DataStatus.Normal;
            ship.CreateTime = DateTime.Now;
            ship.Creator = currentUserId;
            var entity = await _db.User_Role_RelationShips.AddAsync(ship);
            await _db.SaveChangesAsync();
            return entity.Entity.Id;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        [Transation]
        public async Task<long> DelAsync(long id, long currentUserId)
        {
            if (id <= 0)
            {
                throw new Exception("User_Role_RelationShips ID does not exist");
            }
            var item = await _db.User_Role_RelationShips.Where(m => m.Id == id && m.Status == (int)DataStatus.Normal).SingleOrDefaultAsync();
            if (item == null)
            {
                throw new Exception($"No information found for User_Role_RelationShips,Id is {id}");
            }
            item.Status = (int)DataStatus.Delete;
            item.UpdateTime = DateTime.Now;
            item.Updator = currentUserId;
            return await _db.SaveChangesAsync();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="userRoleRelationShipParamsDTO"></param>
        /// <returns></returns>
        public async Task<List<User_Role_RelationShip>> GetListAsync([FromQuery] UserRoleRelationShipParamsDTO userRoleRelationShipParamsDTO)
        {
            var result = _db.User_Role_RelationShips.Where(m => m.Status == (int)DataStatus.Normal).AsNoTracking();
            if (!String.IsNullOrWhiteSpace(userRoleRelationShipParamsDTO.UserName))
            {
                result = result.Where(m => m.UserName.StartsWith(userRoleRelationShipParamsDTO.UserName));
            }
            if (!String.IsNullOrWhiteSpace(userRoleRelationShipParamsDTO.UserCode))
            {
                result = result.Where(m => m.UserCode.StartsWith(userRoleRelationShipParamsDTO.UserCode));
            }
            if (!String.IsNullOrWhiteSpace(userRoleRelationShipParamsDTO.RoleName))
            {
                result = result.Where(m => m.RoleName.StartsWith(userRoleRelationShipParamsDTO.RoleName));
            }
            if (!String.IsNullOrWhiteSpace(userRoleRelationShipParamsDTO.RoleCode))
            {
                result = result.Where(m => m.RoleCode.StartsWith(userRoleRelationShipParamsDTO.RoleCode));
            }
            return await result.ToListAsync();
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="userRoleRelationShipParamsDTO"></param>
        /// <returns></returns>
        public async Task<BasePagination<User_Role_RelationShip>> GetPaginationAsync([FromQuery] UserRoleRelationShipParamsDTO userRoleRelationShipParamsDTO)
        {
            var result = _db.User_Role_RelationShips.Where(m => m.Status == (int)DataStatus.Normal).AsNoTracking();
            if (!String.IsNullOrWhiteSpace(userRoleRelationShipParamsDTO.UserName))
            {
                result = result.Where(m => m.UserName.StartsWith(userRoleRelationShipParamsDTO.UserName));
            }
            if (!String.IsNullOrWhiteSpace(userRoleRelationShipParamsDTO.UserCode))
            {
                result = result.Where(m => m.UserCode.StartsWith(userRoleRelationShipParamsDTO.UserCode));
            }
            if (!String.IsNullOrWhiteSpace(userRoleRelationShipParamsDTO.RoleName))
            {
                result = result.Where(m => m.RoleName.StartsWith(userRoleRelationShipParamsDTO.RoleName));
            }
            if (!String.IsNullOrWhiteSpace(userRoleRelationShipParamsDTO.RoleCode))
            {
                result = result.Where(m => m.RoleCode.StartsWith(userRoleRelationShipParamsDTO.RoleCode));
            }
            return await PaginationService.PaginateAsync(result, userRoleRelationShipParamsDTO.PageIndex, userRoleRelationShipParamsDTO.PageSize);
        }
    }
}

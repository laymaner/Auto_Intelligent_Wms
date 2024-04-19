using Auto_Intelligent_Wms.Core.Model.BaseModel;
using Auto_Intelligent_Wms.Core.Model.Entities;
using Auto_Intelligent_Wms.Core.Model.RequestDTO.User_Role_RelationShip;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Intelligent_Wms.Core.IServices.IServices
{
    public interface IUser_Role_RelationShipService
    {
        /// <summary>
        /// 创建用户角色关系
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        public Task<long> CreateAsync(long userId, long roleId, long currentUserId);

        /// <summary>
        /// 查询用户角色关系
        /// </summary>
        /// <param name="userRoleRelationShipParamsDTO"></param>
        /// <returns></returns>
        public Task<List<User_Role_RelationShip>> GetListAsync([FromQuery] UserRoleRelationShipParamsDTO userRoleRelationShipParamsDTO);

        /// <summary>
        /// 分页查询用户角色关系
        /// </summary>
        /// <param name="userRoleRelationShipParamsDTO"></param>
        /// <returns></returns>
        public Task<BasePagination<User_Role_RelationShip>> GetPaginationAsync([FromQuery] UserRoleRelationShipParamsDTO userRoleRelationShipParamsDTO);

        /// <summary>
        /// 删除用户角色关系
        /// </summary>
        /// <param name="id"></param>
        /// <param name="currentUserId"></param>
        /// <returns></returns>
        public Task<long> DelAsync(long id, long currentUserId);



    }
}

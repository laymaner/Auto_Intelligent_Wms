using Auto_Intelligent_Wms.Core.Model.BaseModel;

namespace Auto_Intelligent_Wms.Core.Model.RequestDTO.User_Role_RelationShip
{
    /// <summary>
    /// 查询角色用户关系参数实体
    /// </summary>
    public class UserRoleRelationShipParamsDTO : BasicQuery
    {
        /// <summary>
        /// 用户编码
        /// </summary>
        public string? UserCode { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string? UserName { get; set; }
        /// <summary>
        /// 角色编码
        /// </summary>
        public string? RoleCode { get; set; }

        /// <summary>
        /// 角色姓名
        /// </summary>
        public string? RoleName { get; set; }
    }
}

using Auto_Intelligent_Wms.Core.Model.BaseModel;

namespace Auto_Intelligent_Wms.Core.Model.RequestDTO.Role
{
    /// <summary>
    /// 查询角色参数实体
    /// </summary>
    public class RoleParamsDto : BasicQuery
    {
        /// <summary>
        /// 角色编码
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// 角色姓名
        /// </summary>
        public string? Name { get; set; }
    }
}

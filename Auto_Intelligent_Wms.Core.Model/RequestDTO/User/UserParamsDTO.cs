using Auto_Intelligent_Wms.Core.Model.BaseModel;

namespace Auto_Intelligent_Wms.Core.Model.RequestDTO.User
{
    /// <summary>
    /// 查询用户参数实体
    /// </summary>
    public class UserParamsDTO : BasicQuery
    {
        /// <summary>
        /// 用户编码
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string? Name { get; set; }

    }
}

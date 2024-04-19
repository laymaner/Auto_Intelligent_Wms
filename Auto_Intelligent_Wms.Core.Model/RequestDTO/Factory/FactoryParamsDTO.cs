using Auto_Intelligent_Wms.Core.Model.BaseModel;

namespace Auto_Intelligent_Wms.Core.Model.RequestDTO.Factory
{
    /// <summary>
    /// 查询工厂参数实体
    /// </summary>
    public class FactoryParamsDTO : BasicQuery
    {
        /// <summary>
        /// 工厂编码
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// 工厂名称
        /// </summary>
        public string? Name { get; set; }
    }
}

using Auto_Intelligent_Wms.Core.Model.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Intelligent_Wms.Core.Model.RequestDTO.Material
{
    /// <summary>
    /// 查询物料信息参数实体
    /// </summary>
    public class MaterialParamsDTO :BasicQuery
    {
        /// <summary>
        /// 物料编码
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// 物料名称
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 物料类型
        /// </summary>
        public string? Type { get; set; }
    }
}

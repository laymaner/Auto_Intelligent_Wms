using Auto_Intelligent_Wms.Core.Model.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Intelligent_Wms.Core.Model.RequestDTO.Area
{
    /// <summary>
    /// 查询库区参数实体
    /// </summary>
    public class AreaParamsDTO :BasicQuery
    {
        /// <summary>
        /// 库区编码
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// 库区名称
        /// </summary>
        public string? Name { get; set; }
    }
}

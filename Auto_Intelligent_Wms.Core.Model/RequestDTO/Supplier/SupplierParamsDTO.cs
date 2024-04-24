using Auto_Intelligent_Wms.Core.Model.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Intelligent_Wms.Core.Model.RequestDTO.Supplier
{
    /// <summary>
    /// 查询供应商实体参数
    /// </summary>
    public class SupplierParamsDTO:BasicQuery
    {
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 供应商编码
        /// </summary>
        public string? Code { get; set; }
    }
}

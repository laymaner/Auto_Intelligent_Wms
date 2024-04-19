using Auto_Intelligent_Wms.Core.Model.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Intelligent_Wms.Core.Model.RequestDTO.Shelf
{
    /// <summary>
    /// 查询货架参数实体
    /// </summary>
    public class ShelfParamsDTO : BasicQuery
    {
        /// <summary>
        /// 货架编码
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// 货架名称
        /// </summary>
        public string? Name { get; set; }
    }
}

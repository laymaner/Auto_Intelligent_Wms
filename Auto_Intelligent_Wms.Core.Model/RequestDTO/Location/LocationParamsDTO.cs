using Auto_Intelligent_Wms.Core.Model.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Intelligent_Wms.Core.Model.RequestDTO.Location
{
    /// <summary>
    /// 查询货位参数实体
    /// </summary>
    public class LocationParamsDTO : BasicQuery
    {
        /// <summary>
        /// 货位编码
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// 货位名称
        /// </summary>
        public string? Name { get; set; }
    }

}

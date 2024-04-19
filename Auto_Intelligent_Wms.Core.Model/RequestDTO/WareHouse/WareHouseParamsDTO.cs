using Auto_Intelligent_Wms.Core.Model.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Intelligent_Wms.Core.Model.RequestDTO.WareHouse
{
    /// <summary>
    /// 查询仓库参数实体
    /// </summary>
    public class WareHouseParamsDTO : BasicQuery
    {
        /// <summary>
        /// 仓库编码
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// 仓库名称
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 仓库类型
        /// </summary>
        public string? WareHouseType { get; set; }
    }
}

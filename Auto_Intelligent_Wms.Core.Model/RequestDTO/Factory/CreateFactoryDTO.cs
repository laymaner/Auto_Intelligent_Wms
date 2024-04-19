using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Intelligent_Wms.Core.Model.RequestDTO.Factory
{
    /// <summary>
    /// 创建或者更新工厂
    /// </summary>
    public class CreateFactoryDTO
    {
        /// <summary>
        /// 工厂名称
        /// </summary>
        public string? Name { get; set; }
        
        /// <summary>
        /// 工厂编号
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string? Remark { get; set; }

    }
}

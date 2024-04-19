using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Intelligent_Wms.Core.Model.RequestDTO.Shelf
{
    /// <summary>
    /// 创建货架实体参数
    /// </summary>
    public class CreateShelfDTO
    {
        /// <summary>
        /// 货架名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 货架编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 库位编码
        /// </summary>
        public string LocationCode { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string? Remark { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Intelligent_Wms.Core.Model.RequestDTO.Location
{
    /// <summary>
    /// 创建库位实体参数
    /// </summary>
    public class CreateLocationDTO
    {
        /// <summary>
        /// 库位名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 库位编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 库区编码
        /// </summary>
        public string AreaCode { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string? Remark { get; set; }
    }
}

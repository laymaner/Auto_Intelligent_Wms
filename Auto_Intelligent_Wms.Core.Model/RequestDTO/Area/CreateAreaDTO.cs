using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Intelligent_Wms.Core.Model.RequestDTO.Area
{
    /// <summary>
    /// 创建库区实体参数
    /// </summary>
    public class CreateAreaDTO
    {
        /// <summary>
        /// 库区名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 库区编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 仓库编码
        /// </summary>
        public string WareHouseCode { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string? Remark { get; set; }
    }
}

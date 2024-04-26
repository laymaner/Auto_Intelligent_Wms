using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "库区名称不能为空")]
        public string Name { get; set; }

        /// <summary>
        /// 库区编码
        /// </summary>
        [Required(ErrorMessage = "库区编码不能为空")]
        public string Code { get; set; }

        /// <summary>
        /// 仓库编码
        /// </summary>
        [Required(ErrorMessage = "仓库编码不能为空")]
        public string WareHouseCode { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string? Remark { get; set; }
    }
}

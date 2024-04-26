using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Intelligent_Wms.Core.Model.RequestDTO.WareHouse
{
    /// <summary>
    /// 创建仓库实体参数
    /// </summary>
    public class CreateWareHouseDTO
    {
        /// <summary>
        /// 仓库名称
        /// </summary>
        [Required(ErrorMessage = "仓库名称不能为空")]
        public string Name { get; set; }

        /// <summary>
        /// 仓库编码
        /// </summary>
        [Required(ErrorMessage = "仓库编码不能为空")]
        public string Code { get; set; }

        /// <summary>
        /// 仓库类型
        /// </summary>
        [Required(ErrorMessage = "仓库类型不能为空")]
        public string Type { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string? Remark { get; set; }
    }
}

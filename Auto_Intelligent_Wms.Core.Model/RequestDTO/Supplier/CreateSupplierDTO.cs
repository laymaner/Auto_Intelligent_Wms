using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Intelligent_Wms.Core.Model.RequestDTO.Supplier
{
    /// <summary>
    /// 创建供应商实体参数信息
    /// </summary>
    public class CreateSupplierDTO
    {
        /// <summary>
        /// 供应商名称
        /// </summary>
        [Required(ErrorMessage = "供应商名称不能为空")]
        public string Name { get; set; }

        /// <summary>
        /// 供应商编码
        /// </summary>
        [Required(ErrorMessage = "供应商编码不能为空")]
        public string Code { get; set; }

        /// <summary>
        /// 供应商地址
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string? Telephone { get; set; }

        /// <summary>
        /// 电子邮件
        /// </summary>
        public string? Email { get; set; }


        /// <summary>
        /// 备注
        /// </summary>
        public string? Remark { get; set; }
    }
}

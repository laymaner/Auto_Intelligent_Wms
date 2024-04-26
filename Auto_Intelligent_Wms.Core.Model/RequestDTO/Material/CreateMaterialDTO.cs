using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Intelligent_Wms.Core.Model.RequestDTO.Material
{
    /// <summary>
    /// 创建物料信息实体参数
    /// </summary>
    public class CreateMaterialDTO
    {
        /// <summary>
        /// 物料名称
        /// </summary>
        [Required(ErrorMessage = "物料名称不能为空")]
        public string Name { get; set; }

        /// <summary>
        /// 物料编码
        /// </summary>
        [Required(ErrorMessage = "物料编码不能为空")]
        public string Code { get; set; }

        /// <summary>
        /// 物料描述
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// 物料类型
        /// </summary>
        [Required(ErrorMessage = "物料类型不能为空")]
        public string Type { get; set; }

        /// <summary>
        /// 基本计量单位
        /// </summary>
        [Required(ErrorMessage = "基本计量单位不能为空")]
        public string Unit { get; set; }

        /// <summary>
        /// 基本计量单位数量
        /// </summary>
        [Required(ErrorMessage = "基本计量单位数量不能为空")]
        public decimal Quantity { get; set; }

        /// <summary>
        /// 最小包装数量
        /// </summary>
        [Required(ErrorMessage = "最小包装数量不能为空")]
        public decimal MinimumPackagingQuantity { get; set; }

        /// <summary>
        /// 价格单位
        /// </summary>
        [Required(ErrorMessage = "价格单位不能为空")]
        public string PriceUint { get; set; }

        /// <summary>
        /// 每个/价格
        /// </summary>
        [Required(ErrorMessage = "价格不能为空")]
        public decimal Price { get; set; }

        /// <summary>
        /// 有效期
        /// </summary>
        [Required(ErrorMessage = "有效期不能为空")]
        public DateTime ValidityPeriod { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string? Remark { get; set; }

        /// <summary>
        /// 物料等级
        /// </summary>
        public string? Version { get; set; }


    }
}

using MiniExcelLibs.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Intelligent_Wms.Core.Model.ImExportTemplate.Material
{
    /// <summary>
    /// 物料信息导出模板
    /// </summary>
    public class MaterialExportTemplate
    {
        /// <summary>
        /// 主键id
        /// </summary>
        [ExcelColumn(Name = "ID", Index = 0, Width = 12)]
        public long Id { get; set; }
        /// <summary>
        /// 物料名称
        /// </summary>
        [ExcelColumn(Name = "物料名称", Index = 1, Width = 12)]
        public string Name { get; set; }

        /// <summary>
        /// 物料编码
        /// </summary>
        [ExcelColumn(Name = "物料编码", Index = 2, Width = 12)]
        public string Code { get; set; }

        /// <summary>
        /// 物料描述
        /// </summary>
        [ExcelColumn(Name = "物料描述", Index = 3, Width = 50)]
        public string? Description { get; set; }

        /// <summary>
        /// 物料类型
        /// </summary>
        [ExcelColumn(Name = "物料类型", Index =4, Width = 12)]
        public string Type { get; set; }

        /// <summary>
        /// 基本计量单位
        /// </summary>
        [ExcelColumn(Name = "基本计量单位", Index = 5, Width = 12)]
        public string Unit { get; set; }

        /// <summary>
        /// 基本计量单位数量
        /// </summary>
        [ExcelColumn(Name = "基本计量单位数量", Index = 6, Width = 12)]
        public decimal Quantity { get; set; }

        /// <summary>
        /// 最小包装数量
        /// </summary>
        [ExcelColumn(Name = "最小包装数量", Index = 7, Width = 12)]
        public decimal MinimumPackagingQuantity { get; set; }

        /// <summary>
        /// 价格单位
        /// </summary>
        [ExcelColumn(Name = "价格单位", Index = 8, Width = 12)]
        public string PriceUint { get; set; }

        /// <summary>
        /// 每个/价格
        /// </summary>
        [ExcelColumn(Name = " 每个/价格", Index = 9, Width = 12)]
        public decimal Price { get; set; }

        /// <summary>
        /// 有效期
        /// </summary>
        [ExcelColumn(Name = "有效期", Index = 10, Width = 40, Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime ValidityPeriod { get; set; }

        /// <summary>
        /// 物料等级
        /// </summary>
        [ExcelColumn(Name = "物料等级", Index = 11, Width = 12)]
        public string? Version { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [ExcelColumn(Name = "备注", Index = 12, Width = 50)]
        public string? Remark { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [ExcelColumn(Name = "创建时间", Index = 13, Width = 40, Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime CreateTime { get; set; }
    }
}

using MiniExcelLibs.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Intelligent_Wms.Core.Model.ImExportTemplate.Factory
{
    /// <summary>
    /// 工厂导出模板
    /// </summary>
    public class FactoryExportTemplate
    {
        /// <summary>
        /// 主键id
        /// </summary>
        [ExcelColumn(Name = "ID", Index = 0, Width = 12)]
        public long Id { get; set; }

        /// <summary>
        /// 工厂名称
        /// </summary>
        [ExcelColumn(Name = "工厂名称", Index = 1, Width = 12)]
        public string Name { get; set; }

        /// <summary>
        /// 工厂编号
        /// </summary>
        [ExcelColumn(Name = "工厂编码", Index = 2, Width = 12)]
        public string Code { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [ExcelColumn(Name = "备注", Index = 3, Width = 40)]
        public string? Remark { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [ExcelColumn(Name = "创建时间", Index = 4, Width = 40, Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime CreateTime { get; set; }

    }
}

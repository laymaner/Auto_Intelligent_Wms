using MiniExcelLibs.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Intelligent_Wms.Core.Model.ImExportTemplate.Factory
{
    /// <summary>
    /// 工厂下载模板
    /// </summary>
    public class FactoryDownloadTemplate
    {

        /// <summary>
        /// 工厂名称
        /// </summary>
        [ExcelColumn(Name = "工厂名称", Index = 0, Width = 12)]
        public string Name { get; set; }

        /// <summary>
        /// 工厂编号
        /// </summary>
        [ExcelColumn(Name = "工厂编码", Index = 1, Width = 12)]
        public string Code { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [ExcelColumn(Name = "备注", Index = 2, Width = 40)]
        public string? Remark { get; set; }


    }
}

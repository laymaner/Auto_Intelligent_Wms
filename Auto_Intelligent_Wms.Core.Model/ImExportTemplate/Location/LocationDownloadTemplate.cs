using MiniExcelLibs.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Intelligent_Wms.Core.Model.ImExportTemplate.Location
{
    /// <summary>
    /// 下载库位模板
    /// </summary>
    public class LocationDownloadTemplate
    {
        /// <summary>
        /// 库位名称
        /// </summary>
        [ExcelColumn(Name = "库位名称", Index = 0, Width = 12)]
        public string Name { get; set; }

        /// <summary>
        /// 库位编码
        /// </summary>
        [ExcelColumn(Name = "库位编码", Index = 1, Width = 12)]
        public string Code { get; set; }

        /// <summary>
        /// 库区编码
        /// </summary>
        [ExcelColumn(Name = "库区编码", Index = 2, Width = 12)]
        public string AreaCode { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [ExcelColumn(Name = "备注", Index = 3, Width = 40)]
        public string? Remark { get; set; }


    }
}

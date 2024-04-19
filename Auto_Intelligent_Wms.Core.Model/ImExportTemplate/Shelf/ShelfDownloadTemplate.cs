using MiniExcelLibs.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Intelligent_Wms.Core.Model.ImExportTemplate.Shelf
{
    /// <summary>
    /// 下载货架模板
    /// </summary>
    public class ShelfDownloadTemplate
    {
        /// <summary>
        /// 货架名称
        /// </summary>
        [ExcelColumn(Name = "货架名称", Index = 0, Width = 12)]
        public string Name { get; set; }

        /// <summary>
        /// 货架编码
        /// </summary>
        [ExcelColumn(Name = "货架编码", Index = 1, Width = 12)]
        public string Code { get; set; }

        /// <summary>
        /// 库位编码
        /// </summary>
        [ExcelColumn(Name = "库位编码", Index = 2, Width = 12)]
        public string LocationCode { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [ExcelColumn(Name = "备注", Index = 3, Width = 40)]
        public string? Remark { get; set; }


    }
}

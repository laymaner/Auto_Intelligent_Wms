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
        /// 库区编码
        /// </summary>
        [ExcelColumn(Name = "库区编码", Index = 2, Width = 12)]
        public string AreaCode { get; set; }

        /// <summary>
        /// 巷道数量
        /// </summary>
        [ExcelColumn(Name = "巷道", Index = 3, Width = 12)]
        public int RoadWay { get; set; }

        /// <summary>
        /// 总排数
        /// </summary>
        [ExcelColumn(Name = "排", Index = 4, Width = 12)]
        public int ShelfRows { get; set; }

        /// <summary>
        /// 总列数
        /// </summary>
        [ExcelColumn(Name = "列", Index = 5, Width = 12)]
        public int ShelfColumns { get; set; }

        /// <summary>
        /// 总层数
        /// </summary>
        [ExcelColumn(Name = "层", Index = 6, Width = 12)]
        public int ShelfLayers { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [ExcelColumn(Name = "备注", Index = 7, Width = 40)]
        public string? Remark { get; set; }


    }
}

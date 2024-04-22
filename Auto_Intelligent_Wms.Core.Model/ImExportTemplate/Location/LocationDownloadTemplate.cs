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
        [ExcelColumn(Name = "货架编码", Index = 2, Width = 12)]
        public string ShelfCode { get; set; }

        /// <summary>
        /// 巷道
        /// </summary>
        [ExcelColumn(Name = "巷道", Index = 3, Width = 12)]
        public int RoadWay { get; set; }

        /// <summary>
        /// 排
        /// </summary>
        [ExcelColumn(Name = "排", Index = 4, Width = 12)]
        public int LRow { get; set; }

        /// <summary>
        /// 列
        /// </summary>
        [ExcelColumn(Name = "列", Index = 5, Width = 12)]
        public int LColumn { get; set; }

        /// <summary>
        /// 层
        /// </summary>
        [ExcelColumn(Name = "层", Index = 6, Width = 12)]
        public int Layer { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [ExcelColumn(Name = "备注", Index = 7, Width = 40)]
        public string? Remark { get; set; }


    }
}

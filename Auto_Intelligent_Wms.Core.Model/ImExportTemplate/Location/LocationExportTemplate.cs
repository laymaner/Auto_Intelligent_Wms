using MiniExcelLibs.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Intelligent_Wms.Core.Model.ImExportTemplate.Location
{
    /// <summary>
    /// 库位信息导出模板
    /// </summary>
    public class LocationExportTemplate
    {
        /// <summary>
        /// 主键id
        /// </summary>
        [ExcelColumn(Name = "ID", Index = 0, Width = 12)]
        public long Id { get; set; }

        /// <summary>
        /// 库位名称
        /// </summary>
        [ExcelColumn(Name = "库位名称", Index = 1, Width = 12)]
        public string Name { get; set; }

        /// <summary>
        /// 库位编码
        /// </summary>
        [ExcelColumn(Name = "库位编码", Index = 2, Width = 12)]
        public string Code { get; set; }

        /// <summary>
        /// 库区编码
        /// </summary>
        [ExcelColumn(Name = "库区编码", Index = 3, Width = 12)]
        public string WareHouseCode { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [ExcelColumn(Name = "备注", Index = 4, Width = 40)]
        public string? Remark { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [ExcelColumn(Name = "创建时间", Index = 5, Width = 40, Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime CreateTime { get; set; }
    }
}

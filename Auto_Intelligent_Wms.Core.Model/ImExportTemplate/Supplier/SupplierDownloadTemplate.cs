using MiniExcelLibs.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Intelligent_Wms.Core.Model.ImExportTemplate.Supplier
{
    /// <summary>
    /// 供应商信息下载模板
    /// </summary>
    public class SupplierDownloadTemplate
    {
        /// <summary>
        /// 供应商名称
        /// </summary>
        [ExcelColumn(Name = "供应商名称", Index = 0, Width = 20)]
        public string Name { get; set; }

        /// <summary>
        /// 供应商编码
        /// </summary>
        [ExcelColumn(Name = "供应商编码", Index = 1, Width = 20)]
        public string Code { get; set; }

        /// <summary>
        /// 供应商地址
        /// </summary>
        [ExcelColumn(Name = "供应商地址", Index = 2, Width = 30)]
        public string? Address { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [ExcelColumn(Name = "电话", Index = 3, Width = 20)]
        public string? Telephone { get; set; }

        /// <summary>
        /// 电子邮件
        /// </summary>
        [ExcelColumn(Name = "电子邮件", Index = 4, Width = 20)]
        public string? Email { get; set; }


        /// <summary>
        /// 备注
        /// </summary>
        [ExcelColumn(Name = "备注", Index = 5, Width = 50)]
        public string? Remark { get; set; }
    }
}

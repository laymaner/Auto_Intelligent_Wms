﻿using MiniExcelLibs.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Intelligent_Wms.Core.Model.ImExportTemplate.Area
{
    /// <summary>
    /// 下载库区模板
    /// </summary>
    public class AreaDownloadTemplate
    {
        /// <summary>
        /// 库区名称
        /// </summary>
        [ExcelColumn(Name = "库区名称", Index = 0, Width = 12)]
        public string Name { get; set; }

        /// <summary>
        /// 库区编码
        /// </summary>
        [ExcelColumn(Name = "库区编码", Index = 1, Width = 12)]
        public string Code { get; set; }

        /// <summary>
        /// 仓库编码
        /// </summary>
        [ExcelColumn(Name = "仓库编码", Index = 2, Width = 12)]
        public string WareHouseCode { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [ExcelColumn(Name = "备注", Index = 3, Width = 40)]
        public string? Remark { get; set; }


    }
}

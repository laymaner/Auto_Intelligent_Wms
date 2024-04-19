using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Intelligent_Wms.Core.Common.Enum
{
    public enum DataStatus
    {
        [Description("正常")]
        Normal = 1,
        [Description("删除")]
        Delete = 2,
        [Description("禁用")]
        Disabled = 3,
    }
}

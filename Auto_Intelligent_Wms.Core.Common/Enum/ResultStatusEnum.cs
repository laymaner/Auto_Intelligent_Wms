using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Intelligent_Wms.Core.Common.Enum
{
    public enum ResultStatusEnum
    {
        [Description("请求成功")]
        Success = 200,

        [Description("请求失败")]
        Fail = 400,

        [Description("请求资源未找到,请求失败")]
        NotFound = 404,

        [Description("请求异常")]
        Error = 500
    }
}

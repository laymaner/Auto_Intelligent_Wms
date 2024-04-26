using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Intelligent_Wms.Core.Common.Filter
{
    public class RequestFilter : IAsyncActionFilter
    {

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
        /*    var request = context.HttpContext.Request;
            var response = context.HttpContext.Response.StatusCode;
            var method = request.Method;
            var ip = context.HttpContext.Connection.RemoteIpAddress.ToString();
            var usercode = context.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            var url = request.Path;
            var param = context.ActionArguments.Values.ToString();
            int i = 0;
            await next();*/
            
        }
    }
}

using Auto_Intelligent_Wms.Core.Extensions.Attri;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Auto_Intelligent_Wms.Core.Extensions.Filter
{
    public class TransationScopeFilter : IAsyncActionFilter
    {
        /// <summary>
        /// 事务
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            bool hasTransactionalAttribute = false;
            if (context.ActionDescriptor is ControllerActionDescriptor)
            {
                var actionDesc = (ControllerActionDescriptor)context.ActionDescriptor;
                hasTransactionalAttribute = actionDesc.MethodInfo.IsDefined(typeof(TransationAttribute));
            }
            if (!hasTransactionalAttribute)
            {
                await next();
                return;
            }
            using var txScope =
                    new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var result = await next();
            if (result.Exception == null)
            {
                txScope.Complete();
            }
        }
    }
}

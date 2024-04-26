using Auto_Intelligent_Wms.Core.Common.Enum;
using Auto_Intelligent_Wms.Core.Model.Entities;
using Mask_STK.Core.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Intelligent_Wms.Core.Extensions.Filter
{
    public class RequestFilter : IActionFilter
    {
        private readonly Auto_Inteligent_Wms_DbContext _db;
        private readonly ILogger<RequestFilter> _log;
        private Operate_Log operate_Log = new Operate_Log();


        public RequestFilter(Auto_Inteligent_Wms_DbContext db,ILogger<RequestFilter> log)
        {
            _db = db;
            _log = log;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            ControllerActionDescriptor desc = context.ActionDescriptor as ControllerActionDescriptor;

            var request = context.HttpContext.Request;
            var re =request.Host;
            operate_Log.OperateType = request.Method;
            operate_Log.IpAddress = context.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            var userId = long.Parse(context.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            var user = _db.Users.Where(m => m.Id == userId && m.Status == (int)DataStatus.Normal).SingleOrDefault();

            operate_Log.UserCode = user.Code;
            operate_Log.UserName = user.Name;
            operate_Log.OperateUrl = request.Path;
            operate_Log.Creator = userId;

            operate_Log.OperateParams = JsonConvert.SerializeObject(context.ActionArguments);

            operate_Log.Title = desc.ControllerName;
            operate_Log.Method = desc.ActionName;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                operate_Log.ErrorMsg = context.Exception.Message;
            }


            operate_Log.OperateStatus = context.HttpContext.Response.StatusCode;
            operate_Log.CreateTime = DateTime.Now;
            operate_Log.Status = (int)DataStatus.Normal;
             _db.Operate_Logs.Add(operate_Log);
             _db.SaveChanges();
        }

     
    }
}

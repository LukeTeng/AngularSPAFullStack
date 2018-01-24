using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using AngularSPA.Modules;
using AngularSPA.Utilities.JSON;

namespace AngularSPA.Infrastructure.MiddleWares
{
    public class GeneralExHandlingMW
    {
        private readonly RequestDelegate _next;
        public GeneralExHandlingMW(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            if (context.Request.Path.ToString().Contains("/api/") && !context.Request.Path.ToString().Contains("/swagger/"))
            {
                var code = HttpStatusCode.OK;
                var result = JsonConvert.SerializeObject(new { error = ex.Message, details = ex.ToString() });
                var response = new ApiResponse<string>(new ErrorMsg { Code = Status.ServerError, Message = result });
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)code;
                return context.Response.WriteAsync(JsonHelper.GetCamelCaseJsonString(response));
            }
            else
            {
                throw ex;
            }
        }
    }
}

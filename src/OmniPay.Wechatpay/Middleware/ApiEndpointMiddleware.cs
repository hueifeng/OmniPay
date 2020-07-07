using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OmniPay.Wechatpay.Middleware
{
    /// <summary>
    ///    WeChat Pay middleware
    /// </summary>
    public class ApiEndpointMiddleware
    {
        private readonly RequestDelegate _next;

        public ApiEndpointMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //Access request method
            var responseContent = context.Request.Path.Value.Replace("/pay-api","");
            responseContent = responseContent.TrimStart('/');

            context.Response.ContentType = "application/json";
            //Reflective access methods
            Type t = typeof(TestPay);
            var tuple= GetObjectMethodTuple(t, responseContent);
            if (tuple.Item1 == null) throw new  NotImplementedException("not implement the stack");

            string str = tuple.Item1.Invoke(tuple.Item2, null).ToString();

            await context.Response.WriteAsync(str);
        }


        public static Tuple<MethodInfo, object> GetObjectMethodTuple(Type type,string methodname) {
            object obj = Activator.CreateInstance(type);
            MethodInfo mt = type.GetMethod(methodname);
            return new Tuple<MethodInfo, object>(mt,obj);
        }

    }
}

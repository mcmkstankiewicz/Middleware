using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Middleware
{
    public class UrlTransformMiddleware
    {
        private RequestDelegate _next; // prywatne pole
        public UrlTransformMiddleware(RequestDelegate next) //konstruktor(przechodzenie do nastepnej czesci)
        {
            _next = next; //pole jest rowne next
        }

        public Task Invoke(HttpContext context)
        {
            string header;
            header = context.Request.Headers["User-Agent"];
            return context.Response.WriteAsync($"Zmienna:{header}");


        }

    }

    public static class UrlTranformMiddlewareExtension
    {
        public static IApplicationBuilder UseUrlTransformMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware <UrlTransformMiddleware>();
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace learnAspDotNetCore.Extensions
{
    public static class IApplicationBuilderExtensions
    {
        public static void RefreshLogin(this IApplicationBuilder app) {
            app.Use(async (context, next) =>
            {
                await context.RefreshLoginAsync();
                await next();
            });
        }
    }
}

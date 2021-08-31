using learnAspDotNetCore.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace learnAspDotNetCore.Tools
{
    public class RefreshLoginAttribute : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        
        {
            await context.HttpContext.RefreshLoginAsync();
            await next();
        }
    }
}

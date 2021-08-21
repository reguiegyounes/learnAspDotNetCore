using learnAspDotNetCore.Models.Types;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace learnAspDotNetCore.Controllers
{
    public class ErrorController : Controller
    {
        [Route("/Error/{StatusCode}")]
        public IActionResult Index(int StatusCode)
        {
            StatusResult model= new StatusResult();
            var statusResult =HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            switch (StatusCode)
            {
                case 404:
                    {
                        model.Message = "Sorry , The resource you requested could not be found.";
                        model.Path = statusResult.OriginalPath;
                        model.QueryStrings = statusResult.OriginalQueryString;
                    }
                    break;
                default:
                    {
                        model.Message = "This page cannot be found";
                        model.Path = statusResult.OriginalPath;
                        model.QueryStrings = statusResult.OriginalQueryString;
                    }
                     break;
            }
            ViewBag.StatusCode=StatusCode.ToString();
            return View("NotFound",model);
        }
    }
}

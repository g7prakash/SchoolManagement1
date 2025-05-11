using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagement.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            this.logger = logger;
        }
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry the resource you requested, Could not be found";
                    if (statusCodeResult != null)
                    {
                        logger.LogWarning($"404 Error Occured. path = {statusCodeResult.OriginalPath}" +
                        $"QueryString = {statusCodeResult.OriginalQueryString}");
                    }
                    
                    break;
                default:
                    break;
            }
            return View("NotFound");
        }

        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            logger.LogError($"The path {exceptionDetails.Path} threw an exception {exceptionDetails.Error}");

            return View("Error");
        }
    }
}

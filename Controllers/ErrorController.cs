using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace MovieMania.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Requested resource not found";
                    if (statusCodeResult != null)
                    {
                        ViewBag.ErrorPath = statusCodeResult.OriginalPath;
                        ViewBag.ErrorQS = statusCodeResult.OriginalQueryString;
                    }
                    break;
            }

            return View("NotFound");
        }
    }
}

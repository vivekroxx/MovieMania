using Microsoft.AspNetCore.Mvc;

namespace MovieMania.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

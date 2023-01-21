using Microsoft.AspNetCore.Mvc;

namespace MovieMania.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddMovie()
        {
            return View("~/Views/Form/AddMovie.cshtml");
        }

    }
}

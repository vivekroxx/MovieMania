using Microsoft.AspNetCore.Mvc;
using MovieMania.Data;
using MovieMania.Models;

namespace MovieMania.Controllers
{
    public class MovieController : Controller
    {
        public MovieController()
        {

        }

        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(MovieViewModel Form)
        {
            if (ModelState.IsValid)
            {
            }

            return View();
        }

        [HttpPost]
        public IActionResult AddToFavorite(int Id)
        {
            if (ModelState.IsValid)
            {
            }

            return View();
        }
    }
}

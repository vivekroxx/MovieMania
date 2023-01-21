using Microsoft.AspNetCore.Mvc;
using MovieMania.Models;

namespace MovieMania.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _db;

        public MovieController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(MoviesModel Form)
        {
            if (ModelState.IsValid)
            {
                _db.Add(Form);
                _db.SaveChanges();  
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

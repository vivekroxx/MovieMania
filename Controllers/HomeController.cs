using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieMania.Models;
using System.Diagnostics;

namespace MovieMania.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(MovieViewModel model)
        {
            var movieList = _db.Movies.ToList();
            var user = await _userManager.GetUserAsync(User);

            List< MovieViewModel> movies = new();

            foreach (var movie in movieList)
            {
                var isFavorite = _db.FavoriteMovie.Where(x => x.MovieId == movie.Id && x.UserId == user.Id).Any();

                model.Id= movie.Id;
                model.Name= movie.Name;
                model.Description= movie.Description;
                model.isFavorite= isFavorite;
                model.Author= movie.Author;
                model.Duration= movie.Duration;
                model.CreatedOn= movie.CreatedOn;
                model.CreatedBy = movie.CreatedBy;
                model.PhotoName= movie.PhotoName;
                model.ReleaseDate= movie.ReleaseDate;

                movies.Add(model);
            }

            return View(movies);
        }

        public IActionResult Details(int id)
        {
            var movie = _db.Movies.FirstOrDefault(x => x.Id == id);
            if (movie == null)
            {
                return View("NotFound");
            }

            return View(movie);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
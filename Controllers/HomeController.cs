using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieMania.Models;
using System.Diagnostics;

namespace MovieMania.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var movies = _db.Movies.ToList();

            List<MovieViewModel> movieList = new();
            var user = await _userManager.GetUserAsync(User);

            foreach (var movie in movies)
            {
                var favoriteMovie = _db.FavoriteMovie.FirstOrDefault(x => x.MovieId == movie.Id && x.UserId == user.Id);

                var data = new MovieViewModel
                {
                    Id = movie.Id,
                    Author = movie.Author,
                    Name = movie.Name,
                    CreatedBy = movie.CreatedBy,
                    CreatedOn = movie.CreatedOn,
                    Description = movie.Description,
                    Duration = movie.Duration,
                    PhotoName = movie.PhotoName,
                    ReleaseDate = movie.ReleaseDate,
                    IsFavorite = favoriteMovie != null ? favoriteMovie.IsFavorite : false
                };

                movieList.Add(data);
            }

            return View(movieList);
        }

        public async Task<IActionResult> Details(int id)
        {
            var movie = _db.Movies.FirstOrDefault(x => x.Id == id);

            if (movie == null)
            {
                return View("NotFound");
            }

            var user = await _userManager.GetUserAsync(User);
            var favoriteMovie = _db.FavoriteMovie.FirstOrDefault(x => x.MovieId == movie.Id && x.UserId == user.Id);

            var result = new MovieViewModel
            {
                Id = movie.Id,
                Author = movie.Author,
                Name = movie.Name,
                CreatedBy = movie.CreatedBy,
                CreatedOn = movie.CreatedOn,
                Description = movie.Description,
                Duration = movie.Duration,
                PhotoName = movie.PhotoName,
                ReleaseDate = movie.ReleaseDate,
                IsFavorite = favoriteMovie != null ? favoriteMovie.IsFavorite : false
            };

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> FavoriteMovies()
        {
            var user = await _userManager.GetUserAsync(User);

            var favoriteMovieIds = _db.FavoriteMovie.Where(x => x.UserId == user.Id && x.IsFavorite == true).Select(x => x.MovieId);
            var movieList = _db.Movies.Where(x => favoriteMovieIds.Contains(x.Id));

            return View(movieList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
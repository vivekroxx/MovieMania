using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieMania.Data;
using MovieMania.Models;
using System.Diagnostics;

namespace MovieMania.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            MovieViewModel model = new()
            {
                Id = 1,
                Name = "Vivek",
                Author = "Vivek KUmar",
                Description = "ABCD",
                Duration = TimeSpan.Zero,
                ReleaseDate= DateTime.Now
            };

            return View(model);
        }

        public IActionResult Details(int Id)
        {

            MovieViewModel model = new()
            {
                Id = 1,
                Name = "Vivek",
                Author = "Vivek KUmar",
                Description = "ABCD",
                Duration = TimeSpan.Zero,
                ReleaseDate = DateTime.Now
            };

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
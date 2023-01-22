using Microsoft.AspNetCore.Mvc;
using MovieMania.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace MovieMania.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IHostingEnvironment _hostingEnvironment;

        public MovieController(ApplicationDbContext db, IHostingEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MovieCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadFile(model);

                MovieModel newMovie = new()
                {
                    Name = model.Name,
                    PhotoPath = uniqueFileName ?? "avatar/noimage.jpg",
                    Author = model.Author,
                    Description = model.Description,
                    Duration = model.Duration,
                    ReleaseDate = model.ReleaseDate,
                };

                _db.Add(newMovie);
                _db.SaveChanges();
            }

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movie = _db.Movies.FirstOrDefault(x => x.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            MovieEditViewModel editMovie = new()
            {
                Id = movie.Id,
                Name = movie.Name,
                Author = movie.Author,
                Description = movie.Description,
                Duration = movie.Duration,
                ReleaseDate = movie.ReleaseDate,
                ExistingPhotoPath = movie.PhotoPath
            };

            return View(editMovie);
        }

        [HttpPost]
        public IActionResult Edit(MovieEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var movie = _db.Movies.FirstOrDefault(x => x.Id == model.Id);

                if (movie != null)
                {
                    movie.Name = model.Name;
                    movie.Author = model.Author;
                    movie.Description = model.Description;
                    movie.Duration = model.Duration;
                    movie.ReleaseDate = model.ReleaseDate;
                    movie.PhotoPath = ProcessUploadFile(model);

                    if (model.Photo != null)
                    {
                        string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "image", model.ExistingPhotoPath);
                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }
                    }

                    _db.Update(movie);
                    _db.SaveChanges();
                }
            }

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        private string ProcessUploadFile(MovieCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "image");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            return uniqueFileName;
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var movie = _db.Movies.FirstOrDefault(x => x.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "image", movie.PhotoPath);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
            _db.Remove(movie);
            _db.SaveChanges();

            return RedirectToAction(nameof(HomeController.Index), "Home");
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

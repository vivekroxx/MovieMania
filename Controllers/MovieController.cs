using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieMania.Models;

namespace MovieMania.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _Environment;

        public MovieController(ApplicationDbContext db, IWebHostEnvironment hostingEnvironment)
        {
            _db = db;
            _Environment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MovieEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadFile(model);

                MovieModel newMovie = new()
                {
                    Name = model.Name,
                    PhotoName = uniqueFileName,
                    Author = model.Author,
                    Description = model.Description,
                    Duration = new TimeSpan(model.Hours, model.Minutes, 0),
                    ReleaseDate = model.ReleaseDate,
                    CreatedBy = User.Identity?.Name,
                    CreatedOn = DateTime.Now
                };

                _db.Add(newMovie);
                _db.SaveChanges();
            }
            else
            {
                return View(model);
            }

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movie = _db.Movies.FirstOrDefault(x => x.Id == id);

            if (movie == null)
            {
                return View("NotFound");
            }

            MovieEditViewModel editMovie = new()
            {
                Id = movie.Id,
                Name = movie.Name,
                Author = movie.Author,
                Description = movie.Description,
                Hours = movie.Duration.Hours,
                Minutes = movie.Duration.Minutes,
                ReleaseDate = movie.ReleaseDate,
                ExistingPhotoPath = movie.PhotoName
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
                    movie.Duration = new TimeSpan(model.Hours, model.Minutes, 0);
                    movie.ReleaseDate = model.ReleaseDate;
                    movie.PhotoName = ProcessUploadFile(model);

                    if (model.Photo != null && !string.IsNullOrWhiteSpace(model.ExistingPhotoPath))
                    {
                        string filePath = Path.Combine(_Environment.WebRootPath, "image", model.ExistingPhotoPath);
                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }
                    }

                    _db.Update(movie);
                    _db.SaveChanges();
                }
            }
            else
            {
                return View(model);
            }

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        private string ProcessUploadFile(MovieEditViewModel model)
        {
            string uniqueFileName = string.Empty;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(_Environment.WebRootPath, "image");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using var fileStream = new FileStream(filePath, FileMode.Create);
                model.Photo.CopyTo(fileStream);
            }
            else
            {
                uniqueFileName = model.ExistingPhotoPath ?? "";
            }

            return uniqueFileName;
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var movie = _db.Movies.FirstOrDefault(x => x.Id == id);
            if (movie == null)
            {
                return View("NotFound");
            }
            if (!String.IsNullOrWhiteSpace(movie.PhotoName))
            {
                var filePath = Path.Combine(_Environment.WebRootPath, "image", movie.PhotoName);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
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

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

    }
}

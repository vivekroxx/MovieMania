using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using MovieMania.Models;

namespace MovieMania.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _db;
        //private readonly IHostingEnvironment _hostingEnvironment;

        public MovieController(ApplicationDbContext db)
        {
            _db = db;
            //_hostingEnvironment = hostingEnvironment;

        }

        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] MovieCreateViewModel Form)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (Form.Photo != null)
                {

                }

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

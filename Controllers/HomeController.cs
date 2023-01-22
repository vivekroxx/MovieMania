﻿using Microsoft.AspNetCore.Mvc;
using MovieMania.Models;
using System.Diagnostics;

namespace MovieMania.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var movieList = _db.Movies.ToList();

            return View(movieList);
        }

        public IActionResult Details(int Id)
        {
            var movie = _db.Movies.FirstOrDefault(x => x.Id == Id);

            return View(movie);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
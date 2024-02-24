using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Hall.Models;
using System.Diagnostics;

namespace Mission06_Hall.Controllers
{
    public class HomeController : Controller
    {
        private MovieEntryContext _context;
        public HomeController(MovieEntryContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieEntry()
        {
            ViewBag.Category = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();


            return View("MovieEntry", new Entry());
        }

        [HttpPost]
        public IActionResult MovieEntry(Entry response)
        {
            if (ModelState.IsValid)
            {
                response.LentTo ??= "";
                response.Notes ??= "";

                _context.Movies.Add(response);
                _context.SaveChanges();

                return View("Confirmation", response);
            }
            else
            {
                ViewBag.Category = _context.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();
                return View(response);
            }
            
        }

        public IActionResult MovieDisplay()
        {
            var movieList = _context.Movies.Include(x => x.Category)
                .OrderBy(x => x.Title).ToList();

            return View(movieList);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Category = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("MovieEntry", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Entry updateInfo)
        {
            _context.Update(updateInfo);
            _context.SaveChanges();

            return RedirectToAction("MovieDisplay");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Entry movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction("MovieDisplay");
        }
    }
}
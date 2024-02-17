using Microsoft.AspNetCore.Mvc;
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
            return View();
        }

        [HttpPost]
        public IActionResult MovieEntry(Entry response)
        {
            response.LentTo ??= "";
            response.Notes ??= "";

            _context.Movies.Add(response);
            _context.SaveChanges();

            return View("Confirmation", response);
        }
    }
}

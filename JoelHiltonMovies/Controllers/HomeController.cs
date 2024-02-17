using JoelHiltonMovies.Models;
using Microsoft.AspNetCore.Mvc;

namespace JoelHiltonMovies.Controllers
{
    public class HomeController : Controller
    {
        private NewMovieContext _context;

        public HomeController(NewMovieContext movies) 
        { 
            _context = movies;
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
        public IActionResult NewMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewMovie(AddMovie response)
        {
            _context.Movie.Add(response);
            _context.SaveChanges();

            return View("Confirmation");
        }
    }
}
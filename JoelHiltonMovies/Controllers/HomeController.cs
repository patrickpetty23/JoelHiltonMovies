// Import necessary namespaces.
using JoelHiltonMovies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// Define the namespace and class for the controller.
namespace JoelHiltonMovies.Controllers
{
    // Define the HomeController class inheriting from Controller.
    public class HomeController : Controller
    {
        // Define a private field to hold the database context.
        private NewMovieContext _context;

        // Define a constructor to inject the database context.
        public HomeController(NewMovieContext context)
        {
            _context = context;
        }

        // Define action method for the Index view.
        public IActionResult Index()
        {
            return View();
        }

        // Define action method for the GetToKnowJoel view.
        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        // Define HTTP GET action method for the NewMovie view.
        [HttpGet]
        public IActionResult NewMovie()
        {
            // Fetch categories from the database and pass them to the view.
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            // Return the NewMovie view with a new Movies object.
            return View(new Movies());
        }

        // Define HTTP POST action method for the NewMovie view.
        [HttpPost]
        public IActionResult NewMovie(Movies response)
        {
            // If model state is valid, add the movie to the database and redirect to confirmation view.
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();
                return View("Confirmation");
            }
            else // If model state is not valid, reload the NewMovie view with validation errors.
            {
                ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
                return View();
            }
        }

        // Define action method for the DisplayMovie view.
        public IActionResult DisplayMovie()
        {
            // Fetch movies from the database along with their categories and order by title.
            var movies = _context.Movies
                .Include(m => m.Category)
                .OrderBy(m => m.Title)
                .ToList();

            // Return the DisplayMovie view with the list of movies.
            return View(movies);
        }

        // Define HTTP GET action method for the Edit view.
        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Fetch the movie record to edit from the database.
            var record = _context.Movies
                .Single(x => x.MovieId == id);

            // Fetch categories from the database and pass them to the view.
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            // Return the NewMovie view with the movie record to edit.
            return View("NewMovie", record);
        }

        // Define HTTP POST action method for the Edit view.
        [HttpPost]
        public IActionResult Edit(Movies updatedInfo)
        {
            // Update the movie record in the database and redirect to DisplayMovie view.
            _context.Update(updatedInfo);
            _context.SaveChanges();
            return RedirectToAction("DisplayMovie");
        }

        // Define action method for the Delete view.
        public IActionResult Delete(int id)
        {
            // Fetch the movie record to delete from the database.
            var record = _context.Movies
                .Single(x => x.MovieId == id);

            // Return the Delete view with the movie record to delete.
            return View(record);
        }

        // Define HTTP POST action method for the Delete view.
        [HttpPost]
        public IActionResult Delete(Movies movie)
        {
            // Remove the movie record from the database and redirect to DisplayMovie view.
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("DisplayMovie");
        }
    }
}
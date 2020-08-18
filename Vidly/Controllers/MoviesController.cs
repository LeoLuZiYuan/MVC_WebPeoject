using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Vidly.Models;
using Vidly.ViewModel;
using String = System.String;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        public ActionResult Index()
        {
            var movies = GetMovies();

            return View(movies);
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>()
            {
                new Customer(){ Name = "Customer 1"},
                new Customer(){ Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };

            //"Bad" method
            //ViewData["Movie"] = movies;
            // ViewBag.Movie = movies;


            return View(viewModel);
            //return Content("Hello World");
            //return HttpNotFound();
            //return new EmptyResult();
            // return RedirectToAction("Index", "Home", new { page = 1, sortby = "name" });
        }

        public ActionResult Edit(int id)
        {
            return Content("id =" + id);
        }


        //movies
        

        /// mvcaction4  action snipper
        
         [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        private IEnumerable<Movie> GetMovies()
        {
            var movies = new List<Movie>()
            {
                new Movie(){ Name = "Shrek"},
                new Movie(){ Name = "Wall-e"}
            };

            return movies;
        }
    }
}
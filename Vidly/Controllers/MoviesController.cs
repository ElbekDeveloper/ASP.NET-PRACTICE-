using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Infrastructure.MappingViews;
using Vidly.ViewModels;
using Microsoft.Owin.Security.Provider;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        public ApplicationDbContext _context { get; set; }
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies
        public ActionResult Index()
        {
            
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Movie movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            MovieViewModel viewModel = new MovieViewModel
            {
                Movie = movie,
                Genres = _context.Genres
            };
            return View("MovieForm", viewModel);
        }
        [HttpGet]
        public ActionResult Create()
        {
            List<Genre> genres = _context.Genres.ToList();

            var viewModel = new MovieViewModel()
            {
                Genres = genres,
                Movie = new Movie()
            };
            return View("MovieForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (ModelState.IsValid == false)
            {
                MovieViewModel viewModel = new MovieViewModel
                {
                    Movie = movie,
                    Genres =_context.Genres
                };

                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                Movie movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.GenreId = movie.GenreId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            Movie movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            MovieViewModel movieViewModel = new MovieViewModel
            {
                Movie = movie,
                Genres = _context.Genres
            };

            return View(movieViewModel);
        }
        public ActionResult Delete(int id)
        {
            if (id < 0)
            {
                return HttpNotFound();
            }
            Movie movie= _context.Movies.FirstOrDefault(c => c.Id == id);

            if (movie!= null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
                return RedirectToAction("Index", "Movies");
            }
            return RedirectToAction("Index", "Movies");
        }
    } 
}
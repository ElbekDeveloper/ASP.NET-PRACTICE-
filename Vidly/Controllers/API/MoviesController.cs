using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class MovieDtoesController : ApiController
    {
        private ApplicationDbContext _context;

        public MovieDtoesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: api/Movies
        [Route("api/Movies")]
        [HttpGet]
        public IHttpActionResult GetMovies()
        {
            IEnumerable<MovieDto> movies = _context.Movies.Include(m => m.Genre)
                                                            .ToList()
                                                            .Select(Mapper.Map<Movie, MovieDto>);
            return Ok(movies) ;
        }

        // GET: api/Movies/5
        [ResponseType(typeof(MovieDto))]
        [HttpGet]
        [Route("api/Movies/{id}")]
        public IHttpActionResult GetMovie(int id)
        {
            Movie movie= _context.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        // PUT: api/Movies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movieDto.Id)
            {
                return BadRequest();
            }
            Movie movie = Mapper.Map<MovieDto, Movie>(movieDto);


            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Movies
        //[ResponseType(typeof(MovieDto))]
        [HttpPost]
        [Route("api/Movies")]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Movie movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        // DELETE: api/Movies/5
        //[ResponseType(typeof(Movie))]
        [Route("api/Movies/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            Movie movie = _context.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return Ok(movie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Count(e => e.Id == id) > 0;
        }
    }
}
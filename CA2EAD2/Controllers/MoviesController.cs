using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CA2EAD2;
using System.Text.RegularExpressions;

namespace CA2EAD2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieContext _context;      

        public MoviesController(MovieContext context)
        {
            _context = context;
        }

        // GET: api/Movies
        [HttpGet]
        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies;
        }

        // GET: api/Movies/5
        [HttpGet("{searchString}")]
        public async Task<IActionResult> GetMovie(string searchString)
        {
            searchString = searchString.Replace("_", " ");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Movie[] movie = await _context.Movies.Where(e => (e.Title.Contains(searchString)) || (e.Year.Contains(searchString)) || (e.Genre.Contains(searchString))).ToArrayAsync();
            
            //if (movie == null)
            //{
            //    return NotFound();
            //}

            //Search method:
            var moviesSearched = _context.Movies.Where(e => (e.Title.ToLower().Contains(searchString.ToLower())) || (e.Year.Contains(searchString)) || (e.Genre.ToLower().Contains(searchString.ToLower())));

            if (!moviesSearched.Any())
            {
                // Separate name and year (if present)
                String name = Regex.Replace(searchString, @"\d{4}", ""); // Name with out year
                name = Regex.Replace(name, @"^\s+|\s+$", ""); // get rid of all extra spaces before/after name
                String year = Regex.Match(searchString, @"\d{4}").Groups[0].ToString(); // year from the string
                moviesSearched = _context.Movies.Where(j => j.Year.Equals(year))
                                       .Where(e => (e.Title.ToLower().Contains(name.ToLower())) || e.Genre.ToLower().Contains(name.ToLower()));

            }

            return Ok(moviesSearched);
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}
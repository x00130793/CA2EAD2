using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CA2EAD2;

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
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Movie[] movie = await _context.Movies.Where(e => (e.Title.Contains(searchString)) || (e.Year.Contains(searchString)) || (e.Genre.Contains(searchString))).ToArrayAsync();
            
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}
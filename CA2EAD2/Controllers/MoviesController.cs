using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CA2EAD2.Controllers
{
    [Route("api/Movies")]
    public class MoviesController : ControllerBase
    {
        List<Movie> movies;

        public MoviesController()
        {
            movies = new List<Movie>();
            movies.Add(new Movie() { Id = 1, Title = "Inception", Genre = "Thriller", Year = "2010" });
            movies.Add(new Movie() { Id = 2, Title = "The butterfly Effect", Genre = "Thriller", Year = "2004" });
            movies.Add(new Movie() { Id = 3, Title = "Looper", Genre = "Thriller", Year = "2012" });
            movies.Add(new Movie() { Id = 4, Title = "Pulp Fiction", Genre = "Crime", Year = "1994" });
        }

        [HttpGet("all")]
        // GET api/movies/all
        public IEnumerable<Movie> GetAllMovies()
        {
            var allMovies = movies.OrderBy(m => m.Title);
            return allMovies;
        }

        [HttpGet("title/{title}")]
        //GET api/movies/title/"title"
        public IActionResult GetTitle(String titleIn)
        {
            //LINQ to find matching title
            var title = movies.FirstOrDefault(t => t.Title.ToUpper() == titleIn.ToUpper());
            if (title == null)
            {
                return NotFound();
            }
            return Ok(title);
        }

        [HttpGet("genre/{genre}")]
        //GET api/movies/genre/"genre"
        public IEnumerable<Movie> GetByGenre(String genreIn)
        {
            //LINQ to find movies by genre
            var genre = movies.Where(g => g.Genre.ToUpper() == genreIn.ToUpper());
            return genre;
        }

        [HttpGet("year/{year}")]
        //GET api/movies/year/"year"
        public IEnumerable<Movie> GetByYear(String yearIn)
        {
            //LINQ to find movies by genre
            var year = movies.Where(y => y.Year.ToUpper() == yearIn.ToUpper());
            return year;
        }
    }
}

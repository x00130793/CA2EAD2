using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CA2EAD2.Controllers
{
    public class InitializeDb
    {
        public static void Initialize(MovieContext context)
        {
            // context.Database.EnsureCreated();

            // Look for any students.
            if (context.Movies.Any())
            {
                return;   // DB has been seeded
            }

            var movies = new Movie[]
            {
            new Movie() { Title = "Inception", Genre = "Thriller", Description="Nice movie", Year = "2010" },
            new Movie() { Title = "Inception2", Genre = "Thriller", Description="Nice movie", Year = "2010" },
            new Movie() { Title = "Inception3", Genre = "Thriller", Description="Nice movie", Year = "2010" },
            new Movie() { Title = "Inception4", Genre = "Thriller", Description="Nice movie", Year = "2010" },
            new Movie() { Title = "Inception5", Genre = "Thriller", Description="Nice movie", Year = "2010" },
            new Movie() { Title = "Inception6", Genre = "Thriller", Description="Nice movie", Year = "2010" },
            };
            foreach (Movie s in movies)
            {
                context.Movies.Add(s);
            }
            context.SaveChanges();
           
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace CA2EAD2
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        { }
        public DbSet<Movie> Movies { get; set; }

    }
}

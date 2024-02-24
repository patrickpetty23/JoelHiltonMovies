using Microsoft.EntityFrameworkCore;

namespace JoelHiltonMovies.Models
{
    public class NewMovieContext : DbContext
    {
        public NewMovieContext(DbContextOptions<NewMovieContext> options) : base(options) 
        {

        }

        public DbSet<Movies> Movies { get; set; }

        public DbSet<Categories> Categories { get; set; }
    }
}

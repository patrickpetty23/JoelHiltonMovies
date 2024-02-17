using Microsoft.EntityFrameworkCore;

namespace JoelHiltonMovies.Models
{
    public class NewMovieContext : DbContext
    {
        public NewMovieContext(DbContextOptions<NewMovieContext> options) : base(options) 
        {

        }

        public DbSet<AddMovie> Movie { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

namespace Mission06_Hall.Models
{
    public class MovieEntryContext : DbContext
    {
        public MovieEntryContext(DbContextOptions<MovieEntryContext> options) : base(options) 
        {
        }

        public DbSet<Entry> Movies { get; set; }

    }
}

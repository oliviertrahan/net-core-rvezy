using Microsoft.EntityFrameworkCore;
using TestApp.Entity;

namespace TestApp.Repository
{
    public class DataContext : DbContext
    {
        public DbSet<Listing> Listings { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
        }
    }
}

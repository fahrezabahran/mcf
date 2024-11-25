using MCFWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MCFWebApp.Data
{
    public class McfDbContext : DbContext
    {
        public McfDbContext(DbContextOptions<McfDbContext> options) : base(options)
        {
        }

        public DbSet<User> MsUsers { get; set; }

        public DbSet<MsStorageLocation> MsStorageLocations { get; set; }
    }
}

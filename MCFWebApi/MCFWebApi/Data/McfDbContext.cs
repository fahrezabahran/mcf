using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MCFWebApi.Models;

namespace MCFWebApi.Data
{
    public class McfDbContext : DbContext
    {
        public McfDbContext(DbContextOptions<McfDbContext> options) : base(options)
        {
        }

        public DbSet<User> MsUsers { get; set; }

        public DbSet<StorageLocation> MsStorageLocations { get; set; }

        public DbSet<Bpkb> Bpkbs { get; set; }
    }
}

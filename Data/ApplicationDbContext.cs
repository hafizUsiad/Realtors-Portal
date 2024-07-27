using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using Real_Estate.Models;

namespace Real_Estate.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Propertyy> Properties { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<PrivateSeller> PrivateSellers { get; set; }
        public DbSet<user> user { get; set; }
        public DbSet<contact> contact { get; set; }

    }

}

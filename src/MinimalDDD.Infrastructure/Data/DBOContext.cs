using Microsoft.EntityFrameworkCore;
using MinimalDDD.Domain.Aggregations.Users;

namespace MinimalDDD.Infrastructure.Data
{
    public class DBOContext : DbContext
    {
        public DBOContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<User> User { get; set; }
    }
}

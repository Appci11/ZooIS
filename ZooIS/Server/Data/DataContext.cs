using Microsoft.EntityFrameworkCore;
using System.Xml;
using ZooIS.Shared.Models;

namespace ZooIS.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<RegisteredUser> RegisteredUsers => Set<RegisteredUser>();
        public DbSet<UserSettings> UserSettings => Set<UserSettings>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserSettings>()
              .Property(e => e.Id)
              .ValueGeneratedNever();
        }
    }
}

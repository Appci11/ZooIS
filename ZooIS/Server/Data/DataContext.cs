using Microsoft.EntityFrameworkCore;
using ZooIS.Shared;

namespace ZooIS.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<RegisteredUser> RegisteredUsers => Set<RegisteredUser>();
    }
}

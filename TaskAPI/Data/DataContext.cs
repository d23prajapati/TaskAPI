using Microsoft.EntityFrameworkCore;

namespace TaskAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Task> Tasktable => Set<Task>();
    }
}

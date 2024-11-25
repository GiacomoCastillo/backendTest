using backend.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<task_colaborator> task_colaborator{ get; set; }

        public DbSet<UserColab> user_colaborator { get; set; }
    }
}

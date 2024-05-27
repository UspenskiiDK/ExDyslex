using Microsoft.EntityFrameworkCore;

namespace DAL.DbModels
{
    public class ApplicationContext: DbContext
    {
        public DbSet<User> Users { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace DAL.DbModels
{
    public class ApplicationContext: DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Client> Clients { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=ExDyslex;Integrated security=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(user =>
            {
                user.Property(user => user.FirstName).IsRequired();
                user.Property(user => user.LastName).IsRequired();
                user.Property(user => user.Birthday).HasColumnType("datetime");
                user.Property(user => user.Password).IsRequired();
                user.Property(user => user.RoleId).IsRequired();
            });

            modelBuilder.Entity<Client>(client =>
            {
                client.Property(client => client.FirstName).IsRequired();
                client.Property(client => client.Birthday).HasColumnType("datetime");
                client.Property(client => client.Email).IsRequired();
                client.Property(client => client.Password).IsRequired();
            });
        }
    }
}

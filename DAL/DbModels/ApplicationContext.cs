using Microsoft.EntityFrameworkCore;

namespace DAL.DbModels
{
    public class ApplicationContext: DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<Test> Tests { get; set; } = null!;
        public DbSet<Task> Tasks { get; set; } = null!;
        public DbSet<TasksToTest> TasksToTests { get; set; } = null!;
        public DbSet<TestsToClient> TestsToClients { get; set; } = null!;

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

            modelBuilder.Entity<Test>(test =>
            {
                test.Property(test => test.Name).IsRequired();
            });

            modelBuilder.Entity<Task>(task =>
            {
                task.Property(task => task.TaskCategory).IsRequired();
                task.Property(task => task.TaskQuestion).IsRequired();
            });

            modelBuilder.Entity<TasksToTest>(ttt =>
            {
                ttt.Property(ttt => ttt.TaskId).IsRequired();
                ttt.Property(ttt => ttt.TestId).IsRequired();
            });

            modelBuilder.Entity<TasksToTest>()
                .HasKey(ttt => new { ttt.TaskId, ttt.TestId });

            modelBuilder.Entity<TasksToTest>()
                .HasOne(t => t.Task)
                .WithMany(te => te.TasksToTests)
                .HasForeignKey(bc => bc.TaskId);

            modelBuilder.Entity<TasksToTest>()
                .HasOne(tt => tt.Test)
                .WithMany(c => c.TasksToTests)
                .HasForeignKey(bc => bc.TestId);

            modelBuilder.Entity<TestsToClient>(ttc =>
            {
                ttc.Property(ttc => ttc.TasksToTestId).IsRequired();
                ttc.Property(ttc => ttc.ClientId).IsRequired();
            });

            modelBuilder.Entity<TestsToClient>()
                .HasKey(ttc => new { ttc.ClientId, ttc.TasksToTestId });

            modelBuilder.Entity<TestsToClient>()
                .HasOne(t => t.Client)
                .WithMany(te => te.TestsToClients)
                .HasForeignKey(bc => bc.ClientId);

            modelBuilder.Entity<TestsToClient>()
                .HasOne(tt => tt.TasksToTest)
                .WithMany(c => c.TestsToClients)
                .HasForeignKey(bc => bc.TasksToTestId);
        }
    }
}

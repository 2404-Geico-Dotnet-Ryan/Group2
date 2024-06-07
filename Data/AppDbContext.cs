using Microsoft.EntityFrameworkCore;
using ProjectTwo.Models;

namespace ProjectTwo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<PurchaseHistory> PurchaseHistories { get; set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     string connectionString = File.ReadAllText(@"C:\Users\U88ABJ\Revature\ProjectTwoDB.txt");
        //     optionsBuilder.UseSqlServer(connectionString);
        // }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PurchaseHistory>()
                .HasOne(p => p.Plant)
                .WithOne(h => h.PurchaseHistory)
                .HasForeignKey<Plant>(p => p.PlantId);

            modelBuilder.Entity<PurchaseHistory>()
                .HasOne(u => u.User)
                .WithOne(h => h.PurchaseHistory)
                .HasForeignKey<User>(u => u.UserId);

            modelBuilder.Entity<User>()
              .HasOne(h => h.PurchaseHistory)
              .WithOne(u => u.User);
              //.HasForeignKey(u => u.UserId);

        }

    }
}
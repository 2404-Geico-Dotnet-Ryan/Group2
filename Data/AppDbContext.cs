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
            // modelBuilder.Entity<User>()
            //   .HasMany(h => h.PurchaseHistories)
            //   .WithOne(u => u.User)
            //   .HasForeignKey(h => h.UserId);

            // modelBuilder.Entity<Plant>()
            //    .HasMany(p => p.PurchaseHistories)
            //    .WithOne(p => p.Plant)
            //    .HasForeignKey(p => p.PlantId);

            modelBuilder.Entity<PurchaseHistory>()
               .HasOne(p => p.User)
               .WithMany(u => u.PurchaseHistories)
               .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<PurchaseHistory>()
               .HasOne(ph => ph.Plant)
               .WithMany(p => p.PurchaseHistories)
               .HasForeignKey(ph => ph.PlantId);

        }

    }
}
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

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     string connectionString = File.ReadAllText(@"C:\Users\U88ABJ\Revature\ProjectTwoDB.txt");
        //     optionsBuilder.UseSqlServer(connectionString);
        // }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(p => p.Plants)
                .WithOne(u => u.Buyer)
                .HasForeignKey(p => p.UserId);
        }

    }
}
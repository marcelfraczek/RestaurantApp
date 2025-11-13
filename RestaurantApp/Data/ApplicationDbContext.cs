using Microsoft.EntityFrameworkCore;
using RestaurantApp.Models;

namespace RestaurantApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Dish>(entity =>
            {
                entity.ToTable("Dishes");
                entity.HasIndex(e => e.Name);
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("Ratings");
                entity.HasOne(r => r.Dish)
                      .WithMany(d => d.Ratings)
                      .HasForeignKey(r => r.DishId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}

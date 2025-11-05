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
        // Tabela z daniami
        public DbSet<Dish> Dishes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Konfiguracja tabeli
            modelBuilder.Entity<Dish>(entity =>
            {
                entity.ToTable("Dishes");
                entity.HasIndex(e => e.Name);
            });
        }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RestaurantApp.Models
{
    public class Dish
    {
        [Key] // Klucz główny
        public int Id { get; set; }
        [Required(ErrorMessage = "Nazwa dania jest wymagana")]
        [StringLength(100)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Opis jest wymagany")]
        [StringLength(500)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Cena jest wymagana")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(0.01, 10000.00, ErrorMessage = "Cena musi być większa od 0")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Kategoria jest wymagana")]
        public MealType Category { get; set; }
        [StringLength(255)]
        public string? ImagePath { get; set; } // Ścieżka do zdjęcia
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
    // Enum dla kategorii posiłków
    public enum MealType
    {
        Śniadanie = 1,
        Obiad = 2,
        Kolacja = 3
    }
}
public ICollection<Rating>? Ratings { get; set; }

[NotMapped]
public double AverageRating => Ratings?.Any() == true
    ? Ratings.Average(r => r.Stars)
    : 0;

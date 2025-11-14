using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace RestaurantApp.Models
{
    public class Dish
    {
        [Key]
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
        public string? ImagePath { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Rating>? Ratings { get; set; }

        [NotMapped]
        public double AverageRating => Ratings?.Any() == true
            ? Ratings.Average(r => r.Stars)
            : 0;

        public ICollection<DishImage>? Images { get; set; }
    }

    public class DishImage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ImagePath { get; set; }

        public bool IsMainImage { get; set; }

        public int DishId { get; set; }
        public Dish Dish { get; set; }
    }

    public enum MealType
    {
        Śniadanie = 1,
        Obiad = 2,
        Kolacja = 3
    }
}

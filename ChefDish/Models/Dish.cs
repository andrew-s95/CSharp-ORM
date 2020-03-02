using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;

namespace ChefDish.Models
{
    public class Dish 
    {
        [Key]
        public int DishId { get; set; }
        [Required]
        [MinLength(2)]
        public string DishName { get; set; }
        [Required]
        [Range(1,10000)]
        public int Calories { get; set; }
        [Required]
        [MinLength(3)]
        public string Description { get; set; }
        [Required]
        [Range(1,5)]
        public int Tastiness { get; set; }
        [Required]
        public int ChefId { get; set; }
        public Chef Creator { get; set; }
    }
}
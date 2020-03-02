using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;

namespace ChefDish.Models
{
    public class Chef
    {
        [Key]
        public int ChefId { get; set; }
        [Required]
        [MinLength(3)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(3)]
        public string LastName { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        public int Age
        {
            get {return DateTime.Now.Year - Birthday.Year;}
        }
        public List<Dish> Dishes { get; set; }
    }
}
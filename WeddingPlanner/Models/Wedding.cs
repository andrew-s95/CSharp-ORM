using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models
{
    public class NoPastDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ((DateTime)value <= DateTime.Now)
                return new ValidationResult("Date must be a future date");
            return ValidationResult.Success;
        }
    }

    public class Wedding
    {
        [Key]
        public int WeddingId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage="Wedder Name must have at least 2 characters")]
        public string WedderOne { get; set; }

        [Required]
        [MinLength(2, ErrorMessage="Wedder Name must have at least 2 characters")]
        public string WedderTwo { get; set; }

        [Required]
        [NoPastDate(ErrorMessage="Date must be a future date")]
        public DateTime Date { get; set; }

        [Required]
        public string Address { get; set; }

        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}

        public int UserId { get; set; }
        public User Planner { get; set; }
        public List<Association> Associations { get; set; }
    }
}
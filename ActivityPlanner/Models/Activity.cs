using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActivityPlanner.Models
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

    public class Activity
    {
        [Key]
        public int ActivityId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage="Activity Name must have at least 2 characters")]
        public string ActivityName { get; set; }

        [Required]
        [NoPastDate(ErrorMessage="Date must be a future date")]
        public DateTime Date { get; set; }

        [Required]
        public string Address { get; set; }

        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}

        public int UserId { get; set; }
        public User Coordinator { get; set; }
        public List<Association> Associations { get; set; }


    }
}
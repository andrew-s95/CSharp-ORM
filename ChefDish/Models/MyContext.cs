using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System;
 
namespace ChefDish.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
        public DbSet<Chef> Chefs { get; set; }
        public DbSet<Dish> Dishes { get; set; }
    }
}
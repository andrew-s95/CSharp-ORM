using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace WeddingPlanner.Models
{
    public class MyContext : DbContext
    {
        public MyContext (DbContextOptions options) : base(options) {}
        public DbSet<User> Users { get; set; }
        public DbSet<Wedding> Weddings { get; set; }
        public DbSet<Association> Associations { get; set; }
    }
}
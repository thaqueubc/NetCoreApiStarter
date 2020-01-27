﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApiStarter.Models
{
    public class ToDo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
        public int Priority { get; set; }
        public DateTime CreatedOn { get; set; }
    }

    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
        public int Priority { get; set; }
        public DateTime CreatedOn { get; set; }
    }


    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options) { }
        public DbSet<ToDo> ToDos { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDo>().HasData(
                new { Id = 1, Description = "Clean house", IsComplete = false, Priority = 1, CreatedOn = DateTime.Now },
                new { Id = 2, Description = "Bake cake", IsComplete = false, Priority = 3, CreatedOn = DateTime.Now }
            );

            modelBuilder.Entity<Product>().HasData(
               new { Id = 1, Description = "Prod-01", IsComplete = false, Priority = 1, CreatedOn = DateTime.Now },
               new { Id = 2, Description = "Prod-02", IsComplete = false, Priority = 3, CreatedOn = DateTime.Now }
           );
        }
    }

    
}

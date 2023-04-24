using System;
using FinalExam.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FinalExam.Models
{
    public class CandyshopContext : DbContext
    {
        //public BookstoreContext()
        //{
        //}

        public CandyshopContext(DbContextOptions<CandyshopContext> options)
            : base(options)
        {
        }

        public DbSet<Candy> Candies { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Horror" },
                new Category { CategoryId = 2, CategoryName = "Adventure" },
                new Category { CategoryId = 3, CategoryName = "Comedy" }
            );

            mb.Entity<Candy>().HasData(

                new Candy
                {
                    CandyId = 1,
                    Title = "Michael",
                    Author = "Scott",
                    Publisher = "duh",
                    Isbn = "555-123-4567",
                    Classification = "Sales",
                    CategoryId = 1,
                    PageCount = 2,
                    Price = 25
                },

                new Candy
                {
                    CandyId = 2,
                    Title = "Creed",
                    Author = "Bratton",
                    Publisher = "Jimbo",
                    Isbn = "555-123-7890",
                    Classification = "Undeclared",
                    CategoryId = 2,
                    PageCount = 3,
                    Price = 20
                }
            );
        }
    }
}

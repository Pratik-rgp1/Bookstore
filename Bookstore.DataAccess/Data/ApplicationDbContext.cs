//This class is a basic class that has to be configured in this way in order to use ERC
using Bookstore.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.DataAccess.Data
{
    public class ApplicationDbContext:DbContext  //DbContext is the root class that is used for EF(building class inside ERC inside nuget packages)
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories  { get; set; }
        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "History", DisplayOrder = "1" },
                new Category { Id = 2, Name = "War", DisplayOrder = "2" },
                new Category { Id = 3, Name = "Entertainment", DisplayOrder = "3" }
                );
            modelBuilder.Entity<Product>().HasData(
               new Product
               {
                   Id = 1,
                   Title = "Dark Skies",
                   Author = "Nancy Drew",
                   Description = "A thrilling mystery novel that keeps you on edge.",
                   ISBN = "DSK888002",
                   ListPrice = 120,
                   Price = 110,
                   Price50 = 105,
                   Price100 = 100,
                   CategoryId=1,
                   ImageUrl=""
               },
                new Product
                {
                    Id = 2,
                    Title = "The Lost Symbol",
                    Author = "Dan Brown",
                    Description = "A fast-paced adventure filled with secrets and history.",
                    ISBN = "TLS777003",
                    ListPrice = 150,
                    Price = 140,
                    Price50 = 135,
                    Price100 = 130,
                    CategoryId = 2,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 3,
                    Title = "C# Mastery",
                    Author = "John Doe",
                    Description = "A complete guide to mastering C# and .NET development.",
                    ISBN = "CSM666004",
                    ListPrice = 200,
                    Price = 180,
                    Price50 = 170,
                    Price100 = 160,
                     CategoryId = 3,
                    ImageUrl = ""
                }

                );
        }
    }
}

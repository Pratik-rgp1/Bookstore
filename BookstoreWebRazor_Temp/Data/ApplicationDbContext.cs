using BookstoreWebRazor_Temp.Models;
using Microsoft.EntityFrameworkCore;

namespace BookstoreWebRazor_Temp.Data
{
    public class ApplicationDbContext : DbContext  //DbContext is the root class that is used for EF(building class inside ERC inside nuget packages)
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Enforce unique constraint on DisplayOrder
            //modelBuilder.Entity<Category>()
            //    .HasIndex(c => c.DisplayOrder)
            //    .IsUnique();

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "History", DisplayOrder = "1" },
                new Category { Id = 2, Name = "War", DisplayOrder = "2" },
                new Category { Id = 3, Name = "Entertainment", DisplayOrder = "3" }
                );
        }
    }
}
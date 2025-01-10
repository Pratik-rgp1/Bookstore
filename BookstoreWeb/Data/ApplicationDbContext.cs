//This class is a basic class that has to be configured in this way in order to use ERC
using BookstoreWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BookstoreWeb.Data
{
    public class ApplicationDbContext:DbContext  //DbCongtext is the root class that is used for EF(building class inside ERC inside nuget packages)
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories  { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "History", DisplayOrder = "1" },
                new Category { Id = 2, Name = "War", DisplayOrder = "2" },
                new Category { Id = 3, Name = "Entertainment", DisplayOrder = "3" }
                );
        }
    }
}

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
    }
}

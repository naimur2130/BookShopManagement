using BookShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShop.DataAccess.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) 
        {
                
        }

        public DbSet<Category>Category {  get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Thriller", DisplayOrder = 1 },
                new Category { CategoryId = 2, CategoryName = "Sci-Fi", DisplayOrder = 2 },
                new Category { CategoryId = 3, CategoryName = "History", DisplayOrder = 3 }
                );
        }

    }
}

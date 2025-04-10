using BookShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookShop.DataAccess.Context
{
    public class AppDBContext : IdentityDbContext<IdentityUser>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) 
        {
                
        }

        public DbSet<Category>Category {  get; set; }
        public DbSet<Product> Product { get; set; }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //When we apply IdentityDbContext we have write this particular line of code
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Thriller", DisplayOrder = 1 },
                new Category { CategoryId = 2, CategoryName = "Sci-Fi", DisplayOrder = 2 },
                new Category { CategoryId = 3, CategoryName = "History", DisplayOrder = 3 }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    ProductName = "Fortune of Time",
                    ProductAuthor = "Billy Spark",
                    ProductDescription = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ProductISBN = "SWD9999001",
                    ListofPrice = 99,
                    Price = 90,
                    ListofPrice50 = 85,
                    ListofPrice100 = 80,
                    CategoryId =4,
                    ProductImage=""
                },
                new Product
                {
                    ProductId = 2,
                    ProductName = "Dark Skies",
                    ProductAuthor = "Nancy Hoover",
                    ProductDescription = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ProductISBN = "CAW777777701",
                    ListofPrice = 40,
                    Price = 30,
                    ListofPrice50 = 25,
                    ListofPrice100 = 20,
                    CategoryId = 4,
                    ProductImage = ""
                },
                new Product
                {
                    ProductId = 3,
                    ProductName = "Vanish in the Sunset",
                    ProductAuthor = "Julian Button",
                    ProductDescription = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ProductISBN = "RITO5555501",
                    ListofPrice = 55,
                    Price = 50,
                    ListofPrice50 = 40,
                    ListofPrice100 = 35,
                    CategoryId = 2,
                    ProductImage = ""
                },
                new Product
                {
                    ProductId = 4,
                    ProductName = "Cotton Candy",
                    ProductAuthor = "Abby Muscles",
                    ProductDescription = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ProductISBN = "WS3333333301",
                    ListofPrice = 70,
                    Price = 65,
                    ListofPrice50 = 60,
                    ListofPrice100 = 55,
                    CategoryId = 6,
                    ProductImage = ""
                },
                new Product
                {
                    ProductId = 5,
                    ProductName = "Rock in the Ocean",
                    ProductAuthor = "Ron Parker",
                    ProductDescription = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ProductISBN = "SOTJ1111111101",
                    ListofPrice = 30,
                    Price = 27,
                    ListofPrice50 = 25,
                    ListofPrice100 = 20,
                    CategoryId = 3,
                    ProductImage = ""
                },
                new Product
                {
                    ProductId = 6,
                    ProductName = "Leaves and Wonders",
                    ProductAuthor = "Laura Phantom",
                    ProductDescription = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ProductISBN = "FOT000000001",
                    ListofPrice = 25,
                    Price = 23,
                    ListofPrice50 = 22,
                    ListofPrice100 = 20,
                    CategoryId = 2,
                    ProductImage = ""
                }
                );
        }

    }
}

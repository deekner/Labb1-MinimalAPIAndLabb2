global using Microsoft.EntityFrameworkCore;
using Labb1_MinimalAPI.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Labb1_MinimalAPI.Data
{
    public class BooksDbContext:DbContext
    {
        public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options)
        {
            
        }

        public DbSet<Book> books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "A Game of Thrones",
                    Author = "George R. R. Martin",
                    Description = "A Game of Thrones is the first novel in A Song of Ice and Fire",
                    Genre = "Political Fiction",
                    Year = "1996",
                    isAvailable = true
                },
                new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "A Clash of Kings",
                    Author = "George R. R. Martin",
                    Description = "A Clash of Kings is the second of seven planned novels in A Song of Ice and Fire",
                    Genre = "Political Fiction",
                    Year = "1998",
                    isAvailable = true
                },
                new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "A Storm of Swords",
                    Author = "George R. R. Martin",
                    Description = "A Storm of Swords is the third of seven planned novels in A Song of Ice and Fire",
                    Genre = "Political Fiction",
                    Year = "2000",
                    isAvailable = false
                });

        }
    }
}

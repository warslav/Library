using Library.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(builder => 
            {
                builder.HasKey(x => x.Id);
                builder.HasIndex(x => x.Id).IsUnique();
                builder.Property(x => x.Title).IsRequired();
                builder.Property(x => x.Cover).IsRequired();
                builder.Property(x => x.Author).IsRequired();

                builder.HasMany(book => book.Reviews).WithOne(review => review.Book).OnDelete(DeleteBehavior.Cascade);
                builder.HasMany(book => book.Ratings).WithOne(rating => rating.Book).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Rating>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.HasIndex(x => x.Id).IsUnique();
                builder.Property(x => x.Score).IsRequired();

                builder.HasOne(review => review.Book).WithMany(book => book.Ratings).HasForeignKey(review => review.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Review>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.HasIndex(x => x.Id).IsUnique();
                builder.Property(x => x.Message).IsRequired();
                builder.Property(x => x.Reviewer).IsRequired();

                builder.HasOne(review => review.Book).WithMany(book => book.Reviews).HasForeignKey(review => review.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            SeedData seedData = new SeedData();
            modelBuilder.Entity<Book>().HasData(seedData.Books);
            modelBuilder.Entity<Rating>().HasData(seedData.Ratings);
            modelBuilder.Entity<Review>().HasData(seedData.Reviews);

            base.OnModelCreating(modelBuilder);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookStore.Models;

namespace BookStore.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext (DbContextOptions<BookStoreContext> options)
            : base(options)
        {
        }

        public DbSet<BookStore.Models.Author> Author { get; set; } = default!;

        public DbSet<BookStore.Models.Book>? Book { get; set; }

        public DbSet<BookStore.Models.BookGenre>? BookGenre { get; set; }

        public DbSet<BookStore.Models.Genre>? Genre { get; set; }

        public DbSet<BookStore.Models.Review>? Review { get; set; }

        public DbSet<BookStore.Models.UserBooks>? UserBooks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(b => b.Books)
                .HasForeignKey(b => b.AuthorId);
            modelBuilder.Entity<UserBooks>()
                .HasOne(ub => ub.Book)
                .WithMany(ub => ub.UserBooks)
                .HasForeignKey(ub => ub.BookId);
            modelBuilder.Entity<Review>()
                .HasOne(rv => rv.Book)
                .WithMany(rv => rv.Reviews)
                .HasForeignKey(rv => rv.BookId);
            modelBuilder.Entity<BookGenre>()
                .HasOne(bg => bg.Book)
                .WithMany(bg => bg.BookGenres)
                .HasForeignKey(bg => bg.BookId);
            modelBuilder.Entity<BookGenre>()
                .HasOne(bg => bg.Genre)
                .WithMany(bg => bg.BookGenres)
                .HasForeignKey(bg => bg.BookId);


        }
    }
}

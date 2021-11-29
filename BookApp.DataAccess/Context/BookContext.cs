using BookApp.DataAccess.Configuration;
using BookApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookApp.DataAccess.Context
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server = DESKTOP-R8THRJK;database = Bookdb; integrated security = true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());

            modelBuilder.Entity<BookGenre>().HasKey(c => new { c.GenreId, c.BookId }); //1-1 1-1 
        }
    }
}

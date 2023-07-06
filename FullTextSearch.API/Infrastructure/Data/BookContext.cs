using FullTextSearch.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Reflection.Emit;

namespace FullTextSearch.API.Infrastructure.Data
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
        }

        public DbSet<Book> Book { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
               new Book
               {
                   Id = Guid.NewGuid(),
                   Name = "Tôi tài giỏi, bạn cũng thế!",
                   Description = "Đây là một cuốn sách hay."
               },
               new Book
               {
                   Id = Guid.NewGuid(),
                   Name = "Thép đã tôi thế đấy!",
                   Description = "Một cuốn sách xuất sác."
               },
               new Book
               {
                   Id = Guid.NewGuid(),
                   Name = "Chủ nghĩa khắc kỷ",
                   Description = "Nói về triết học khắc kỷ"
               },
               new Book
               {
                   Id = Guid.NewGuid(),
                   Name = "Cuốn theo chiều gió",
                   Description = "Sách tình cảm"
               }
               );
        }
    }
}

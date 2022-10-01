using System.Collections.ObjectModel;
using Bookify.Extensions;
using Bookify.Models;
using Bookify.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<BookSoldCopies> BookSoldCopies { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<BookOrder> BookOrder { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.SeedData();
            modelBuilder.SeedIdentityData();
            modelBuilder.Entity<Book>().HasMany(x => x.Order)
                .WithMany(x => x.Books)
                .UsingEntity<BookOrder>(
                    x => x.HasOne(x => x.Order)
                        .WithMany().HasForeignKey(x => x.OrderId),
                    x => x.HasOne(x => x.Book)
                        .WithMany().HasForeignKey(x => x.BooksId));
            modelBuilder.Entity<User>(user =>
            {
                user.HasIndex(u => u.DisplayName).IsUnique();
            });
        }
    }
}
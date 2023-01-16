using Microsoft.EntityFrameworkCore;
using ProiectMPA_1.Models;

namespace ProiectMPA_1.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Book> Books { get; set; }
        //public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<PublishedBook> PublishedBooks { get; set; }

        // The code in the OnModelCreating method of the DbContext class uses the fluent API to configure EF behavior.
        // The API is called "fluent" because it's often used by stringing a series of method calls together into a single statement
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()?.ToTable("Customer");
            modelBuilder.Entity<Order>()?.ToTable("Order");
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<Author>().ToTable("Author");
            modelBuilder.Entity<Publisher>().ToTable("Publisher");
            modelBuilder.Entity<PublishedBook>().ToTable("PublishedBook");
            // Configureaza cheia primara compusa
            modelBuilder.Entity<PublishedBook>().HasKey(c => new { c.BookID, c.PublisherID });
        }
        public DbSet<Author> Authors { get; set; }
    }
}

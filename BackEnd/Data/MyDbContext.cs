using BackEnd.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Data;
public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        // User
        builder.Entity<User>(e => e.ToTable("User"));
        
        // Category
        builder.Entity<Category>(e=>e.ToTable("Category"));

        var data = new List<Category>
        {
            new Category{Id = 1, Name = "Novel"},
            new Category{Id = 2, Name = "Fantasy"},
            new Category{Id = 3, Name = "Comic"},
            new Category{Id = 4, Name = "Poem"},
            new Category{Id = 5, Name = "Textbook"},
        };
        builder.Entity<Category>().HasData(data);
        
        // Book
        builder.Entity<Book>(e=>e.ToTable("Book"));
        builder.Entity<Book>()
        .HasOne(b=>b.Category)
        .WithMany(c=>c.Books)
        .HasForeignKey(b=>b.CategoryId)
        .IsRequired();

        // BookBorrowingRequest
         builder.Entity<BookBorrowingRequest>(e=>e.ToTable("BookBorrowingRequest"));
         builder.Entity<BookBorrowingRequest>()
        .HasOne(b=>b.RequestedBy)
        .WithMany(c=>c.BookBorrowingRequests)
        .HasForeignKey(b=>b.RequestedByUserId)
        .OnDelete(DeleteBehavior.Restrict)
        .IsRequired();

        builder.Entity<BookBorrowingRequest>()
        .HasOne(b=>b.ProcessedBy)
        .WithMany(c=>c.ProssedRequests)
        .HasForeignKey(b=>b.ProcessedByUserId)
        .OnDelete(DeleteBehavior.SetNull)
        .IsRequired(false);

        // BookBorrowingRequestDetails
        builder.Entity<BookBorrowingRequestDetails>(e=>e.ToTable("BookBorrowingRequestDetail"));
        builder.Entity<BookBorrowingRequestDetails>().HasKey(d=>new {d.BookBorrowingRequestId, d.BookId});

         builder.Entity<BookBorrowingRequestDetails>()
        .HasOne(b=>b.BookBorrowingRequest)
        .WithMany(c=>c.Details)
        .HasForeignKey(b=>b.BookBorrowingRequestId)
        .IsRequired();

        builder.Entity<BookBorrowingRequestDetails>()
        .HasOne(b=>b.Book)
        .WithMany(c=>c.Details)
        .HasForeignKey(b=>b.BookId)
        .IsRequired();
        
    }
}
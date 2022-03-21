using System.ComponentModel.DataAnnotations;

namespace BackEnd.Data.Entities;
public class BookBorrowingRequestDetails
{
    [Required]
    public int BookBorrowingRequestId { get; set; }
    public virtual BookBorrowingRequest? BookBorrowingRequest { get; set; }
    [Required]
    public int BookId { get; set; }
    public virtual Book? Book { get; set; }
}
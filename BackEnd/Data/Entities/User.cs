using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BackEnd.Data.Entities;

public class User : BaseEntity
{
    // [Key]
    // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Required, MaxLength(50)]
    public string? UserName { get; set; }

    public byte[]? Password { get; set; }

    [Required, MaxLength(50)]
    public string? Email { get; set; }

    [Required, MaxLength(50)]
    public string? FullName { get; set; }

    public bool? IsSuperUser { get; set; }

    public ICollection<BookBorrowingRequest>? BookBorrowingRequests { get; set; }
    public ICollection<BookBorrowingRequest>? ProssedRequests { get; set; }

}
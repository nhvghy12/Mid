
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BackEnd.Data.Entities;

public class Book : BaseEntity
{
    [Required, MaxLength(50)]
    public string? Name { get; set; }

    public string? Author { get; set; }

    public string? Summary { get; set; }
    [Required]
    public int CategoryId { get; set; }

    [JsonIgnore]
    public virtual Category? Category { get; set; }
     public ICollection<BookBorrowingRequestDetails>? Details { get; set; }
     

}
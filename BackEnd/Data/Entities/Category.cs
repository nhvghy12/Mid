
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Data.Entities;

public class Category : BaseEntity
{
    [Required, MaxLength(50)]
    public string? Name { get; set; }
    public ICollection<Book>? Books { get; set; }
}
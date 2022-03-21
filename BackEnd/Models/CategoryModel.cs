using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models;
public class CategoryViewModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public IEnumerable<BookViewModel>? Books { get; set; }
}
public class CategoryCreateModel
{
    [Required, MaxLength(50)]
    public string? Name { get; set; }
    public IEnumerable<BookCreateModel>? Books { get; set; }
}
public class CategoryEditModel : CategoryCreateModel
{
    public int Id { get; set; }
}
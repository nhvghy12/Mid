using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using BackEnd.Data.Entities;

namespace BackEnd.Models;
public class BookViewModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Author { get; set; }
    public string? Summary { get; set; }
    [Required]
    public int? CategoryId { get; set; }
    [JsonIgnore]
    public virtual Category? Category{get;set;}
}
public class BookCreateModel
{
    [Required, MaxLength(50)]
    public string? Name { get; set; }
    [Required, MaxLength(50)]
    public string? Author { get; set; }
    public string? Summary { get; set; }
    public int? CategoryId { get; set; }
}
public class BookEditModel : BookCreateModel
{
    public int Id { get; set; }
}
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Data.Entities;
public class BookBorrowingRequest : BaseEntity
{
    [Required]
    public int RequestedByUserId { get; set; }
    public virtual User? RequestedBy { get; set; }
    public int? ProcessedByUserId { get; set; }
    public virtual User? ProcessedBy { get; set; }

    [Required, DefaultValue(RequestStatus.Waiting)]
    public RequestStatus Status { get; set; }
    public DateTime DateRequested { get; set; }
    public ICollection<BookBorrowingRequestDetails>? Details { get; set; }
}
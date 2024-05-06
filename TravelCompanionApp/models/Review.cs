using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelCompanionApp.models;

public class Review
{
    [Key]
    public long Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public double? Stars { get; set; }
    
    public User? Creator { get; set; }
    public Guid? CreatorId { get; set; }

    public User? User { get; set; }
    public Guid UserId { get; set; }

    public DateTime? CreationDate { get; set; }
}
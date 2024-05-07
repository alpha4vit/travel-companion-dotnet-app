using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelCompanionApp.models;

[Table("reviews")]
public class Review
{
    [Key]
    [Column("id")]
    public long Id { get; set; }
    [Column("title")]
    public string? Title { get; set; }
    [Column("description")]
    public string? Description { get; set; }
    [Column("stars")]
    public double? Stars { get; set; }
    
    public User? Creator { get; set; }
    [Column("creator_id")]
    public Guid? CreatorId { get; set; }

    public User? User { get; set; }
    [Column("user_id")]
    public Guid UserId { get; set; }

    [Column("creation_date")]
    public DateTime? CreationDate { get; set; }
}
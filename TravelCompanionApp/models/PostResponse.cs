using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelCompanionApp.models;
[Table("responses")]
public class PostResponse
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("comment")]
    public string? Comment { get; set; }

    [Column("contact")]
    public string? Contact { get; set; }
    
    public Post? Post { get; set; }
    [Column("post_id")]
    public Guid? PostId { get; set; }
    
    public User? User { get; set; }
    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("creation_date")]
    public DateTime? CreationDate { get; set; }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelCompanionApp.models;

public class PostResponse
{
    [Key]
    public long Id { get; set; }

    public string? Comment { get; set; }

    public string? Contact { get; set; }
    
    public Post? Post { get; set; }
    public Guid? PostId { get; set; }
    
    public User? User { get; set; }
    public Guid? UserId { get; set; }

    public DateTime? CreationDate { get; set; }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelCompanionApp.models;

public class Post
{
    [Key]
    public Guid Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Fee { get; set; }
    
    public DateTime DateThere { get; set; }

    public DateTime DateBack { get; set; }

    public PostType Type { get; set; }
    public Guid UserId { get; set; }
    
    public User User { get; set; }
    
    public DateTime CreationDate { get; set; }
    
    public long RouteId { get; set; }
    public Route Route { get; set; }
    public List<PostResponse> Responses { get; set; } = new List<PostResponse>();
}
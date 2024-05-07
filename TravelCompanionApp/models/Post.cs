using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelCompanionApp.models;

[Table("posts")]
public class Post
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("title")]
    public string? Title { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("fee")]
    public string? Fee { get; set; }
    
    [Column("date_there")]
    public DateTime DateThere { get; set; }

    [Column("date_back")]
    public DateTime DateBack { get; set; }

    [EnumDataType(typeof(PostType))]
    [Column("post_type")]
    public PostType Type { get; set; }
    
    [Column("user_id")]
    public Guid UserId { get; set; }
    
    public User User { get; set; }
    
    [Column("creation_date")]
    public DateTime CreationDate { get; set; }
    
    [Column("route_id")]
    public long RouteId { get; set; }
    public Route Route { get; set; }
    public List<PostResponse> Responses { get; set; } = new List<PostResponse>();
}
using System.Text.Json.Serialization;

namespace TravelCompanionApp.dto;

public class ReviewDTO
{
    [JsonPropertyName("id")]
    public long Id { get; set; }
    [JsonPropertyName("title")]
    public string? Title { get; set; }
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    [JsonPropertyName("stars")]
    public double? Stars { get; set; }
    [JsonPropertyName("creator")]
    public UserDTO? Creator { get; set; }
    [JsonPropertyName("creator_id")]
    public Guid? CreatorId { get; set; }
    [JsonPropertyName("user")]
    public UserDTO? User { get; set; }
    [JsonPropertyName("user_id")]
    public Guid? UserId { get; set; }
    [JsonPropertyName("creation_date")]
    public DateTime? CreationDate { get; set; }
}
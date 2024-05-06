using System.Text.Json.Serialization;
using TravelCompanionApp.models;
using Route = TravelCompanionApp.models.Route;

namespace TravelCompanionApp.dto;

public class PostDTO
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("fee")]
    public string? Fee { get; set; }
    
    [JsonPropertyName("date_there")]
    public DateTime? DateThere { get; set; }

    [JsonPropertyName("date_back")]
    public DateTime? DateBack { get; set; }

    [JsonPropertyName("type")]
    public PostType? Type { get; set; }
    
    [JsonPropertyName("user_id")]
    public Guid? UserId { get; set; }
    
    [JsonPropertyName("user")]
    public UserDTO? User { get; set; }
    
    [JsonPropertyName("creation_date")]
    public DateTime? CreationDate { get; set; }
    
    [JsonPropertyName("route_id")]
    public long? RouteId { get; set; }
    
    [JsonPropertyName("route")]
    public RouteDTO? Route { get; set; }
    
    [JsonPropertyName("responses_count")]
    public long? ResponsesCount { get; set; }
}
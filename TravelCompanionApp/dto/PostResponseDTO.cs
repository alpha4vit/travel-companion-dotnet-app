using System.Text.Json.Serialization;

namespace TravelCompanionApp.dto;

public class PostResponseDTO
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }
    [JsonPropertyName("contact")]
    public string? Contact { get; set; }
    [JsonPropertyName("comment")]
    public string? Comment { get; set; }
    [JsonPropertyName("post")]
    public PostDTO? Post { get; set; }
    [JsonPropertyName("user")]
    public UserDTO? User { get; set; }
    [JsonPropertyName("creation_date")]
    public string? CreationDate { get; set; }
}
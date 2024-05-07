using System.Text.Json.Serialization;

namespace TravelCompanionApp.dto;

public class AddressDTO
{
    [JsonPropertyName("id")]
    public long Id { get; set; }
    [JsonPropertyName("text")]
    public string? Text { get; set; }
    [JsonPropertyName("longitude")]
    public double? Longitude { get; set; }
    [JsonPropertyName("latitude")]
    public double? Latitude { get; set; }
}
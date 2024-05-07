using System.Text.Json.Serialization;

namespace TravelCompanionApp.dto;

public class RouteDTO
{
    [JsonPropertyName("id")]
    public long Id { get; set; }
    [JsonPropertyName("departure")]
    public AddressDTO Departure { get; set; }
    [JsonPropertyName("destination")]
    public AddressDTO Destination { get; set; }

}
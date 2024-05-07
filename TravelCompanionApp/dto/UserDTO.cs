using System.Text.Json.Serialization;

namespace TravelCompanionApp.dto;

public class UserDTO
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    [JsonPropertyName("username")]
    public string? Username { get; set; }
    [JsonPropertyName("email")]
    public string? Email { get; set; }
    [JsonPropertyName("password")]
    public string? Password { get; set; }
    [JsonPropertyName("bio")]
    public string? Bio { get; set; }
    [JsonPropertyName("avatar")]
    public string? Avatar { get; set; }
    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; set; }
    [JsonPropertyName("is_email_verified")]
    public bool IsEmailVerified { get; set; }
    [JsonPropertyName("confirmation_code")]
    public string? ConfirmationCode { get; set; }
    [JsonPropertyName("rating")]
    public double Rating { get; set; }
}
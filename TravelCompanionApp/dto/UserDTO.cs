namespace TravelCompanionApp.dto;

public class UserDTO
{
    public Guid Id { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Bio { get; set; }

    public string? Avatar { get; set; }
    
    public string? PhoneNumber { get; set; }

    public bool IsEmailVerified { get; set; }

    public string? ConfirmationCode { get; set; }

    public double Rating { get; set; }
}
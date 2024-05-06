using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelCompanionApp.models;

public class User
{
    [Key]
    public Guid Id { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Bio { get; set; }

    public string? Avatar { get; set; }
    
    public string? PhoneNumber { get; set; }

    public bool IsEmailVerified { get; set; }

    public string? ConfirmationCode { get; set; }

    public ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();

    public ICollection<Post> Posts { get; set; }
    
    public ICollection<Review> Reviews { get; set; }
    
    public ICollection<Review> CreatedReviews { get; set; }
    
    public ICollection<PostResponse> PostResponses { get; set; }

    public double Rating { get; set; }
}
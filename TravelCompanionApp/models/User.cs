using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelCompanionApp.models;

[Table("users")]
public class User
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }
    [Column("username")]

    public string? Username { get; set; }
    [Column("email")]
    public string? Email { get; set; }
    [Column("password")]
    public string? Password { get; set; }
    [Column("bio")]
    public string? Bio { get; set; }
    [Column("avatar")]
    public string? Avatar { get; set; }
    [Column("phone_number")]
    public string? PhoneNumber { get; set; }
    [Column("is_email_verified")]
    public bool IsEmailVerified { get; set; }
    [Column("confirmation_code")]
    public string? ConfirmationCode { get; set; }

    public ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();

    public ICollection<Post> Posts { get; set; }
    
    public ICollection<Review> Reviews { get; set; }
    
    public ICollection<Review> CreatedReviews { get; set; }
    
    public ICollection<PostResponse> PostResponses { get; set; }

    [Column("rating")]
    public double Rating { get; set; }
}
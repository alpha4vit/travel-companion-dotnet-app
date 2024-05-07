using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelCompanionApp.models;

[Table("users_roles")]
public class UserRole
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    public User User { get; set; }
    [Column("user_id")]
    public Guid UserId { get; set; }

    [Column("role")]
    [EnumDataType(typeof(Role))]
    public Role Role { get; set; }
}
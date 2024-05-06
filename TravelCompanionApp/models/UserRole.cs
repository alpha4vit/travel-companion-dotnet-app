using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelCompanionApp.models;

public class UserRole
{
    [Key]
    public Guid Id { get; set; }

    public User User { get; set; }
    public Guid UserId { get; set; }

    [EnumDataType(typeof(Role))]
    public Role Role { get; set; }
}
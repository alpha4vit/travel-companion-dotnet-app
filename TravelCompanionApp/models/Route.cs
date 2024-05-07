using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelCompanionApp.models;

[Table("routes")]
public class Route
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public long Id { get; set; }
    
    public Address Departure { get; set; }
    [Column("departure_id")]

    public long DepartureId { get; set; }

    public Address Destination { get; set; }
    [Column("destination_id")]
    public long DestinationId { get; set; }

    public ICollection<Post> Posts;

}
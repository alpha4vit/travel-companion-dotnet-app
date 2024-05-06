using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelCompanionApp.models;

public class Route
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    
    public Address Departure { get; set; }
    public long DepartureId { get; set; }

    public Address Destination { get; set; }
    public long DestinationId { get; set; }

    public ICollection<Post> Posts;

}
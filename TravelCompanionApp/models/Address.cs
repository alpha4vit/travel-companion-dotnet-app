using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelCompanionApp.models;

public class Address
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string Text { get; set; }
    public string Longitude { get; set; }
    public string Latitude { get; set; }
    public ICollection<Route> Destinations;
    public ICollection<Route> Departures;
    
}
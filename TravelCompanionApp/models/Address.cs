using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelCompanionApp.models;

[Table("addresses")]
public class Address
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public long Id { get; set; }
    [Column("text")]
    public string Text { get; set; }
    [Column("longitude")]
    public string Longitude { get; set; }
    [Column("latitude")]
    public string Latitude { get; set; }
    public ICollection<Route> Destinations;
    public ICollection<Route> Departures;
    
}
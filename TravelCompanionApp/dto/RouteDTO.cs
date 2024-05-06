namespace TravelCompanionApp.dto;

public class RouteDTO
{
    public long Id { get; set; }
    
    public AddressDTO Departure { get; set; }

    public AddressDTO Destination { get; set; }

}
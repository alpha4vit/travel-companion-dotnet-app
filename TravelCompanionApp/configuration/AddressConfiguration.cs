using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelCompanionApp.models;

namespace TravelCompanionApp.configuration;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasMany(a => a.Destinations)
            .WithOne(r => r.Destination)
            .HasForeignKey(r => r.DestinationId);
        builder.HasMany(a => a.Departures)
            .WithOne(r => r.Departure)
            .HasForeignKey(r => r.DepartureId);
    }
}
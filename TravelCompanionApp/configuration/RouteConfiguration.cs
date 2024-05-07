using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelCompanionApp.models;

namespace TravelCompanionApp.configuration;

public class RouteConfiguration : IEntityTypeConfiguration<models.Route>
{
    public void Configure(EntityTypeBuilder<models.Route> builder)
    {
        builder.HasMany(r => r.Posts)
            .WithOne(p => p.Route)
            .HasForeignKey(p => p.RouteId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(r => r.Departure)
            .WithMany(a => a.Departures)
            .HasForeignKey(r => r.DepartureId);
        builder.Navigation(r => r.Departure).AutoInclude();
        builder.HasOne(r => r.Destination)
            .WithMany(a => a.Destinations)
            .HasForeignKey(r => r.DestinationId);
        builder.Navigation(r => r.Destination).AutoInclude();
    }
}
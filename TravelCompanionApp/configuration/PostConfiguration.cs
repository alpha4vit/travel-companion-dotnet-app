using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelCompanionApp.converters;
using TravelCompanionApp.models;

namespace TravelCompanionApp.configuration;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasOne(p => p.User)
            .WithMany(u => u.Posts)
            .HasForeignKey(p => p.UserId);
        builder.Navigation(p => p.User).AutoInclude();
        builder.HasOne(p => p.Route)
            .WithMany(r => r.Posts)
            .HasForeignKey(r => r.RouteId);
        builder.Navigation(p => p.Route).AutoInclude();
        builder.HasMany(p => p.Responses)
            .WithOne(pr => pr.Post)
            .HasForeignKey(pr => pr.PostId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Property(p => p.Type)
            .HasConversion(new PostTypeConverter());
    }
}
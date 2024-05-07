using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelCompanionApp.models;

namespace TravelCompanionApp.configuration;

public class PostResponseConfiguration : IEntityTypeConfiguration<PostResponse>
{
    public void Configure(EntityTypeBuilder<PostResponse> builder)
    {
        builder.HasOne(pr => pr.Post)
            .WithMany(p => p.Responses)
            .HasForeignKey(pr => pr.PostId);
        builder.Navigation(pr => pr.Post).AutoInclude();
        builder.HasOne(pr => pr.User)
            .WithMany(u => u.PostResponses)
            .HasForeignKey(pr => pr.UserId);
        builder.Navigation(pr => pr.User).AutoInclude();
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelCompanionApp.models;

namespace TravelCompanionApp.configuration;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasOne(r => r.User)
            .WithMany(u => u.Reviews)
            .HasForeignKey(r => r.UserId);
        builder.HasOne(r => r.Creator)
            .WithMany(u => u.CreatedReviews)
            .HasForeignKey(r => r.CreatorId);
    }
}
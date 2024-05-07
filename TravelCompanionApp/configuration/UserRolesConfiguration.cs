using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelCompanionApp.converters;
using TravelCompanionApp.models;

namespace TravelCompanionApp.configuration;

public class UserRolesConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasOne(ur => ur.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(ur => ur.UserId);
        builder.Property(ur => ur.Role)
            .HasConversion(new UserRoleConverter());
        builder.Navigation(u => u.User).AutoInclude();
    }
}
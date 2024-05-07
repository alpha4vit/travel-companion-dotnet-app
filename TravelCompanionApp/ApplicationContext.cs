using Microsoft.EntityFrameworkCore;
using TravelCompanionApp.models;
using Post = TravelCompanionApp.models.Post;

namespace TravelCompanionApp;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<PostResponse> PostResponses { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<models.Route> Routes { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public ApplicationContext()
    {
        // Database.EnsureCreated();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
    }
}
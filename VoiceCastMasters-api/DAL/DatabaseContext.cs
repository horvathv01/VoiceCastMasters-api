using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using VoiceCastMasters_api.Model;

namespace VoiceCastMasters_api.DAL;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> contextOptions) : base(contextOptions)
    {
    }
    public DbSet<Actor> Actors { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actor>()
            .ToTable("Actors")
            .HasKey(a => a.ID);
    }
}

public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
{
    public DatabaseContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
        optionsBuilder.UseNpgsql("Host=34.88.126.174; Database=voice-cast-masters; Username=postgres; Password=VoiceOfVili");

        return new DatabaseContext(optionsBuilder.Options);
    }

}
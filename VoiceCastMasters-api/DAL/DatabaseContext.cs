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
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Actor>()
            .HasKey(a => a.ID);
        
        modelBuilder.Entity<Relation>()
            .HasKey(ar => ar.Id);
        
        modelBuilder.Entity<Relation>()
            .HasOne(ar => ar.Actor1)
            .WithMany()
            .HasForeignKey(ar => ar.Actor1Id)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Relation>()
            .HasOne(ar => ar.Actor2)
            .WithMany()
            .HasForeignKey(ar => ar.Actor2Id)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

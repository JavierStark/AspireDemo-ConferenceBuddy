using Microsoft.EntityFrameworkCore;
using SessionsApi.Models;

namespace SessionsApi.Data;

public class ConferenceDbContext(DbContextOptions<ConferenceDbContext> options) : DbContext(options)
{
    public DbSet<Session> Sessions => Set<Session>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).HasMaxLength(200);
            entity.Property(e => e.SpeakerName).HasMaxLength(100);
            entity.Property(e => e.Room).HasMaxLength(50);
        });
    }
}

namespace Mizon.Database.Configurations;

internal static class FollowingActivityConfiguration
{
    public static void Configure(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MusicComment>()
            .HasIndex(x => new { x.ClientId, x.CreateDateTime, x.Id })
            .IsDescending(false, true, true);
        modelBuilder.Entity<MusicLike>()
            .HasIndex(x => new { x.ClientId, x.CreateDateTime, x.Id })
            .IsDescending(false, true, true);
        modelBuilder.Entity<MusicReaction>()
            .HasIndex(x => new { x.ClientId, x.CreateDateTime, x.Id })
            .IsDescending(false, true, true);
        modelBuilder.Entity<MusicPlaylist>()
            .HasIndex(x => new { x.ClientId, x.CreateDateTime, x.Id })
            .IsDescending(false, true, true);
    }
}

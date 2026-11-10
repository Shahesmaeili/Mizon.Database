namespace Mizon.Database.Configurations;

internal sealed class MusicPlaylistMusicConfiguration : IEntityTypeConfiguration<MusicPlaylistMusic>
{
    public void Configure(EntityTypeBuilder<MusicPlaylistMusic> builder)
    {
        builder.HasOne(x => x.MusicPlaylist)
            .WithMany(x => x.MusicPlaylistMusics)
            .HasForeignKey(x => x.MusicPlaylistId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Music)
            .WithMany(x => x.MusicPlaylistMusics)
            .HasForeignKey(x => x.MusicId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new { x.MusicPlaylistId, x.MusicId })
            .IsUnique();
        builder.HasIndex(x => new { x.MusicPlaylistId, x.Id });
    }
}

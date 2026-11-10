namespace Mizon.Database.Configurations;

internal sealed class MusicPlaylistConfiguration : IEntityTypeConfiguration<MusicPlaylist>
{
    public void Configure(EntityTypeBuilder<MusicPlaylist> builder)
    {
        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(60);

        builder.HasOne(x => x.Client)
            .WithMany(x => x.MusicPlaylists)
            .HasForeignKey(x => x.ClientId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new { x.ClientId, x.Id });

        builder.Property(x => x.LastActivityDateTime)
            .HasComputedColumnSql("COALESCE([UpdateDateTime], [CreateDateTime])", stored: true);

        builder.HasIndex(x => new { x.ClientId, x.LastActivityDateTime, x.Id })
            .IsDescending(false, true, true)
            .IncludeProperties(x => new { x.PublicId, x.Title });
    }
}

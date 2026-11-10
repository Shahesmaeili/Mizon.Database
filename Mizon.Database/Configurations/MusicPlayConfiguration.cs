namespace Mizon.Database.Configurations;

internal sealed class MusicPlayConfiguration : IEntityTypeConfiguration<MusicPlay>
{
    public void Configure(EntityTypeBuilder<MusicPlay> builder)
    {
        builder.HasOne(x => x.Client)
            .WithMany(x => x.MusicPlays)
            .HasForeignKey(x => x.ClientId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Music)
            .WithMany(x => x.MusicPlays)
            .HasForeignKey(x => x.MusicId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.PlatformVersion)
            .WithMany(x => x.MusicPlays)
            .HasForeignKey(x => x.PlatformVersionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new { x.ClientId, x.PlaybackPublicId }).IsUnique();
        builder.HasIndex(x => new { x.ClientId, x.CreateDateTime, x.Id })
            .IsDescending(false, true, true);
    }
}

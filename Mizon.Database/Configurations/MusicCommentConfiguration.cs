namespace Mizon.Database.Configurations;

internal sealed class MusicCommentConfiguration : IEntityTypeConfiguration<MusicComment>
{
    public void Configure(EntityTypeBuilder<MusicComment> builder)
    {
        builder.HasOne(x => x.PlatformVersion).WithMany().HasForeignKey(x => x.PlatformVersionId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.ParentMusicComment).WithMany(x => x.Replies)
            .HasForeignKey(x => new { x.MusicId, x.ParentMusicCommentId })
            .HasPrincipalKey(x => new { x.MusicId, x.Id })
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasIndex(x => new { x.MusicId, x.ParentMusicCommentId, x.Id });
        builder.HasIndex(x => new { x.MusicId, x.Timestamp, x.Id });
    }
}

namespace Mizon.Database.Configurations;

internal sealed class MusicFeatureConfiguration : IEntityTypeConfiguration<MusicFeature>
{
    public void Configure(EntityTypeBuilder<MusicFeature> builder)
    {
        builder.HasIndex(x => new { x.IsActive, x.Id }).IsDescending(false, true);
        builder.HasOne(x => x.Music).WithMany(x => x.MusicFeatures).HasForeignKey(x => x.MusicId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.ContentMedia).WithMany(x => x.ContentMusicFeatures).HasForeignKey(x => x.ContentMediaId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.PreviewMedia).WithMany(x => x.PreviewMusicFeatures).HasForeignKey(x => x.PreviewMediaId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.MusicFeatureContentType).WithMany(x => x.MusicFeatures).HasForeignKey(x => x.MusicFeatureContentTypeId).OnDelete(DeleteBehavior.Restrict);
    }
}

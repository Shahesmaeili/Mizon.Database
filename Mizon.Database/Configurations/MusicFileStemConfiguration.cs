namespace Mizon.Database.Configurations;

internal sealed class MusicFileStemConfiguration : IEntityTypeConfiguration<MusicFileStem>
{
    public void Configure(EntityTypeBuilder<MusicFileStem> builder)
    {
        builder.HasOne(item => item.MusicFile).WithMany(item => item.MusicFileStems).HasForeignKey(item => item.MusicFileId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(item => item.MusicFileStemType).WithMany(item => item.MusicFileStems).HasForeignKey(item => item.MusicFileStemTypeId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(item => item.Media).WithMany().HasForeignKey(item => item.MediaId).OnDelete(DeleteBehavior.Restrict);
        builder.HasIndex(item => new { item.MusicFileId, item.MusicFileStemTypeId }).IsUnique();
    }
}

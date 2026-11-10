namespace Mizon.Database.Configurations;

internal sealed class MusicFileQualityConfiguration : IEntityTypeConfiguration<MusicFileQuality>
{
    public void Configure(EntityTypeBuilder<MusicFileQuality> builder)
    {
        builder.HasKey(item => item.Id);
        builder.Property(item => item.BitrateKbps).IsRequired(false);
        builder.HasIndex(item => item.MusicFileId).IsUnique();

        builder.HasOne(item => item.MusicFile).WithOne(item => item.MusicFileQuality)
            .HasForeignKey<MusicFileQuality>(item => item.MusicFileId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(item => item.MusicFileQualityChannel).WithMany(item => item.MusicFileQualities)
            .HasForeignKey(item => item.MusicFileQualityChannelId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(item => item.MusicFileQualityCodec).WithMany(item => item.MusicFileQualities)
            .HasForeignKey(item => item.MusicFileQualityCodecId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(item => item.MusicFileQualityFormat).WithMany(item => item.MusicFileQualities)
            .HasForeignKey(item => item.MusicFileQualityFormatId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(item => item.MusicFileQualityBitDepth).WithMany(item => item.MusicFileQualities)
            .HasForeignKey(item => item.MusicFileQualityBitDepthId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(item => item.MusicFileQualitySampleFormat).WithMany(item => item.MusicFileQualities)
            .HasForeignKey(item => item.MusicFileQualitySampleFormatId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(item => item.MusicFileQualityEncoder).WithMany(item => item.MusicFileQualities)
            .HasForeignKey(item => item.MusicFileQualityEncoderId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(item => item.MusicFileQualityEncoderMode).WithMany(item => item.MusicFileQualities)
            .HasForeignKey(item => item.MusicFileQualityEncoderModeId).OnDelete(DeleteBehavior.Restrict);
    }
}

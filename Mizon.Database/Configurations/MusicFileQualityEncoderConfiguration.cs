namespace Mizon.Database.Configurations;

internal sealed class MusicFileQualityEncoderConfiguration : IEntityTypeConfiguration<MusicFileQualityEncoder>
{
    public void Configure(EntityTypeBuilder<MusicFileQualityEncoder> builder)
    {
        builder.HasKey(item => item.Id);
        builder.Property(item => item.Id).ValueGeneratedNever();
        builder.Property(item => item.Title).IsRequired().HasMaxLength(64);
        builder.HasData(
            new MusicFileQualityEncoder { Id = 1, PublicId = Guid.Parse("b7bdc105-0000-4000-8000-000000000001"), Title = "LAME" },
            new MusicFileQualityEncoder { Id = 2, PublicId = Guid.Parse("b7bdc105-0000-4000-8000-000000000002"), Title = "FFmpeg" },
            new MusicFileQualityEncoder { Id = 3, PublicId = Guid.Parse("b7bdc105-0000-4000-8000-000000000003"), Title = "libfdk_aac" },
            new MusicFileQualityEncoder { Id = 4, PublicId = Guid.Parse("b7bdc105-0000-4000-8000-000000000004"), Title = "libopus" },
            new MusicFileQualityEncoder { Id = 5, PublicId = Guid.Parse("b7bdc105-0000-4000-8000-000000000005"), Title = "reference flac" });
    }
}

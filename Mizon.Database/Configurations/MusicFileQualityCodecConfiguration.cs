namespace Mizon.Database.Configurations;

internal sealed class MusicFileQualityCodecConfiguration : IEntityTypeConfiguration<MusicFileQualityCodec>
{
    public void Configure(EntityTypeBuilder<MusicFileQualityCodec> builder)
    {
        builder.HasKey(item => item.Id);
        builder.Property(item => item.Id).ValueGeneratedNever();
        builder.Property(item => item.Title).IsRequired().HasMaxLength(32);
        builder.Property(item => item.PersianTitle).HasMaxLength(32);
        builder.HasData(
            new MusicFileQualityCodec { Id = 1, PublicId = Guid.Parse("b7bdc102-0000-4000-8000-000000000001"), Title = "MP3" },
            new MusicFileQualityCodec { Id = 2, PublicId = Guid.Parse("b7bdc102-0000-4000-8000-000000000002"), Title = "AAC" },
            new MusicFileQualityCodec { Id = 3, PublicId = Guid.Parse("b7bdc102-0000-4000-8000-000000000003"), Title = "FLAC" },
            new MusicFileQualityCodec { Id = 4, PublicId = Guid.Parse("b7bdc102-0000-4000-8000-000000000004"), Title = "PCM" },
            new MusicFileQualityCodec { Id = 5, PublicId = Guid.Parse("b7bdc102-0000-4000-8000-000000000005"), Title = "Opus" },
            new MusicFileQualityCodec { Id = 6, PublicId = Guid.Parse("b7bdc102-0000-4000-8000-000000000006"), Title = "Vorbis" },
            new MusicFileQualityCodec { Id = 7, PublicId = Guid.Parse("b7bdc102-0000-4000-8000-000000000007"), Title = "ALAC" });
    }
}

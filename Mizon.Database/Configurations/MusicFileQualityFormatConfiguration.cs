namespace Mizon.Database.Configurations;

internal sealed class MusicFileQualityFormatConfiguration : IEntityTypeConfiguration<MusicFileQualityFormat>
{
    public void Configure(EntityTypeBuilder<MusicFileQualityFormat> builder)
    {
        builder.HasKey(item => item.Id);
        builder.Property(item => item.Id).ValueGeneratedNever();
        builder.Property(item => item.Title).IsRequired().HasMaxLength(32);
        builder.Property(item => item.PersianTitle).HasMaxLength(32);
        builder.HasData(
            new MusicFileQualityFormat { Id = 1, PublicId = Guid.Parse("b7bdc103-0000-4000-8000-000000000001"), Title = "MP3" },
            new MusicFileQualityFormat { Id = 2, PublicId = Guid.Parse("b7bdc103-0000-4000-8000-000000000002"), Title = "MP4" },
            new MusicFileQualityFormat { Id = 3, PublicId = Guid.Parse("b7bdc103-0000-4000-8000-000000000003"), Title = "WAV" },
            new MusicFileQualityFormat { Id = 4, PublicId = Guid.Parse("b7bdc103-0000-4000-8000-000000000004"), Title = "FLAC" },
            new MusicFileQualityFormat { Id = 5, PublicId = Guid.Parse("b7bdc103-0000-4000-8000-000000000005"), Title = "Ogg" },
            new MusicFileQualityFormat { Id = 6, PublicId = Guid.Parse("b7bdc103-0000-4000-8000-000000000006"), Title = "WebM" },
            new MusicFileQualityFormat { Id = 7, PublicId = Guid.Parse("b7bdc103-0000-4000-8000-000000000007"), Title = "Matroska" });
    }
}

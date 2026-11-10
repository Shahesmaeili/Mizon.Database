namespace Mizon.Database.Configurations;

internal sealed class MusicFileQualityEncoderModeConfiguration : IEntityTypeConfiguration<MusicFileQualityEncoderMode>
{
    public void Configure(EntityTypeBuilder<MusicFileQualityEncoderMode> builder)
    {
        builder.HasKey(item => item.Id);
        builder.Property(item => item.Id).ValueGeneratedNever();
        builder.Property(item => item.Title).IsRequired().HasMaxLength(32);
        builder.HasData(
            new MusicFileQualityEncoderMode { Id = 1, PublicId = Guid.Parse("b7bdc106-0000-4000-8000-000000000001"), Title = "CBR" },
            new MusicFileQualityEncoderMode { Id = 2, PublicId = Guid.Parse("b7bdc106-0000-4000-8000-000000000002"), Title = "VBR" },
            new MusicFileQualityEncoderMode { Id = 3, PublicId = Guid.Parse("b7bdc106-0000-4000-8000-000000000003"), Title = "ABR" },
            new MusicFileQualityEncoderMode { Id = 4, PublicId = Guid.Parse("b7bdc106-0000-4000-8000-000000000004"), Title = "Lossless" });
    }
}

namespace Mizon.Database.Configurations;

internal sealed class MusicFileQualityBitDepthConfiguration : IEntityTypeConfiguration<MusicFileQualityBitDepth>
{
    public void Configure(EntityTypeBuilder<MusicFileQualityBitDepth> builder)
    {
        builder.HasKey(item => item.Id);
        builder.Property(item => item.Id).ValueGeneratedNever();
        builder.Property(item => item.Title).IsRequired().HasMaxLength(16);
        builder.HasData(
            new MusicFileQualityBitDepth { Id = 1, PublicId = Guid.Parse("b7bdc101-0000-4000-8000-000000000001"), Title = "8-bit", BitDepth = 8 },
            new MusicFileQualityBitDepth { Id = 2, PublicId = Guid.Parse("b7bdc101-0000-4000-8000-000000000002"), Title = "16-bit", BitDepth = 16 },
            new MusicFileQualityBitDepth { Id = 3, PublicId = Guid.Parse("b7bdc101-0000-4000-8000-000000000003"), Title = "24-bit", BitDepth = 24 },
            new MusicFileQualityBitDepth { Id = 4, PublicId = Guid.Parse("b7bdc101-0000-4000-8000-000000000004"), Title = "32-bit", BitDepth = 32 });
    }
}

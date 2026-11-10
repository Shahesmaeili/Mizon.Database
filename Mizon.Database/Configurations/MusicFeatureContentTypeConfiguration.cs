namespace Mizon.Database.Configurations;

internal sealed class MusicFeatureContentTypeConfiguration : IEntityTypeConfiguration<MusicFeatureContentType>
{
    public void Configure(EntityTypeBuilder<MusicFeatureContentType> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.Code).IsRequired().HasMaxLength(16);
        builder.HasIndex(x => x.Code).IsUnique();
        builder.Property(x => x.Title).IsRequired().HasMaxLength(32);
        builder.Property(x => x.PersianTitle).HasMaxLength(32);
        builder.HasData(
            new MusicFeatureContentType { Id = 1, PublicId = Guid.Parse("d829f512-1ce7-4c64-b562-133f3594f001"), Code = "image", Title = "Image", PersianTitle = "تصویر" },
            new MusicFeatureContentType { Id = 2, PublicId = Guid.Parse("d829f512-1ce7-4c64-b562-133f3594f002"), Code = "video", Title = "Video", PersianTitle = "ویدیو" });
    }
}

namespace Mizon.Database.Configurations;

internal sealed class MusicFileQualitySampleFormatConfiguration : IEntityTypeConfiguration<MusicFileQualitySampleFormat>
{
    public void Configure(EntityTypeBuilder<MusicFileQualitySampleFormat> builder)
    {
        builder.HasKey(item => item.Id);
        builder.Property(item => item.Id).ValueGeneratedNever();
        builder.Property(item => item.Title).IsRequired().HasMaxLength(32);
        builder.Property(item => item.PersianTitle).HasMaxLength(32);
        builder.HasData(
            new MusicFileQualitySampleFormat { Id = 1, PublicId = Guid.Parse("b7bdc104-0000-4000-8000-000000000001"), Title = "Unsigned 8-bit", PersianTitle = "۸ بیت بدون علامت" },
            new MusicFileQualitySampleFormat { Id = 2, PublicId = Guid.Parse("b7bdc104-0000-4000-8000-000000000002"), Title = "Signed 16-bit", PersianTitle = "۱۶ بیت علامت‌دار" },
            new MusicFileQualitySampleFormat { Id = 3, PublicId = Guid.Parse("b7bdc104-0000-4000-8000-000000000003"), Title = "Signed 24-bit", PersianTitle = "۲۴ بیت علامت‌دار" },
            new MusicFileQualitySampleFormat { Id = 4, PublicId = Guid.Parse("b7bdc104-0000-4000-8000-000000000004"), Title = "Signed 32-bit", PersianTitle = "۳۲ بیت علامت‌دار" },
            new MusicFileQualitySampleFormat { Id = 5, PublicId = Guid.Parse("b7bdc104-0000-4000-8000-000000000005"), Title = "Float 32-bit", PersianTitle = "شناور ۳۲ بیت" },
            new MusicFileQualitySampleFormat { Id = 6, PublicId = Guid.Parse("b7bdc104-0000-4000-8000-000000000006"), Title = "Float 64-bit", PersianTitle = "شناور ۶۴ بیت" });
    }
}

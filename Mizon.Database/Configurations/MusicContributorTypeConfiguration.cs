namespace Mizon.Database.Configurations;

internal sealed class MusicContributorTypeConfiguration : IEntityTypeConfiguration<MusicContributorType>
{
    public void Configure(EntityTypeBuilder<MusicContributorType> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.Title).IsRequired().HasMaxLength(32);
        builder.Property(x => x.PersianTitle).HasMaxLength(32);

        builder.HasData(
            new MusicContributorType { Id = 1, PublicId = Guid.Parse("c5fb8a20-4dc5-45a6-9111-001000000001"), Title = "LeadVocal", PersianTitle = "خواننده اصلی" },
            new MusicContributorType { Id = 2, PublicId = Guid.Parse("c5fb8a20-4dc5-45a6-9111-001000000002"), Title = "FeaturedVocal", PersianTitle = "خواننده مهمان" },
            new MusicContributorType { Id = 3, PublicId = Guid.Parse("c5fb8a20-4dc5-45a6-9111-001000000003"), Title = "Composer", PersianTitle = "آهنگساز" },
            new MusicContributorType { Id = 4, PublicId = Guid.Parse("c5fb8a20-4dc5-45a6-9111-001000000004"), Title = "Lyricist", PersianTitle = "ترانه‌سرا" },
            new MusicContributorType { Id = 5, PublicId = Guid.Parse("c5fb8a20-4dc5-45a6-9111-001000000005"), Title = "Arranger", PersianTitle = "تنظیم‌کننده" },
            new MusicContributorType { Id = 6, PublicId = Guid.Parse("c5fb8a20-4dc5-45a6-9111-001000000006"), Title = "Producer", PersianTitle = "تهیه‌کننده" },
            new MusicContributorType { Id = 7, PublicId = Guid.Parse("c5fb8a20-4dc5-45a6-9111-001000000007"), Title = "MixingEngineer", PersianTitle = "مهندس میکس" },
            new MusicContributorType { Id = 8, PublicId = Guid.Parse("c5fb8a20-4dc5-45a6-9111-001000000008"), Title = "MasteringEngineer", PersianTitle = "مهندس مسترینگ" },
            new MusicContributorType { Id = 9, PublicId = Guid.Parse("c5fb8a20-4dc5-45a6-9111-001000000009"), Title = "Instrumentalist", PersianTitle = "نوازنده" },
            new MusicContributorType { Id = 10, PublicId = Guid.Parse("c5fb8a20-4dc5-45a6-9111-001000000010"), Title = "Guitarist", PersianTitle = "گیتاریست" },
            new MusicContributorType { Id = 11, PublicId = Guid.Parse("c5fb8a20-4dc5-45a6-9111-001000000011"), Title = "RecordingEngineer", PersianTitle = "مهندس ضبط" },
            new MusicContributorType { Id = 12, PublicId = Guid.Parse("c5fb8a20-4dc5-45a6-9111-001000000012"), Title = "Director", PersianTitle = "کارگردان" },
            new MusicContributorType { Id = 13, PublicId = Guid.Parse("c5fb8a20-4dc5-45a6-9111-001000000013"), Title = "Artwork", PersianTitle = "طراح کاور" },
            new MusicContributorType { Id = 14, PublicId = Guid.Parse("c5fb8a20-4dc5-45a6-9111-001000000014"), Title = "Remixer", PersianTitle = "ریمیکسر" },
            new MusicContributorType { Id = 15, PublicId = Guid.Parse("c5fb8a20-4dc5-45a6-9111-001000000015"), Title = "Publisher", PersianTitle = "ناشر" });
    }
}

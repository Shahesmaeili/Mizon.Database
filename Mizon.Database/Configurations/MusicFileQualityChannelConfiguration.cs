namespace Mizon.Database.Configurations;

internal sealed class MusicFileQualityChannelConfiguration : IEntityTypeConfiguration<MusicFileQualityChannel>
{
    public void Configure(EntityTypeBuilder<MusicFileQualityChannel> builder)
    {
        builder.HasKey(item => item.Id);
        builder.Property(item => item.Id).ValueGeneratedNever();
        builder.Property(item => item.Title).IsRequired().HasMaxLength(32);
        builder.Property(item => item.PersianTitle).HasMaxLength(32);
        builder.Property(item => item.ChannelLayout).HasMaxLength(32);
        builder.HasData(
            new MusicFileQualityChannel { Id = 1, PublicId = Guid.Parse("b7bdc100-0000-4000-8000-000000000001"), Title = "Mono", PersianTitle = "مونو", ChannelCount = 1, ChannelLayout = "mono" },
            new MusicFileQualityChannel { Id = 2, PublicId = Guid.Parse("b7bdc100-0000-4000-8000-000000000002"), Title = "Stereo", PersianTitle = "استریو", ChannelCount = 2, ChannelLayout = "stereo" },
            new MusicFileQualityChannel { Id = 3, PublicId = Guid.Parse("b7bdc100-0000-4000-8000-000000000003"), Title = "5.1", PersianTitle = "پنج‌ویک", ChannelCount = 6, ChannelLayout = "5.1" },
            new MusicFileQualityChannel { Id = 4, PublicId = Guid.Parse("b7bdc100-0000-4000-8000-000000000004"), Title = "7.1", PersianTitle = "هفت‌ویک", ChannelCount = 8, ChannelLayout = "7.1" },
            new MusicFileQualityChannel { Id = 5, PublicId = Guid.Parse("b7bdc100-0000-4000-8000-000000000005"), Title = "2.1", PersianTitle = "دو‌ویک", ChannelCount = 3, ChannelLayout = "2.1" },
            new MusicFileQualityChannel { Id = 6, PublicId = Guid.Parse("b7bdc100-0000-4000-8000-000000000006"), Title = "Quad", PersianTitle = "چهارکاناله", ChannelCount = 4, ChannelLayout = "quad" },
            new MusicFileQualityChannel { Id = 7, PublicId = Guid.Parse("b7bdc100-0000-4000-8000-000000000007"), Title = "5.0", PersianTitle = "پنج‌کاناله", ChannelCount = 5, ChannelLayout = "5.0" },
            new MusicFileQualityChannel { Id = 8, PublicId = Guid.Parse("b7bdc100-0000-4000-8000-000000000008"), Title = "6.1", PersianTitle = "شش‌ویک", ChannelCount = 7, ChannelLayout = "6.1" });
    }
}

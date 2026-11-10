namespace Mizon.Database.Configurations;

internal sealed class StoryContentTypeConfiguration : IEntityTypeConfiguration<StoryContentType>
{
    public void Configure(EntityTypeBuilder<StoryContentType> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.Title).IsRequired().HasMaxLength(32);
        builder.Property(x => x.PersianTitle).HasMaxLength(32);

        builder.HasData(
            new StoryContentType { Id = 1, PublicId = Guid.Parse("c24a20a7-849b-41cb-a7a6-8a0df698a001"), Title = "Image", PersianTitle = "تصویر" },
            new StoryContentType { Id = 2, PublicId = Guid.Parse("c24a20a7-849b-41cb-a7a6-8a0df698a002"), Title = "Video", PersianTitle = "ویدیو" });
    }
}

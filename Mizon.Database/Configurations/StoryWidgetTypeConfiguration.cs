namespace Mizon.Database.Configurations;

internal sealed class StoryWidgetTypeConfiguration : IEntityTypeConfiguration<StoryWidgetType>
{
    public void Configure(EntityTypeBuilder<StoryWidgetType> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.Title).IsRequired().HasMaxLength(32);
        builder.Property(x => x.PersianTitle).HasMaxLength(32);

        builder.HasData(
            new StoryWidgetType { Id = 1, PublicId = Guid.Parse("e5b4a410-17c2-48c6-ae1e-7707b9240001"), Title = "ClientTag", PersianTitle = "تگ کاربر" },
            new StoryWidgetType { Id = 2, PublicId = Guid.Parse("e5b4a410-17c2-48c6-ae1e-7707b9240002"), Title = "MusicTag", PersianTitle = "تگ موسیقی" });
    }
}

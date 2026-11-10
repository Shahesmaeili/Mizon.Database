namespace Mizon.Database.Configurations;

internal sealed class StoryWidgetStyleConfiguration : IEntityTypeConfiguration<StoryWidgetStyle>
{
    public void Configure(EntityTypeBuilder<StoryWidgetStyle> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.Title).IsRequired().HasMaxLength(32);
        builder.Property(x => x.PersianTitle).HasMaxLength(32);
        builder.HasIndex(x => new { x.StoryWidgetTypeId, x.Title }).IsUnique();
        builder.HasOne(x => x.StoryWidgetType).WithMany(x => x.StoryWidgetStyles).HasForeignKey(x => x.StoryWidgetTypeId).OnDelete(DeleteBehavior.Restrict);

        builder.HasData(
            new StoryWidgetStyle { Id = 1, PublicId = Guid.Parse("b03f6d02-5661-4100-a3f3-571d1f030001"), StoryWidgetTypeId = 1, Title = "Classic", PersianTitle = "کلاسیک" },
            new StoryWidgetStyle { Id = 2, PublicId = Guid.Parse("b03f6d02-5661-4100-a3f3-571d1f030002"), StoryWidgetTypeId = 1, Title = "Compact", PersianTitle = "جمع‌وجور" },
            new StoryWidgetStyle { Id = 11, PublicId = Guid.Parse("b03f6d02-5661-4100-a3f3-571d1f030011"), StoryWidgetTypeId = 2, Title = "Classic", PersianTitle = "کلاسیک" },
            new StoryWidgetStyle { Id = 12, PublicId = Guid.Parse("b03f6d02-5661-4100-a3f3-571d1f030012"), StoryWidgetTypeId = 2, Title = "Compact", PersianTitle = "جمع‌وجور" });
    }
}

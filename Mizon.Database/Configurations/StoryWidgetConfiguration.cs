namespace Mizon.Database.Configurations;

internal sealed class StoryWidgetConfiguration : IEntityTypeConfiguration<StoryWidget>
{
    public void Configure(EntityTypeBuilder<StoryWidget> builder)
    {
        builder.HasIndex(x => new { x.StoryId, x.ZIndex });
        builder.HasOne(x => x.Story).WithMany(x => x.StoryWidgets).HasForeignKey(x => x.StoryId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.StoryWidgetType).WithMany(x => x.StoryWidgets).HasForeignKey(x => x.StoryWidgetTypeId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.StoryWidgetStyle).WithMany(x => x.StoryWidgets).HasForeignKey(x => x.StoryWidgetStyleId).OnDelete(DeleteBehavior.Restrict);
    }
}

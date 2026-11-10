namespace Mizon.Database.Configurations;

internal sealed class StoryClientWidgetConfiguration : IEntityTypeConfiguration<StoryClientWidget>
{
    public void Configure(EntityTypeBuilder<StoryClientWidget> builder)
    {
        builder.HasIndex(x => x.StoryWidgetId).IsUnique();
        builder.HasOne(x => x.StoryWidget).WithOne(x => x.ClientWidget).HasForeignKey<StoryClientWidget>(x => x.StoryWidgetId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.Client).WithMany(x => x.StoryClientWidgets).HasForeignKey(x => x.ClientId).OnDelete(DeleteBehavior.Restrict);
    }
}

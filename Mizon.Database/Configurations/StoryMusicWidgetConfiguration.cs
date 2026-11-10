namespace Mizon.Database.Configurations;

internal sealed class StoryMusicWidgetConfiguration : IEntityTypeConfiguration<StoryMusicWidget>
{
    public void Configure(EntityTypeBuilder<StoryMusicWidget> builder)
    {
        builder.HasIndex(x => x.StoryWidgetId).IsUnique();
        builder.HasOne(x => x.StoryWidget).WithOne(x => x.MusicWidget).HasForeignKey<StoryMusicWidget>(x => x.StoryWidgetId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.Music).WithMany(x => x.StoryMusicWidgets).HasForeignKey(x => x.MusicId).OnDelete(DeleteBehavior.Restrict);
    }
}

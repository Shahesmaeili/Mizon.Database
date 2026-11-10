namespace Mizon.Database.Configurations;

internal sealed class StoryViewConfiguration : IEntityTypeConfiguration<StoryView>
{
    public void Configure(EntityTypeBuilder<StoryView> builder)
    {
        builder.HasIndex(x => new { x.StoryId, x.ClientId }).IsUnique();
        builder.HasOne(x => x.Story).WithMany(x => x.StoryViews).HasForeignKey(x => x.StoryId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.Client).WithMany(x => x.StoryViews).HasForeignKey(x => x.ClientId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.PlatformVersion).WithMany(x => x.StoryViews).HasForeignKey(x => x.PlatformVersionId).OnDelete(DeleteBehavior.Restrict);
    }
}

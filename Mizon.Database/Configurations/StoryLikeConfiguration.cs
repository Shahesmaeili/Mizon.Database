namespace Mizon.Database.Configurations;

internal sealed class StoryLikeConfiguration : IEntityTypeConfiguration<StoryLike>
{
    public void Configure(EntityTypeBuilder<StoryLike> builder)
    {
        builder.HasIndex(x => new { x.StoryId, x.ClientId }).IsUnique();
        builder.HasOne(x => x.Story).WithMany(x => x.StoryLikes).HasForeignKey(x => x.StoryId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.Client).WithMany(x => x.StoryLikes).HasForeignKey(x => x.ClientId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.PlatformVersion).WithMany(x => x.StoryLikes).HasForeignKey(x => x.PlatformVersionId).OnDelete(DeleteBehavior.Restrict);
    }
}

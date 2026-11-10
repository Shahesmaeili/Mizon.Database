namespace Mizon.Database.Configurations;

internal sealed class StoryConfiguration : IEntityTypeConfiguration<Story>
{
    public void Configure(EntityTypeBuilder<Story> builder)
    {
        builder.Property(x => x.Title).HasMaxLength(60);
        builder.HasIndex(x => new { x.IsActive, x.ExpireDateTime });
        builder.HasIndex(x => new { x.ClientId, x.CreateDateTime });

        builder.HasOne(x => x.Client).WithMany(x => x.Stories).HasForeignKey(x => x.ClientId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.ContentMedia).WithMany(x => x.ContentStories).HasForeignKey(x => x.ContentMediaId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.PreviewMedia).WithMany(x => x.PreviewStories).HasForeignKey(x => x.PreviewMediaId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.StoryContentType).WithMany(x => x.Stories).HasForeignKey(x => x.StoryContentTypeId).OnDelete(DeleteBehavior.Restrict);
    }
}

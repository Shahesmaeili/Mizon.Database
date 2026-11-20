namespace Mizon.Database.Configurations;

internal sealed class MusicCommentTagConfiguration : IEntityTypeConfiguration<MusicCommentTag>
{
    public void Configure(EntityTypeBuilder<MusicCommentTag> builder)
    {
        builder.HasOne(x => x.MusicComment).WithMany(x => x.Tags).HasForeignKey(x => x.MusicCommentId);
        builder.HasOne(x => x.TaggedPerson).WithMany().HasForeignKey(x => x.TaggedPersonId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.TaggedClient).WithMany().HasForeignKey(x => x.TaggedClientId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.TaggedMusic).WithMany().HasForeignKey(x => x.TaggedMusicId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.TaggedMusicVideo).WithMany().HasForeignKey(x => x.TaggedMusicVideoId).OnDelete(DeleteBehavior.Restrict);
        builder.ToTable(table => table.HasCheckConstraint("CK_MusicCommentTags_OneTarget",
            "(CASE WHEN [TaggedPersonId] IS NULL THEN 0 ELSE 1 END + CASE WHEN [TaggedClientId] IS NULL THEN 0 ELSE 1 END + " +
            "CASE WHEN [TaggedMusicId] IS NULL THEN 0 ELSE 1 END + CASE WHEN [TaggedMusicVideoId] IS NULL THEN 0 ELSE 1 END) = 1"));
    }
}

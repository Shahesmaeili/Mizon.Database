namespace Mizon.Database.Configurations;

internal sealed class MusicCommentVoteConfiguration : IEntityTypeConfiguration<MusicCommentVote>
{
    public void Configure(EntityTypeBuilder<MusicCommentVote> builder)
    {
        builder.HasOne(x => x.MusicComment).WithMany(x => x.Votes).HasForeignKey(x => x.MusicCommentId);
        builder.HasOne(x => x.Client).WithMany().HasForeignKey(x => x.ClientId).OnDelete(DeleteBehavior.Restrict);
        builder.HasIndex(x => new { x.MusicCommentId, x.ClientId }).IsUnique();
        builder.HasIndex(x => new { x.MusicCommentId, x.IsLike });
    }
}

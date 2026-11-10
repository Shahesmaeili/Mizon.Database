namespace Mizon.Database.Configurations;

internal sealed class MusicReactionConfiguration : IEntityTypeConfiguration<MusicReaction>
{
    public void Configure(EntityTypeBuilder<MusicReaction> builder)
    {
        builder.HasOne(x => x.Music)
.WithMany(x => x.MusicReactions)
.HasForeignKey(x => x.MusicId)
.OnDelete(DeleteBehavior.Restrict);


        builder.HasOne(x => x.Client)
.WithMany(x => x.MusicReactions)
.HasForeignKey(x => x.ClientId)
.OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.PlatformVersion)
.WithMany(x => x.MusicReactions)
.HasForeignKey(x => x.PlatformVersionId)
.OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.MusicReactionType)
.WithMany(x => x.MusicReactions)
.HasForeignKey(x => x.MusicReactionTypeId)
.OnDelete(DeleteBehavior.Restrict);
    }
}

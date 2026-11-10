namespace Mizon.Database.Configurations;

internal sealed class MusicLikeConfiguration : IEntityTypeConfiguration<MusicLike>
{
    public void Configure(EntityTypeBuilder<MusicLike> builder)
    {
        builder.HasIndex(x => new { x.MusicId, x.ClientId }).IsUnique();
        builder.HasOne(x => x.Music)
.WithMany(x => x.MusicLikes)
.HasForeignKey(x => x.MusicId)
.OnDelete(DeleteBehavior.Restrict);


        builder.HasOne(x => x.Client)
.WithMany(x => x.MusicLikes)
.HasForeignKey(x => x.ClientId)
.OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.PlatformVersion)
.WithMany(x => x.MusicLikes)
.HasForeignKey(x => x.PlatformVersionId)
.OnDelete(DeleteBehavior.Restrict);
    }
}

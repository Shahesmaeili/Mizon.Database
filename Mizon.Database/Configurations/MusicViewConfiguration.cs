namespace Mizon.Database.Configurations;

internal sealed class MusicViewConfiguration : IEntityTypeConfiguration<MusicView>
{
    public void Configure(EntityTypeBuilder<MusicView> builder)
    {
        builder.HasOne(x => x.Music)
.WithMany(x => x.MusicViews)
.HasForeignKey(x => x.MusicId)
.OnDelete(DeleteBehavior.Restrict);


        builder.HasOne(x => x.Client)
.WithMany(x => x.MusicViews)
.HasForeignKey(x => x.ClientId)
.OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.PlatformVersion)
.WithMany(x => x.MusicViews)
.HasForeignKey(x => x.PlatformVersionId)
.OnDelete(DeleteBehavior.Restrict);
    }
}
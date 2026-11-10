namespace Mizon.Database.Configurations;

internal sealed class MusicConfiguration : IEntityTypeConfiguration<Music>
{
    public void Configure(EntityTypeBuilder<Music> builder)
    {

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(64);

        builder.Property(x => x.PersianTitle)
    .IsRequired(false)
    .HasMaxLength(64);

        builder.Property(x => x.ReleaseDateTime)
.IsRequired(false);

        builder.HasOne(x => x.MusicLabel)
.WithMany(x => x.Musics)
.HasForeignKey(x => x.MusicLabelId)
.OnDelete(DeleteBehavior.Restrict);


        builder.HasOne(c => c.MusicCover)
           .WithOne(x => x.Music)
           .HasForeignKey<MusicCover>(c => c.MusicId);

        builder.HasOne(x => x.MusicAlbum)
.WithMany(x => x.Musics)
.HasForeignKey(x => x.MusicAlbumId)
.OnDelete(DeleteBehavior.Restrict);
    }
}

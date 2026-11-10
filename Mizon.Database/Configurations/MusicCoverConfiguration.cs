namespace Mizon.Database.Configurations;

internal sealed class MusicCoverConfiguration : IEntityTypeConfiguration<MusicCover>
{
    public void Configure(EntityTypeBuilder<MusicCover> builder)
    {
        builder.HasKey(x => x.MusicId);

        builder.Property(x => x.Blurhash)
 .IsRequired()
 .HasMaxLength(256);

        builder.Property(x => x.PrimaryAccentColor)
 .IsRequired()
 .HasMaxLength(9);

        builder.HasOne(x => x.Media)
.WithMany(x => x.MusicCovers)
.HasForeignKey(x => x.MediaId)
.OnDelete(DeleteBehavior.Restrict);



        builder.HasOne(x => x.ImageFormat)
.WithMany(x => x.MusicCovers)
.HasForeignKey(x => x.ImageFormatId)
.OnDelete(DeleteBehavior.Restrict);
    }
}


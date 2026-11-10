namespace Mizon.Database.Configurations;

public sealed class MusicAlbumConfiguration : IEntityTypeConfiguration<MusicAlbum>
{
    public void Configure(EntityTypeBuilder<MusicAlbum> builder)
    {
        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(64);

        builder.Property(x => x.PersianTitle)
    .IsRequired(false)
    .HasMaxLength(64);
    }
}
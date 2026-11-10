namespace Mizon.Database.Configurations;

internal sealed class MediaConfiguration : IEntityTypeConfiguration<Media>
{
    public void Configure(EntityTypeBuilder<Media> builder)
    {
        builder.Property(x => x.StoragePath)
            .IsRequired()
            .HasMaxLength(512);

        builder.Property(x => x.EncryptionIV)
    .IsRequired()
    .HasMaxLength(16);

        builder.Property(x => x.FileHash)
    .IsRequired()
    .HasMaxLength(128)
    .IsUnicode(false);

        builder.Property(x => x.FileName)
.IsRequired()
.HasMaxLength(512);

        builder.HasOne(x => x.MediaKey)
.WithMany(x => x.Medias)
.HasForeignKey(x => x.MediaKeyId)
.OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.MediaEncryptionType)
.WithMany(x => x.Medias)
.HasForeignKey(x => x.MediaEncryptionTypeId)
.OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.MediaStorageType)
.WithMany(x => x.Medias)
.HasForeignKey(x => x.MediaStorageTypeId)
.OnDelete(DeleteBehavior.Restrict);

    }
}
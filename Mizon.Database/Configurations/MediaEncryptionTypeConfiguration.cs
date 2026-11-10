namespace Mizon.Database.Configurations;

internal sealed class MediaEncryptionTypeConfiguration : IEntityTypeConfiguration<MediaEncryptionType>
{
    public void Configure(EntityTypeBuilder<MediaEncryptionType> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
           .ValueGeneratedNever();

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(32);
    }
}

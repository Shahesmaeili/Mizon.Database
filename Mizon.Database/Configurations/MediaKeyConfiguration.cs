namespace Mizon.Database.Configurations;

internal sealed class MediaKeyConfiguration : IEntityTypeConfiguration<MediaKey>
{
    public void Configure(EntityTypeBuilder<MediaKey> builder)
    {
        builder.Property(x => x.KeyData)
            .IsRequired()
            .HasMaxLength(128);
    }
}
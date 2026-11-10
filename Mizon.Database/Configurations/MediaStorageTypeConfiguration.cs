namespace Mizon.Database.Configurations;

internal sealed class MediaStorageTypeConfiguration : IEntityTypeConfiguration<MediaStorageType>
{
    public void Configure(EntityTypeBuilder<MediaStorageType> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
           .ValueGeneratedNever();

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(32);
    }
}

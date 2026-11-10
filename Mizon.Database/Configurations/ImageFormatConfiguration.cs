namespace Mizon.Database.Configurations;

internal sealed class ImageFormatConfiguration : IEntityTypeConfiguration<ImageFormat>
{
    public void Configure(EntityTypeBuilder<ImageFormat> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
           .ValueGeneratedNever();

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(16);
    }
}

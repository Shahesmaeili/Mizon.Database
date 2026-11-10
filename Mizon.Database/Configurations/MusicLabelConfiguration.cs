namespace Mizon.Database.Configurations;

internal sealed class MusicLabelConfiguration : IEntityTypeConfiguration<MusicLabel>
{
    public void Configure(EntityTypeBuilder<MusicLabel> builder)
    {
        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(64);

        builder.Property(x => x.PersianTitle)
    .IsRequired(false)
    .HasMaxLength(64);
    }
}
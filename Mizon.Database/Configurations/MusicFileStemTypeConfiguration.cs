namespace Mizon.Database.Configurations;

internal sealed class MusicFileStemTypeConfiguration : IEntityTypeConfiguration<MusicFileStemType>
{
    public void Configure(EntityTypeBuilder<MusicFileStemType> builder)
    {
        builder.Property(item => item.Title).IsRequired().HasMaxLength(64);
        builder.Property(item => item.PersianTitle).IsRequired(false).HasMaxLength(64);
    }
}

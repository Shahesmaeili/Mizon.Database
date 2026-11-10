namespace Mizon.Database.Configurations;

internal sealed class MusicGenreTypeConfiguration : IEntityTypeConfiguration<MusicGenreType>
{
    public void Configure(EntityTypeBuilder<MusicGenreType> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
           .ValueGeneratedNever();

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(32);

        builder.Property(x => x.PersianTitle)
            .IsRequired(false)
            .HasMaxLength(32);

        builder.Property(x => x.AccentColorHex)
            .IsRequired()
            .HasMaxLength(9);

        builder.Property(x => x.IconSymbol)
            .IsRequired()
            .HasMaxLength(64);
    }
}

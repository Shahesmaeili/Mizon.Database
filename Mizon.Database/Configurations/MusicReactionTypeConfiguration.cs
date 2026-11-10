namespace Mizon.Database.Configurations;

internal sealed class MusicReactionTypeConfiguration : IEntityTypeConfiguration<MusicReactionType>
{
    public void Configure(EntityTypeBuilder<MusicReactionType> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
           .ValueGeneratedNever();

        builder.Property(x => x.Emoji)
            .IsRequired()
            .HasMaxLength(10)
            .IsUnicode(true);
    }
}

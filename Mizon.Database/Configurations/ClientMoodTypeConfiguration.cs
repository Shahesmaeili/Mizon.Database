namespace Mizon.Database.Configurations;

internal sealed class ClientMoodTypeConfiguration : IEntityTypeConfiguration<ClientMoodType>
{
    public void Configure(EntityTypeBuilder<ClientMoodType> builder)
    {
        builder.Property(x => x.Emoji).IsRequired().HasMaxLength(64).UseCollation("Latin1_General_100_BIN2");
        builder.HasIndex(x => x.Emoji).IsUnique();
        builder.Property(x => x.Title).IsRequired().HasMaxLength(128);
        builder.Property(x => x.PersianTitle).HasMaxLength(128);
        builder.HasOne(x => x.AnimationMedia).WithMany(x => x.AnimationClientMoodTypes)
            .HasForeignKey(x => x.AnimationMediaId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.PreviewMedia).WithMany(x => x.PreviewClientMoodTypes)
            .HasForeignKey(x => x.PreviewMediaId).OnDelete(DeleteBehavior.Restrict);
    }
}


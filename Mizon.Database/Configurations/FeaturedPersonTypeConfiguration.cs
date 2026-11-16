namespace Mizon.Database.Configurations;

internal sealed class FeaturedPersonTypeConfiguration : IEntityTypeConfiguration<FeaturedPersonType>
{
    public void Configure(EntityTypeBuilder<FeaturedPersonType> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.Code).IsRequired().HasMaxLength(16);
        builder.HasIndex(x => x.Code).IsUnique();
        builder.Property(x => x.Title).IsRequired().HasMaxLength(32);
        builder.Property(x => x.PersianTitle).HasMaxLength(32);
    }
}

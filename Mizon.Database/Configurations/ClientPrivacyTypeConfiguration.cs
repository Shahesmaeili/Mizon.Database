namespace Mizon.Database.Configurations;

internal sealed class ClientPrivacyTypeConfiguration : IEntityTypeConfiguration<ClientPrivacyType>
{
    public void Configure(EntityTypeBuilder<ClientPrivacyType> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.Title).IsRequired().HasMaxLength(32);
        builder.Property(x => x.PersianTitle).HasMaxLength(32);
    }
}

namespace Mizon.Database.Configurations;

internal sealed class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasOne(x => x.ClientMoodType)
            .WithMany(x => x.Clients)
            .HasForeignKey(x => x.ClientMoodTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.ClientPrivacyTypeId)
            .IsConcurrencyToken();

        builder.HasOne(x => x.ClientPrivacyType)
            .WithMany(x => x.Clients)
            .HasForeignKey(x => x.ClientPrivacyTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(64);

        builder.Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(64);

        builder.Property(x => x.NickName)
            .IsRequired(false)
            .HasMaxLength(64);
    }
}

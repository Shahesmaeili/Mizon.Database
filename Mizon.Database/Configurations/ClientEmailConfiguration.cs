namespace Mizon.Database.Configurations;

internal sealed class ClientEmailConfiguration : IEntityTypeConfiguration<ClientEmail>
{
    public void Configure(EntityTypeBuilder<ClientEmail> builder)
    {
        builder.Property(x => x.Email)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(128);

        builder.HasOne(x => x.Client)
       .WithMany(x => x.ClientEmails)
       .HasForeignKey(x => x.ClientId)
       .OnDelete(DeleteBehavior.Restrict);
    }
}
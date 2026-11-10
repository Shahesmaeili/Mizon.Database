namespace Mizon.Database.Configurations;

internal sealed class ClientPasswordConfiguration : IEntityTypeConfiguration<ClientPassword>
{
    public void Configure(EntityTypeBuilder<ClientPassword> builder)
    {
        builder.Property(x => x.PasswordHash)
            .IsRequired()
            .HasMaxLength(32);

        builder.Property(x => x.Salt)
            .IsRequired()
            .HasMaxLength(16);


        builder.HasOne(x => x.Client)
.WithMany(x => x.ClientPasswords)
.HasForeignKey(x => x.ClientId)
.OnDelete(DeleteBehavior.Restrict);
    }
}
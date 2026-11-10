namespace Mizon.Database.Configurations;

internal sealed class ClientUsernameConfiguration : IEntityTypeConfiguration<ClientUsername>
{
    public void Configure(EntityTypeBuilder<ClientUsername> builder)
    {
        builder.Property(x => x.Username)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(64);

        builder.HasOne(x => x.Client)
.WithMany(x => x.ClientUsernames)
.HasForeignKey(x => x.ClientId)
.OnDelete(DeleteBehavior.Restrict);


    }
}
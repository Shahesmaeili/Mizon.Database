namespace Mizon.Database.Configurations;

internal sealed class ClientSessionIpConfiguration : IEntityTypeConfiguration<ClientSessionIp>
{
    public void Configure(EntityTypeBuilder<ClientSessionIp> builder)
    {
        builder.Property(x => x.IpAddress)
            .IsRequired()
            .HasMaxLength(128);


        builder.HasOne(x => x.ClientSession)
.WithMany(x => x.ClientSessionIps)
.HasForeignKey(x => x.ClientSessionId)
.OnDelete(DeleteBehavior.Restrict);
    }
}
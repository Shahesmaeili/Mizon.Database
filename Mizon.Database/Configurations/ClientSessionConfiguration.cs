namespace Mizon.Database.Configurations;

internal sealed class ClientSessionConfiguration : IEntityTypeConfiguration<ClientSession>
{
    public void Configure(EntityTypeBuilder<ClientSession> builder)
    {
        builder.Property(x => x.OsVersion)
            .IsRequired()
            .HasMaxLength(16);

        builder.Property(x => x.DeviceIdentifier)
     .IsRequired()
     .HasMaxLength(128);

        builder.Property(x => x.DeviceName)
.IsRequired()
.HasMaxLength(128);

        builder.Property(x => x.DeviceUsername)
.IsRequired()
.HasMaxLength(128);

        builder.Property(x => x.DeviceModel)
.IsRequired()
.HasMaxLength(128);

        builder.Property(x => x.RefreshTokenHash)
.IsRequired()
.HasMaxLength(128);


        builder.HasOne(x => x.PlatformVersion)
.WithMany(x => x.ClientSessions)
.HasForeignKey(x => x.PlatformVersionId)
.OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Client)
.WithMany(x => x.ClientSessions)
.HasForeignKey(x => x.ClientId)
.OnDelete(DeleteBehavior.Restrict);
    }
}

namespace Mizon.Database.Configurations;

internal sealed class ClientProfileConfiguration : IEntityTypeConfiguration<ClientProfile>
{
    public void Configure(EntityTypeBuilder<ClientProfile> builder)
    {
        builder.Property(x => x.Blurhash)
            .IsRequired()
            .HasMaxLength(150);


        builder.HasOne(x => x.ImageFormat)
.WithMany(x => x.ClientProfiles)
.HasForeignKey(x => x.ImageFormatId)
.OnDelete(DeleteBehavior.Restrict);

        //builder.HasOne<Media>()
        //  .WithMany(x => x.ClientProfiles)
        //  .HasForeignKey(x => x.MediaId)
        //  .OnDelete(DeleteBehavior.Restrict);




        builder.HasOne(x => x.Client)
.WithMany(x => x.ClientProfiles)
.HasForeignKey(x => x.ClientId)
.OnDelete(DeleteBehavior.Restrict);
    }
}
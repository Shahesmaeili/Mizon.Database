namespace Mizon.Database.Configurations;

internal sealed class PlatformVersionConfiguration : IEntityTypeConfiguration<PlatformVersion>
{
    public void Configure(EntityTypeBuilder<PlatformVersion> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
           .ValueGeneratedNever();

        builder.Property(x => x.Version)
            .IsRequired()
            .HasMaxLength(32);


        builder.HasOne(x => x.Platform)
.WithMany(x => x.PlatformVersions)
.HasForeignKey(x => x.PlatformId)
.OnDelete(DeleteBehavior.Restrict);

    }
}


namespace Mizon.Database.Configurations;

internal sealed class MusicVideoConfiguration : IEntityTypeConfiguration<MusicVideo>
{
    public void Configure(EntityTypeBuilder<MusicVideo> builder)
    {
        builder.HasIndex(item => item.PublicId).IsUnique();

        builder.HasOne(item => item.Music)
            .WithOne(music => music.MusicVideo)
            .HasForeignKey<MusicVideo>(item => item.MusicId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(item => item.Media)
            .WithMany()
            .HasForeignKey(item => item.MediaId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(item => item.CoverMedia)
            .WithMany()
            .HasForeignKey(item => item.CoverMediaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

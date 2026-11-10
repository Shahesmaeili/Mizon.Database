namespace Mizon.Database.Configurations;

internal sealed class MusicFileStemPitchConfiguration : IEntityTypeConfiguration<MusicFileStemPitch>
{
    public void Configure(EntityTypeBuilder<MusicFileStemPitch> builder)
    {
        builder.HasOne(item => item.MusicFileStem).WithMany().HasForeignKey(item => item.MusicFileStemId).OnDelete(DeleteBehavior.Restrict);
        builder.HasIndex(item => new { item.MusicFileStemId, item.StartTimeInMilliseconds }).IsUnique();
    }
}

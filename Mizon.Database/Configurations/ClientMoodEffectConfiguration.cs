namespace Mizon.Database.Configurations;

internal sealed class ClientMoodEffectConfiguration : IEntityTypeConfiguration<ClientMoodEffect>
{
    public void Configure(EntityTypeBuilder<ClientMoodEffect> builder)
    {
        builder.HasIndex(x => new { x.ClientMoodTypeId, x.MediaId }).IsUnique();
        builder.HasOne(x => x.ClientMoodType).WithMany(x => x.ClientMoodEffects)
            .HasForeignKey(x => x.ClientMoodTypeId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.Media).WithMany(x => x.ClientMoodEffects)
            .HasForeignKey(x => x.MediaId).OnDelete(DeleteBehavior.Restrict);
    }
}


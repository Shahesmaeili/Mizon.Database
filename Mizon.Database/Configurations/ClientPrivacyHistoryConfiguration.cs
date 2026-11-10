namespace Mizon.Database.Configurations;

internal sealed class ClientPrivacyHistoryConfiguration : IEntityTypeConfiguration<ClientPrivacyHistory>
{
    public void Configure(EntityTypeBuilder<ClientPrivacyHistory> builder)
    {
        builder.HasOne(x => x.Client)
            .WithMany(x => x.ClientPrivacyHistories)
            .HasForeignKey(x => x.ClientId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.PreviousClientPrivacyType)
            .WithMany(x => x.PreviousClientPrivacyHistories)
            .HasForeignKey(x => x.PreviousClientPrivacyTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.ClientPrivacyType)
            .WithMany(x => x.ClientPrivacyHistories)
            .HasForeignKey(x => x.ClientPrivacyTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.ActorClient)
            .WithMany(x => x.ClientPrivacyHistoryActions)
            .HasForeignKey(x => x.ActorClientId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new { x.ClientId, x.Id });
    }
}

namespace Mizon.Database.Configurations;

internal sealed class ClientFollowHistoryConfiguration : IEntityTypeConfiguration<ClientFollowHistory>
{
    public void Configure(EntityTypeBuilder<ClientFollowHistory> builder)
    {
        builder.HasOne(x => x.ClientFollow)
            .WithMany(x => x.ClientFollowHistories)
            .HasForeignKey(x => x.ClientFollowId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.ClientFollowActionType)
            .WithMany(x => x.ClientFollowHistories)
            .HasForeignKey(x => x.ClientFollowActionTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.PreviousClientFollowStatusType)
            .WithMany(x => x.PreviousClientFollowHistories)
            .HasForeignKey(x => x.PreviousClientFollowStatusTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.ClientFollowStatusType)
            .WithMany(x => x.ClientFollowHistories)
            .HasForeignKey(x => x.ClientFollowStatusTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.ActorClient)
            .WithMany(x => x.ClientFollowHistoryActions)
            .HasForeignKey(x => x.ActorClientId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new { x.ClientFollowId, x.Id });
    }
}

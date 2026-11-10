namespace Mizon.Database.Configurations;

internal sealed class ClientFollowConfiguration : IEntityTypeConfiguration<ClientFollow>
{
    public void Configure(EntityTypeBuilder<ClientFollow> builder)
    {
        builder.Property(x => x.RowVersion).IsRowVersion();

        builder.HasOne(x => x.FollowerClient)
            .WithMany(x => x.ClientFollowings)
            .HasForeignKey(x => x.FollowerClientId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.FollowedClient)
            .WithMany(x => x.ClientFollowers)
            .HasForeignKey(x => x.FollowedClientId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.FollowedPerson)
            .WithMany(x => x.ClientFollowers)
            .HasForeignKey(x => x.FollowedPersonId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.ClientFollowStatusType)
            .WithMany(x => x.ClientFollows)
            .HasForeignKey(x => x.ClientFollowStatusTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new { x.FollowerClientId, x.FollowedClientId })
            .IsUnique()
            .HasFilter("[FollowedClientId] IS NOT NULL");

        builder.HasIndex(x => new { x.FollowerClientId, x.FollowedPersonId })
            .IsUnique()
            .HasFilter("[FollowedPersonId] IS NOT NULL");

        builder.HasIndex(x => new { x.FollowerClientId, x.ClientFollowStatusTypeId, x.Id });

        builder.HasIndex(x => new { x.FollowedClientId, x.ClientFollowStatusTypeId, x.Id })
            .HasFilter("[FollowedClientId] IS NOT NULL");

        builder.HasIndex(x => new { x.FollowedPersonId, x.ClientFollowStatusTypeId, x.Id })
            .HasFilter("[FollowedPersonId] IS NOT NULL");
    }
}

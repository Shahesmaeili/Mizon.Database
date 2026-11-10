namespace Mizon.Database.Entities;

public class ClientFollowHistory : IEntityTable<int>, ICreate
{
    public int Id { get; set; }

    public int ClientFollowId { get; set; }
    public ClientFollow? ClientFollow { get; set; }

    public byte ClientFollowActionTypeId { get; set; }
    public ClientFollowActionType? ClientFollowActionType { get; set; }

    public byte? PreviousClientFollowStatusTypeId { get; set; }
    public ClientFollowStatusType? PreviousClientFollowStatusType { get; set; }

    public byte ClientFollowStatusTypeId { get; set; }
    public ClientFollowStatusType? ClientFollowStatusType { get; set; }

    // A null actor identifies an action performed by the system.
    public int? ActorClientId { get; set; }
    public Client? ActorClient { get; set; }

    public DateTimeOffset CreateDateTime { get; set; }
}

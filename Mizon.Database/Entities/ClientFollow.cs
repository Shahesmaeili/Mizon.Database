namespace Mizon.Database.Entities;

public class ClientFollow : IEntityTable<int>, IPublicId, ICreate, IUpdate
{
    public int Id { get; set; }
    public Guid PublicId { get; set; }

    public int FollowerClientId { get; set; }
    public Client? FollowerClient { get; set; }

    public int? FollowedClientId { get; set; }
    public Client? FollowedClient { get; set; }

    public int? FollowedPersonId { get; set; }
    public Person? FollowedPerson { get; set; }

    public byte ClientFollowStatusTypeId { get; set; }
    public ClientFollowStatusType? ClientFollowStatusType { get; set; }

    // These timestamps describe the current request/follow cycle; history retains earlier cycles.
    public DateTimeOffset? RequestDateTime { get; set; }
    public DateTimeOffset? AcceptDateTime { get; set; }
    public DateTimeOffset? FollowDateTime { get; set; }
    public DateTimeOffset? EndDateTime { get; set; }

    public byte[] RowVersion { get; set; } = [];

    public List<ClientFollowHistory> ClientFollowHistories { get; set; } = [];
    public DateTimeOffset CreateDateTime { get; set; }
    public DateTimeOffset? UpdateDateTime { get; set; }
}

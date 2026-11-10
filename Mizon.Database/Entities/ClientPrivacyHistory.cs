namespace Mizon.Database.Entities;

public class ClientPrivacyHistory : IEntityTable<int>, ICreate
{
    public int Id { get; set; }

    public int ClientId { get; set; }
    public Client? Client { get; set; }

    public byte? PreviousClientPrivacyTypeId { get; set; }
    public ClientPrivacyType? PreviousClientPrivacyType { get; set; }

    public byte ClientPrivacyTypeId { get; set; }
    public ClientPrivacyType? ClientPrivacyType { get; set; }

    // A null actor identifies a system action, including the initial privacy baseline.
    public int? ActorClientId { get; set; }
    public Client? ActorClient { get; set; }

    public DateTimeOffset CreateDateTime { get; set; }
}

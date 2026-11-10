namespace Mizon.Database.Entities;

public class ClientPrivacyType : IEntityTable<byte>, IPublicId, ICreate, IUpdate
{
    public byte Id { get; set; }
    public Guid PublicId { get; set; }
    public string Title { get; set; } = null!;
    public string? PersianTitle { get; set; }
    public DateTimeOffset CreateDateTime { get; set; }
    public DateTimeOffset? UpdateDateTime { get; set; }

    public List<Client> Clients { get; set; } = [];
    public List<ClientPrivacyHistory> ClientPrivacyHistories { get; set; } = [];
    public List<ClientPrivacyHistory> PreviousClientPrivacyHistories { get; set; } = [];
}

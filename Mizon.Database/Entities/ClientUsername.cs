namespace Mizon.Database.Entities;

public class ClientUsername : IEntityTable<int>, IPublicId, ICreate, IUpdate
{
    public int Id { get; set; }
    public Guid PublicId { get; set; }
    public int ClientId { get; set; }
    public Client? Client { get; set; }
    public string Username { get; set; } = null!;
    public bool IsActive { get; set; }
    public DateTimeOffset CreateDateTime { get; set; }
    public DateTimeOffset? UpdateDateTime { get; set; }
}

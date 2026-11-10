namespace Mizon.Database.Entities;

public class ClientEmail : IEntityTable<int>, IPublicId, ICreate, IUpdate
{
    public int Id { get; set; }
    public Guid PublicId { get; set; }

    public int ClientId { get; set; }
    public Client? Client { get; set; }

    public string Email { get; set; } = null!;

    public bool IsActive { get; set; }

    public bool IsVerified { get; set; }

    public DateTimeOffset CreateDateTime { get; set; }
    public DateTimeOffset? UpdateDateTime { get; set; }
}

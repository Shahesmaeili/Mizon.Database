namespace Mizon.Database.Entities;

public class ClientPassword : IEntityTable<int>, ICreate, IUpdate
{
    public int Id { get; set; }

    public int ClientId { get; set; }
    public Client? Client { get; set; }

    public byte[] PasswordHash { get; set; } = null!;

    public byte[] Salt { get; set; } = null!;
    public bool IsActive { get; set; }
    public DateTimeOffset CreateDateTime { get; set; }
    public DateTimeOffset? UpdateDateTime { get; set; }
}

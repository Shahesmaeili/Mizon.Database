namespace Mizon.Database.Entities;

public class ClientSessionIp : IEntityTable<int>, ICreate
{
    public int Id { get; set; }
    public int ClientSessionId { get; set; }
    public ClientSession? ClientSession { get; set; }
    public string IpAddress { get; set; } = null!;
    public DateTimeOffset CreateDateTime { get; set; }
}

namespace Mizon.Database.Entities;

public class ClientSession : IEntityTable<int>, IPublicId, ICreate, IUpdate
{
    public int Id { get; set; }
    public Guid PublicId { get; set; }
    public int ClientId { get; set; }
    public Client? Client { get; set; }
    public short PlatformVersionId { get; set; }
    public PlatformVersion PlatformVersion { get; set; } = null!;

    public DateTimeOffset LastSeenDateTime { get; set; }

    public string OsVersion { get; set; } = null!;

    public string DeviceIdentifier { get; set; } = null!;

    public string DeviceName { get; set; } = null!;
    public string DeviceUsername { get; set; } = null!;

    public string DeviceModel { get; set; } = null!;

    public string RefreshTokenHash { get; set; } = null!;

    public DateTimeOffset CreateDateTime { get; set; }
    public DateTimeOffset? UpdateDateTime { get; set; }
    public DateTimeOffset? LogoutDateTime { get; set; }
    public List<ClientSessionIp> ClientSessionIps { get; set; } = [];
}

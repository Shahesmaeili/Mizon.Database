namespace Mizon.Database.Entities;

public class MusicView : IEntityTable<int>, ICreate, IUpdate
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public Client? Client { get; set; }

    public int MusicId { get; set; }
    public Music? Music { get; set; }

    public short PlatformVersionId { get; set; }
    public PlatformVersion? PlatformVersion { get; set; }

    public DateTimeOffset CreateDateTime { get; set; }
    public DateTimeOffset? UpdateDateTime { get; set; }
}

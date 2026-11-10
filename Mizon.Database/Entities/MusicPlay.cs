namespace Mizon.Database.Entities;

public sealed class MusicPlay : IEntityTable<int>, ICreate
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public Client? Client { get; set; }
    public int MusicId { get; set; }
    public Music? Music { get; set; }
    public short PlatformVersionId { get; set; }
    public PlatformVersion? PlatformVersion { get; set; }
    public Guid PlaybackPublicId { get; set; }
    public DateTimeOffset CreateDateTime { get; set; }
}

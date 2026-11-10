namespace Mizon.Database.Entities;

public class MusicFileQualityBitDepth : IEntityTable<byte>, IPublicId, ICreate, IUpdate
{
    public byte Id { get; set; }
    public Guid PublicId { get; set; }
    public string Title { get; set; } = null!;
    public byte BitDepth { get; set; }
    public DateTimeOffset CreateDateTime { get; set; }
    public DateTimeOffset? UpdateDateTime { get; set; }
    public List<MusicFileQuality> MusicFileQualities { get; set; } = [];
}

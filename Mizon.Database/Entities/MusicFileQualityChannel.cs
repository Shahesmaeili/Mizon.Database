namespace Mizon.Database.Entities;

public class MusicFileQualityChannel : IEntityTable<byte>, IPublicId, ICreate, IUpdate
{
    public byte Id { get; set; }
    public Guid PublicId { get; set; }
    public string Title { get; set; } = null!;
    public string? PersianTitle { get; set; }
    public byte ChannelCount { get; set; }
    public string? ChannelLayout { get; set; }
    public DateTimeOffset CreateDateTime { get; set; }
    public DateTimeOffset? UpdateDateTime { get; set; }
    public List<MusicFileQuality> MusicFileQualities { get; set; } = [];
}

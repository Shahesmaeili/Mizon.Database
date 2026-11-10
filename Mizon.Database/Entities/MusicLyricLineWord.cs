namespace Mizon.Database.Entities;

public class MusicLyricLineWord : IEntityTable<int>, IPublicId, ICreate, IUpdate
{
    public int Id { get; set; }
    public Guid PublicId { get; set; }
    public int MusicLyricLineId { get; set; }
    public MusicLyricLine? MusicLyricLine { get; set; }
    public int StartTimeInMilliseconds { get; set; }
    public int EndTimeInMilliseconds { get; set; }
    public int WordOrder { get; set; }
    public string Text { get; set; } = null!;
    public DateTimeOffset CreateDateTime { get; set; }
    public DateTimeOffset? UpdateDateTime { get; set; }
}

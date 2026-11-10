namespace Mizon.Database.Entities;

public class MusicLyricLine : IEntityTable<int>, IPublicId, ICreate, IUpdate
{
    public int Id { get; set; }
    public Guid PublicId { get; set; }
    public int MusicLyricId { get; set; }
    public MusicLyric? MusicLyric { get; set; }
    public int StartTimeInMilliseconds { get; set; }
    public int EndTimeInMilliseconds { get; set; }
    public int LineOrder { get; set; }
    public string Text { get; set; } = null!;
    public DateTimeOffset CreateDateTime { get; set; }
    public DateTimeOffset? UpdateDateTime { get; set; }
    public List<MusicLyricLineWord> MusicLyricLineWords { get; set; } = [];

}

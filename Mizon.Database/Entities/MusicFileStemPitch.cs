namespace Mizon.Database.Entities;

public class MusicFileStemPitch : IEntityTable<int>, ICreate, IUpdate
{
    public int Id { get; set; }
    public int MusicFileStemId { get; set; }
    public MusicFileStem? MusicFileStem { get; set; }
    public float AverageF0Hz { get; set; }
    public int StartTimeInMilliseconds { get; set; }
    public int EndTimeInMilliseconds { get; set; }
    public DateTimeOffset CreateDateTime { get; set; }
    public DateTimeOffset? UpdateDateTime { get; set; }
}

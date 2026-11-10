namespace Mizon.Database.Entities;

public class MusicFileWaveform : IEntityTable<long>, ICreate, IUpdate
{
    public long Id { get; set; }
    public int MusicFileId { get; set; }
    public MusicFile? MusicFile { get; set; }
    public int OffsetInMilliseconds { get; set; }
    public short MinimumAmplitude { get; set; }
    public short MaximumAmplitude { get; set; }
    public float RMS { get; set; }
    public short Peak { get; set; }
    public float Transient { get; set; }     // sudden energy change
    public bool IsClipping { get; set; }
    public DateTimeOffset CreateDateTime { get; set; }
    public DateTimeOffset? UpdateDateTime { get; set; }
}

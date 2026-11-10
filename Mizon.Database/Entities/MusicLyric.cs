namespace Mizon.Database.Entities;

public class MusicLyric : IEntityTable<int>, IPublicId, ICreate, IUpdate
{
    public int Id { get; set; }
    public Guid PublicId { get; set; }
    public int MusicId { get; set; }
    public Music? Music { get; set; }
    public byte LanguageId { get; set; }
    public Language? Language { get; set; }
    public DateTimeOffset CreateDateTime { get; set; }
    public DateTimeOffset? UpdateDateTime { get; set; }
    public List<MusicLyricLine> MusicLyricLines { get; set; } = [];
}

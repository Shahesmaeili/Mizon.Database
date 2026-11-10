namespace Mizon.Database.Entities;

public class MusicLanguage : IEntityTable<int>, ICreate, IUpdate
{
    public int Id { get; set; }
    public int MusicId { get; set; }
    public Music? Music { get; set; }
    public byte LanguageId { get; set; }
    public Language? Language { get; set; }
    public DateTimeOffset CreateDateTime { get; set; }
    public DateTimeOffset? UpdateDateTime { get; set; }
}

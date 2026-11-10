namespace Mizon.Database.Entities;

public class Language : IEntityTable<byte>, IPublicId, ICreate, IUpdate
{
    public byte Id { get; set; }
    public Guid PublicId { get; set; }
    public string Title { get; set; } = null!;
    public string? PersianTitle { get; set; }
    public DateTimeOffset CreateDateTime { get; set; }
    public DateTimeOffset? UpdateDateTime { get; set; }
    public List<MusicLanguage> MusicLanguages { get; set; } = [];
    public List<MusicLyric> MusicLyrics { get; set; } = [];
}

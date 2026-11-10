namespace Mizon.Database.Entities;

public class MusicLabel : IEntityTable<int>, IPublicId, ICreate, IUpdate
{
    public int Id { get; set; }
    public Guid PublicId { get; set; }
    public string Title { get; set; } = null!;
    public string? PersianTitle { get; set; }
    public DateTimeOffset CreateDateTime { get; set; }
    public DateTimeOffset? UpdateDateTime { get; set; }
    public List<Music> Musics { get; set; } = [];
}

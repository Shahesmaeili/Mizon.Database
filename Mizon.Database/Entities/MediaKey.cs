namespace Mizon.Database.Entities;

public class MediaKey : IEntityTable<int>, IPublicId, ICreate, IUpdate
{
    public int Id { get; set; }
    public Guid PublicId { get; set; }

    public string KeyData { get; set; } = null!;

    public bool IsRevoked { get; set; }

    public DateTimeOffset CreateDateTime { get; set; }
    public DateTimeOffset? UpdateDateTime { get; set; }

    public List<Media> Medias { get; set; } = [];
}

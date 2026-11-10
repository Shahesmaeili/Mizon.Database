namespace Mizon.Database.Entities;

public class MediaStorageType : IEntityTable<byte>, IPublicId, ICreate, IUpdate
{
    public byte Id { get; set; }
    public Guid PublicId { get; set; }

    public string Title { get; set; } = null!;

    public DateTimeOffset CreateDateTime { get; set; }
    public DateTimeOffset? UpdateDateTime { get; set; }
    public List<Media> Medias { get; set; } = [];
}

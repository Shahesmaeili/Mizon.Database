namespace Mizon.Database.Entities;

public class MusicFeature : IEntityTable<int>, IPublicId, ICreate, IUpdate
{
    public int Id { get; set; }
    public Guid PublicId { get; set; }
    public int MusicId { get; set; }
    public Music? Music { get; set; }
    public int ContentMediaId { get; set; }
    public Media? ContentMedia { get; set; }
    public int? PreviewMediaId { get; set; }
    public Media? PreviewMedia { get; set; }
    public byte MusicFeatureContentTypeId { get; set; }
    public MusicFeatureContentType? MusicFeatureContentType { get; set; }
    public int DisplaySeconds { get; set; } = 8;
    public bool IsActive { get; set; } = true;
    public DateTimeOffset? StartDateTime { get; set; }
    public DateTimeOffset? ExpireDateTime { get; set; }
    public DateTimeOffset CreateDateTime { get; set; }
    public DateTimeOffset? UpdateDateTime { get; set; }
}

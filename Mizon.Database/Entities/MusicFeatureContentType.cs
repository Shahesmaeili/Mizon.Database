namespace Mizon.Database.Entities;

public class MusicFeatureContentType : IEntityTable<byte>, IPublicId, ICreate, IUpdate
{
    public byte Id { get; set; }
    public Guid PublicId { get; set; }
    public string Code { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string? PersianTitle { get; set; }
    public DateTimeOffset CreateDateTime { get; set; }
    public DateTimeOffset? UpdateDateTime { get; set; }
    public List<MusicFeature> MusicFeatures { get; set; } = [];
}

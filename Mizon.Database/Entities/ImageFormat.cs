namespace Mizon.Database.Entities;

public class ImageFormat : IEntityTable<byte>, IPublicId, ICreate, IUpdate
{
    public byte Id { get; set; }
    public Guid PublicId { get; set; }
    public string Title { get; set; } = null!;
    public DateTimeOffset CreateDateTime { get; set; }
    public DateTimeOffset? UpdateDateTime { get; set; }
    public List<ClientProfile> ClientProfiles { get; set; } = [];
    public List<MusicCover> MusicCovers { get; set; } = [];

}

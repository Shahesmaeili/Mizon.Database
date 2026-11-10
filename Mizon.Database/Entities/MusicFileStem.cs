namespace Mizon.Database.Entities;

public class MusicFileStem : IEntityTable<int>, IPublicId, ICreate, IUpdate
{
    public int Id { get; set; }
    public Guid PublicId { get; set; }
    public int MusicFileId { get; set; }
    public MusicFile? MusicFile { get; set; }
    public byte MusicFileStemTypeId { get; set; }
    public MusicFileStemType? MusicFileStemType { get; set; }
    public int MediaId { get; set; }
    public Media? Media { get; set; }
    public DateTimeOffset CreateDateTime { get; set; }
    public DateTimeOffset? UpdateDateTime { get; set; }
}

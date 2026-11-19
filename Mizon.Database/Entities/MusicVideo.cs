namespace Mizon.Database.Entities;

public class MusicVideo : IEntityTable<int>, IPublicId, ICreate, IUpdate
{
    public int Id { get; set; }
    public Guid PublicId { get; set; }

    public int MusicId { get; set; }
    public Music? Music { get; set; }

    public int MediaId { get; set; }
    public Media? Media { get; set; }

    public int? CoverMediaId { get; set; }
    public Media? CoverMedia { get; set; }

    public bool IsActive { get; set; }
    public DateTimeOffset CreateDateTime { get; set; }
    public DateTimeOffset? UpdateDateTime { get; set; }
}

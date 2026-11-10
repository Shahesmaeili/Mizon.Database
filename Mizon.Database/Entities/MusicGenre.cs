namespace Mizon.Database.Entities;

public class MusicGenre : IEntityTable<int>, ICreate, IUpdate
{
    public int Id { get; set; }
    public int MusicId { get; set; }
    public Music? Music { get; set; }
    public byte MusicGenreTypeId { get; set; }
    public MusicGenreType? MusicGenreType { get; set; }
    public DateTimeOffset CreateDateTime { get; set; }
    public DateTimeOffset? UpdateDateTime { get; set; }
}

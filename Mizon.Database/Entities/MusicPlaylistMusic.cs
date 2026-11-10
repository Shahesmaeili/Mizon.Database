namespace Mizon.Database.Entities;

public class MusicPlaylistMusic : IEntityTable<int>, ICreate
{
    public int Id { get; set; }

    public int MusicPlaylistId { get; set; }
    public MusicPlaylist? MusicPlaylist { get; set; }

    public int MusicId { get; set; }
    public Music? Music { get; set; }

    public DateTimeOffset CreateDateTime { get; set; }
}

namespace Mizon.Database.Entities;

public class MusicPlaylist : IEntityTable<int>, IPublicId, ICreate, IUpdate
{
    public int Id { get; set; }
    public Guid PublicId { get; set; }

    public int ClientId { get; set; }
    public Client? Client { get; set; }

    public string Title { get; set; } = null!;

    public List<MusicPlaylistMusic> MusicPlaylistMusics { get; set; } = [];

    public DateTimeOffset CreateDateTime { get; set; }
    public DateTimeOffset? UpdateDateTime { get; set; }

    public DateTimeOffset LastActivityDateTime { get; private set; }
}

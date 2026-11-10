namespace Mizon.Database.Entities;

public class PlatformVersion :  IEntityTable<short>, IPublicId, ICreate, IUpdate
{
    public short Id { get; set; }
    public Guid PublicId { get; set; }
    public byte PlatformId { get; set; }
    public Platform? Platform { get; set; }
    public string Version { get; set; } = null!;
    public DateTimeOffset CreateDateTime { get; set; }
    public DateTimeOffset? UpdateDateTime { get; set; }
    public List<ClientSession> ClientSessions { get; set; } = [];
    public List<MusicLike> MusicLikes { get; set; } = [];
    public List<MusicView> MusicViews { get; set; } = [];
    public List<MusicPlay> MusicPlays { get; set; } = [];
    public List<MusicReaction> MusicReactions { get; set; } = [];
    public List<StoryView> StoryViews { get; set; } = [];
    public List<StoryLike> StoryLikes { get; set; } = [];

}

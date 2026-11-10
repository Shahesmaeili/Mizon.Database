namespace Mizon.Database.Entities;

public class Client : IEntityTable<int>, IPublicId, ICreate, IUpdate
{
    public int Id { get; set; }
    public Guid PublicId { get; set; }

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? NickName { get; set; }
    public short TokenVersion { get; set; }

    public byte? ClientPrivacyTypeId { get; set; }
    public ClientPrivacyType? ClientPrivacyType { get; set; }
    public int? ClientMoodTypeId { get; set; }
    public ClientMoodType? ClientMoodType { get; set; }

    public List<ClientProfile> ClientProfiles { get; set; } = [];
    public List<ClientUsername> ClientUsernames { get; set; } = [];
    public List<ClientEmail> ClientEmails { get; set; } = [];
    public List<ClientPassword> ClientPasswords { get; set; } = [];
    public List<ClientSession> ClientSessions { get; set; } = [];
    public List<ClientPrivacyHistory> ClientPrivacyHistories { get; set; } = [];
    public List<ClientPrivacyHistory> ClientPrivacyHistoryActions { get; set; } = [];
    public List<ClientFollow> ClientFollowings { get; set; } = [];
    public List<ClientFollow> ClientFollowers { get; set; } = [];
    public List<ClientFollowHistory> ClientFollowHistoryActions { get; set; } = [];
    public List<MusicLike> MusicLikes { get; set; } = [];
    public List<MusicView> MusicViews { get; set; } = [];
    public List<MusicPlay> MusicPlays { get; set; } = [];
    public List<MusicReaction> MusicReactions { get; set; } = [];
    public List<MusicComment> MusicComments { get; set; } = [];
    public List<MusicPlaylist> MusicPlaylists { get; set; } = [];
    public List<Story> Stories { get; set; } = [];
    public List<StoryView> StoryViews { get; set; } = [];
    public List<StoryLike> StoryLikes { get; set; } = [];
    public List<StoryClientWidget> StoryClientWidgets { get; set; } = [];
    public DateTimeOffset CreateDateTime { get; set; }
    public DateTimeOffset? UpdateDateTime { get; set; }
}

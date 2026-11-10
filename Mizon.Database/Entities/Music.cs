namespace Mizon.Database.Entities;

public class Music : IEntityTable<int>, IPublicId, ICreate, IUpdate
{
    public int Id { get; set; }
    public Guid PublicId { get; set; }

    public string Title { get; set; } = null!;

    public string? PersianTitle { get; set; }

    public DateTimeOffset? ReleaseDateTime { get; set; }

    public int? MusicLabelId { get; set; }
    public MusicLabel? MusicLabel { get; set; }

    public MusicCover? MusicCover { get; set; }

   // public MusicKey? MusicKey { get; set; }

    public int? MusicAlbumId { get; set; }
    public MusicAlbum? MusicAlbum { get; set; }

    public bool IsActive { get; set; }

    public DateTimeOffset CreateDateTime { get; set; }
    public DateTimeOffset? UpdateDateTime { get; set; }

    public List<MusicFile> MusicFiles { get; set; } = [];
    public List<MusicFeature> MusicFeatures { get; set; } = [];

    public List<MusicGenre> MusicGenres { get; set; } = [];

    public List<MusicContributor> MusicContributors { get; set; } = [];

    public List<MusicView> MusicViews { get; set; } = [];
    public List<MusicPlay> MusicPlays { get; set; } = [];

    public List<MusicLike> MusicLikes { get; set; } = [];

    public List<MusicLyric> MusicLyrics { get; set; } = [];

    public List<MusicLanguage> MusicLanguages { get; set; } = [];
    public List<MusicReaction> MusicReactions { get; set; } = [];
    public List<MusicComment> MusicComments { get; set; } = [];
    public List<MusicPlaylistMusic> MusicPlaylistMusics { get; set; } = [];
    public List<StoryMusicWidget> StoryMusicWidgets { get; set; } = [];

}

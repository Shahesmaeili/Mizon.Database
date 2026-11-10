namespace Mizon.Database.Entities;

public class Media : IEntityTable<int>, IPublicId, ICreate, IUpdate
{
    public int Id { get; set; }
    public Guid PublicId { get; set; }
    public string StoragePath { get; set; } = null!;
    
    public byte[] EncryptionIV { get; set; } = null!;

    public int MediaKeyId { get; set; }
    public MediaKey? MediaKey { get; set; }

    public byte MediaEncryptionTypeId { get; set; }
    public MediaEncryptionType? MediaEncryptionType { get; set; }
    public byte MediaStorageTypeId { get; set; }
    public MediaStorageType? MediaStorageType { get; set; }
    public int TotalChunks { get; set; }
    public int ChunkSize { get; set; }
    public string FileHash { get; set; } = null!;
    public string FileName { get; set; } = null!;

    public long FileSize { get; set; }

    public DateTimeOffset CreateDateTime { get; set; }
    public DateTimeOffset? UpdateDateTime { get; set; }

    public List<ClientProfile> ClientProfiles { get; set; } = [];
    public List<ClientMoodType> AnimationClientMoodTypes { get; set; } = [];
    public List<ClientMoodType> PreviewClientMoodTypes { get; set; } = [];
    public List<ClientMoodEffect> ClientMoodEffects { get; set; } = [];

    public List<MusicCover> MusicCovers { get; set; } = [];

    public List<MusicFile> MusicFiles { get; set; } = [];
    public List<Story> ContentStories { get; set; } = [];
    public List<Story> PreviewStories { get; set; } = [];
    public List<MusicFeature> ContentMusicFeatures { get; set; } = [];
    public List<MusicFeature> PreviewMusicFeatures { get; set; } = [];
}

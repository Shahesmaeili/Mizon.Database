namespace Mizon.Database.Entities;

public class MusicGenreType : IEntityTable<byte>, IPublicId, ICreate, IUpdate
{
    public byte Id { get; set; }
    public Guid PublicId { get; set; }
    public string Title { get; set; } = null!;
    public string? PersianTitle { get; set; }
    public string AccentColorHex { get; set; } = null!;
    public string IconSymbol { get; set; } = null!;
    public DateTimeOffset CreateDateTime { get; set; }
    public DateTimeOffset? UpdateDateTime { get; set; }
    public List<MusicGenre> MusicGenres { get; set; } = [];
}

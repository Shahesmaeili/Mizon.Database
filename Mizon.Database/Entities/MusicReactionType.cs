namespace Mizon.Database.Entities;

public sealed class MusicReactionType : IEntityTable<byte>, IPublicId, ICreate, IUpdate
{
    public byte Id { get; set; }
    public Guid PublicId { get; set; }
    public string Emoji { get; set; } = null!;
    public bool IsActive { get; set; }
    public DateTimeOffset CreateDateTime { get; set; }
    public DateTimeOffset? UpdateDateTime { get; set; }
    public List<MusicReaction> MusicReactions { get; set; } = [];
}

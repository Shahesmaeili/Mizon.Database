namespace Mizon.Database.Entities;

public sealed class MusicComment : IEntityTable<int>, IPublicId, ICreate, IUpdate
{
    public int Id { get; set; }
    public Guid PublicId { get; set; }

    public int MusicId { get; set; }
    public Music? Music { get; set; }

    public int ClientId { get; set; }
    public Client? Client { get; set; }

    public string Text { get; set; } = null!;
    public TimeSpan? Timestamp { get; set; }

    public DateTimeOffset CreateDateTime { get; set; }
    public DateTimeOffset? UpdateDateTime { get; set; }
}

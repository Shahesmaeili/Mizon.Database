namespace Mizon.Database.Entities;

public sealed class MusicCommentVote : IEntityTable<int>, ICreate, IUpdate
{
    public int Id { get; set; }
    public int MusicCommentId { get; set; }
    public MusicComment? MusicComment { get; set; }
    public int ClientId { get; set; }
    public Client? Client { get; set; }
    public bool IsLike { get; set; }
    public DateTimeOffset CreateDateTime { get; set; }
    public DateTimeOffset? UpdateDateTime { get; set; }
}

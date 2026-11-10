namespace Mizon.Database.Entities;

public class Story : IEntityTable<int>, IPublicId, ICreate, IUpdate
{
    public int Id { get; set; }
    public Guid PublicId { get; set; }

    public int ClientId { get; set; }
    public Client? Client { get; set; }

    public int ContentMediaId { get; set; }
    public Media? ContentMedia { get; set; }

    public int? PreviewMediaId { get; set; }
    public Media? PreviewMedia { get; set; }

    public byte StoryContentTypeId { get; set; }
    public StoryContentType? StoryContentType { get; set; }
    public string? Title { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTimeOffset? ExpireDateTime { get; set; }

    public DateTimeOffset CreateDateTime { get; set; }
    public DateTimeOffset? UpdateDateTime { get; set; }

    public List<StoryView> StoryViews { get; set; } = [];
    public List<StoryLike> StoryLikes { get; set; } = [];
    public List<StoryWidget> StoryWidgets { get; set; } = [];
}

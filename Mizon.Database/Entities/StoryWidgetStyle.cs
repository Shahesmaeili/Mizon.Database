namespace Mizon.Database.Entities;

public class StoryWidgetStyle : IEntityTable<short>, IPublicId, ICreate, IUpdate
{
    public short Id { get; set; }
    public Guid PublicId { get; set; }
    public byte StoryWidgetTypeId { get; set; }
    public StoryWidgetType? StoryWidgetType { get; set; }
    public string Title { get; set; } = null!;
    public string? PersianTitle { get; set; }
    public DateTimeOffset CreateDateTime { get; set; }
    public DateTimeOffset? UpdateDateTime { get; set; }
    public List<StoryWidget> StoryWidgets { get; set; } = [];
}

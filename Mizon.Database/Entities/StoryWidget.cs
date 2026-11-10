namespace Mizon.Database.Entities;

public class StoryWidget : IEntityTable<int>, IPublicId, ICreate, IUpdate
{
    public int Id { get; set; }
    public Guid PublicId { get; set; }
    public int StoryId { get; set; }
    public Story? Story { get; set; }
    public byte StoryWidgetTypeId { get; set; }
    public StoryWidgetType? StoryWidgetType { get; set; }
    public short StoryWidgetStyleId { get; set; }
    public StoryWidgetStyle? StoryWidgetStyle { get; set; }
    public float X { get; set; }
    public float Y { get; set; }
    public float Width { get; set; }
    public float Height { get; set; }
    public float Rotation { get; set; }
    public short ZIndex { get; set; }
    public DateTimeOffset CreateDateTime { get; set; }
    public DateTimeOffset? UpdateDateTime { get; set; }
    public StoryMusicWidget? MusicWidget { get; set; }
    public StoryClientWidget? ClientWidget { get; set; }
}

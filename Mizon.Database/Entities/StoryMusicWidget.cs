namespace Mizon.Database.Entities;

public class StoryMusicWidget : IEntityTable<int>
{
    public int Id { get; set; }
    public int StoryWidgetId { get; set; }
    public StoryWidget? StoryWidget { get; set; }
    public int MusicId { get; set; }
    public Music? Music { get; set; }
}

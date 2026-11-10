namespace Mizon.Database.Entities;

public class StoryClientWidget : IEntityTable<int>
{
    public int Id { get; set; }
    public int StoryWidgetId { get; set; }
    public StoryWidget? StoryWidget { get; set; }
    public int ClientId { get; set; }
    public Client? Client { get; set; }
}

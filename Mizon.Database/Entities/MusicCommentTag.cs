namespace Mizon.Database.Entities;

public sealed class MusicCommentTag : IEntityTable<int>, ICreate
{
    public int Id { get; set; }
    public int MusicCommentId { get; set; }
    public MusicComment? MusicComment { get; set; }
    public int? TaggedPersonId { get; set; }
    public Person? TaggedPerson { get; set; }
    public int? TaggedClientId { get; set; }
    public Client? TaggedClient { get; set; }
    public int? TaggedMusicId { get; set; }
    public Music? TaggedMusic { get; set; }
    public int? TaggedMusicVideoId { get; set; }
    public MusicVideo? TaggedMusicVideo { get; set; }
    public DateTimeOffset CreateDateTime { get; set; }
}

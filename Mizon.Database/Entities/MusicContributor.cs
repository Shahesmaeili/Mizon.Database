namespace Mizon.Database.Entities;

public class MusicContributor : IEntityTable<int>, ICreate, IUpdate
{
    public int Id { get; set; }

    public int MusicId { get; set; }
    public Music? Music { get; set; }

    public byte MusicContributorTypeId { get; set; }
    public MusicContributorType? MusicContributorType { get; set; }

    public int PersonId { get; set; }
    public Person? Person { get; set; }


    public DateTimeOffset CreateDateTime { get; set; }
    public DateTimeOffset? UpdateDateTime { get; set; }
}

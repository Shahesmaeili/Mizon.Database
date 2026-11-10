namespace Mizon.Database.Entities;

public class Person : IEntityTable<int>, IPublicId, ICreate, IUpdate
{
    public int Id { get; set; }
    public Guid PublicId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;

    public int? ProfileMediaId { get; set; }
    public Media? ProfileMedia { get; set; }

    public DateTimeOffset CreateDateTime { get; set; }
    public DateTimeOffset? UpdateDateTime { get; set; }

    public List<MusicContributor> MusicContributors { get; set; } = [];
    public List<ClientFollow> ClientFollowers { get; set; } = [];

}

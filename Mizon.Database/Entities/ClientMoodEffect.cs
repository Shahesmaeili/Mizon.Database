namespace Mizon.Database.Entities;

public sealed class ClientMoodEffect : IEntityTable<int>, IPublicId, ICreate, IUpdate
{
    public int Id { get; set; }
    public Guid PublicId { get; set; }
    public int ClientMoodTypeId { get; set; }
    public ClientMoodType? ClientMoodType { get; set; }
    public int MediaId { get; set; }
    public Media? Media { get; set; }
    public bool IsActive { get; set; }
    public DateTimeOffset CreateDateTime { get; set; }
    public DateTimeOffset? UpdateDateTime { get; set; }
}


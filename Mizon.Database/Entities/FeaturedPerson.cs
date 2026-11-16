namespace Mizon.Database.Entities;

public sealed class FeaturedPerson : IEntityTable<int>, IPublicId, ICreate, IUpdate
{
    public int Id { get; set; }
    public Guid PublicId { get; set; }
    public byte FeaturedPersonTypeId { get; set; }
    public FeaturedPersonType? FeaturedPersonType { get; set; }
    public int PersonId { get; set; }
    public Person? Person { get; set; }
    public short SortOrder { get; set; }
    public string? AccentColor { get; set; }
    public string? ModelAttribution { get; set; }
    public float ModelYawInDegrees { get; set; }
    public float ModelViewScale { get; set; } = 1;
    public float ModelVerticalFocus { get; set; }
    public DateTimeOffset CreateDateTime { get; set; }
    public DateTimeOffset? UpdateDateTime { get; set; }
}

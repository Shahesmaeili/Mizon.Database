namespace Mizon.Database.Entities;

public sealed class ClientMoodType : IEntityTable<int>, IPublicId, ICreate, IUpdate
{
    public int Id { get; set; }
    public Guid PublicId { get; set; }
    public string Emoji { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string? PersianTitle { get; set; }
    public int AnimationMediaId { get; set; }
    public Media? AnimationMedia { get; set; }
    public int? PreviewMediaId { get; set; }
    public Media? PreviewMedia { get; set; }
    public bool IsActive { get; set; }
    public DateTimeOffset CreateDateTime { get; set; }
    public DateTimeOffset? UpdateDateTime { get; set; }
    public List<Client> Clients { get; set; } = [];
    public List<ClientMoodEffect> ClientMoodEffects { get; set; } = [];
}


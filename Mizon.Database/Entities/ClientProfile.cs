namespace Mizon.Database.Entities;

public class ClientProfile : IEntityTable<int>, IPublicId, ICreate, IUpdate
{
    public int Id { get; set; }
    public Guid PublicId { get; set; }

    public int ClientId { get; set; }
    public Client? Client { get; set; }

    public int MediaId { get; set; }
    public Media? Media { get; set; }

    public string Blurhash { get; set; } = null!;

    public short Width {  get; set; }
    public short Height { get; set; }

    public byte ImageFormatId { get; set; }
    public ImageFormat? ImageFormat { get; set; }

    public string PrimaryAccentColor { get; set; } = null!;

    public bool IsDefault { get; set; }

    public DateTimeOffset CreateDateTime { get; set; }
    public DateTimeOffset? UpdateDateTime { get; set; }
}

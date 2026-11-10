namespace Mizon.Database.Entities;

public class MusicCover : ICreate, IUpdate
{
    public int MusicId { get; set; }
    public Music? Music { get; set; }

    public int MediaId { get; set; }
    public Media? Media { get; set; }

    public string Blurhash { get; set; } = null!;

    public short Width { get; set; }
    public short Height { get; set; }

    public byte ImageFormatId { get; set; }
    public ImageFormat? ImageFormat { get; set; }

    public string PrimaryAccentColor { get; set; } = null!;

    public DateTimeOffset CreateDateTime { get; set; }
    public DateTimeOffset? UpdateDateTime { get; set; }
}

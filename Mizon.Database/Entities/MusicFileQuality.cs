namespace Mizon.Database.Entities;

public class MusicFileQuality : IEntityTable<int>, IPublicId, ICreate, IUpdate
{
    public int Id { get; set; }
    public Guid PublicId { get; set; }

    public int MusicFileId { get; set; }
    public MusicFile? MusicFile { get; set; }

    public int? BitrateKbps { get; set; }
    public bool IsVariableBitRate { get; set; }
    public int SampleRateHz { get; set; }
    public byte ChannelCount { get; set; }

    public byte MusicFileQualityChannelId { get; set; }
    public MusicFileQualityChannel? MusicFileQualityChannel { get; set; }
    public byte MusicFileQualityCodecId { get; set; }
    public MusicFileQualityCodec? MusicFileQualityCodec { get; set; }
    public byte MusicFileQualityFormatId { get; set; }
    public MusicFileQualityFormat? MusicFileQualityFormat { get; set; }
    public byte? MusicFileQualityBitDepthId { get; set; }
    public MusicFileQualityBitDepth? MusicFileQualityBitDepth { get; set; }
    public byte? MusicFileQualitySampleFormatId { get; set; }
    public MusicFileQualitySampleFormat? MusicFileQualitySampleFormat { get; set; }
    public byte? MusicFileQualityEncoderId { get; set; }
    public MusicFileQualityEncoder? MusicFileQualityEncoder { get; set; }
    public byte? MusicFileQualityEncoderModeId { get; set; }
    public MusicFileQualityEncoderMode? MusicFileQualityEncoderMode { get; set; }

    public DateTimeOffset CreateDateTime { get; set; }
    public DateTimeOffset? UpdateDateTime { get; set; }
}

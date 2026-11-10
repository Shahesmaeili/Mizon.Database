namespace Mizon.Database.Entities;

public class MusicFile : IEntityTable<int>, IPublicId, ICreate, IUpdate
{
    public int Id { get; set; }
    public Guid PublicId { get; set; }

    public int MusicId { get; set; }
    public Music? Music { get; set; }

    public MusicFileQuality? MusicFileQuality { get; set; }

    public int MediaId { get; set; }
    public Media? Media { get; set; }

    //public int MusicFileTypeId { get; set; }
    //public MusicFileType? MusicFileType { get; set; }

    public TimeSpan Duration { get; set; }

    public DateTimeOffset CreateDateTime { get; set; }
    public DateTimeOffset? UpdateDateTime { get; set; }

   // public MusicFileFeature? MusicFileFeature { get; set; }

    public List<MusicFileWaveform> MusicFileWaveforms { get; set; } = [];
    public List<MusicFileStem> MusicFileStems { get; set; } = [];

    //public List<MusicFileStructure> MusicFileStructures { get; set; } = [];

    //public List<MusicFileBeat> Beats { get; set; } = [];

}

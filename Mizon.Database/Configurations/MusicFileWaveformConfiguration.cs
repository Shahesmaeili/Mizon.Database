namespace Mizon.Database.Configurations;

internal sealed class MusicFileWaveformConfiguration : IEntityTypeConfiguration<MusicFileWaveform>
{
    public void Configure(EntityTypeBuilder<MusicFileWaveform> builder)
    {


        builder.HasOne(x => x.MusicFile)
.WithMany(x => x.MusicFileWaveforms)
.HasForeignKey(x => x.MusicFileId)
.OnDelete(DeleteBehavior.Restrict);

    }
}
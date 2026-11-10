namespace Mizon.Database.Configurations;

internal sealed class MusicFileConfiguration : IEntityTypeConfiguration<MusicFile>
{
    public void Configure(EntityTypeBuilder<MusicFile> builder)
    {


        builder.HasOne(x => x.Music)
.WithMany(x => x.MusicFiles)
.HasForeignKey(x => x.MusicId)
.OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Media)
.WithMany(x => x.MusicFiles)
.HasForeignKey(x => x.MediaId)
.OnDelete(DeleteBehavior.Restrict);


    }
}
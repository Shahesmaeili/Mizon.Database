namespace Mizon.Database.Configurations;

internal sealed class MusicGenreConfiguration : IEntityTypeConfiguration<MusicGenre>
{
    public void Configure(EntityTypeBuilder<MusicGenre> builder)
    {
        builder.HasOne(x => x.Music)
.WithMany(x => x.MusicGenres)
.HasForeignKey(x => x.MusicId)
.OnDelete(DeleteBehavior.Restrict);


        builder.HasOne(x => x.MusicGenreType)
.WithMany(x => x.MusicGenres)
.HasForeignKey(x => x.MusicGenreTypeId)
.OnDelete(DeleteBehavior.Restrict);
    }
}
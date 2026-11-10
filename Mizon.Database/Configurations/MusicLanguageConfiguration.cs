namespace Mizon.Database.Configurations;

internal sealed class MusicLanguageConfiguration : IEntityTypeConfiguration<MusicLanguage>
{
    public void Configure(EntityTypeBuilder<MusicLanguage> builder)
    {
        builder.HasOne(x => x.Music)
.WithMany(x => x.MusicLanguages)
.HasForeignKey(x => x.MusicId)
.OnDelete(DeleteBehavior.Restrict);


        builder.HasOne(x => x.Language)
.WithMany(x => x.MusicLanguages)
.HasForeignKey(x => x.LanguageId)
.OnDelete(DeleteBehavior.Restrict);
    }
}
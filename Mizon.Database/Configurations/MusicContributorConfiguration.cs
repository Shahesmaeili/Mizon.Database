namespace Mizon.Database.Configurations;

internal sealed class MusicContributorConfiguration : IEntityTypeConfiguration<MusicContributor>
{
    public void Configure(EntityTypeBuilder<MusicContributor> builder)
    {
        builder.HasOne(x => x.Music)
.WithMany(x => x.MusicContributors)
.HasForeignKey(x => x.MusicId)
.OnDelete(DeleteBehavior.Restrict);


        builder.HasOne(x => x.MusicContributorType)
.WithMany(x => x.MusicContributors)
.HasForeignKey(x => x.MusicContributorTypeId)
.OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Person)
.WithMany(x => x.MusicContributors)
.HasForeignKey(x => x.PersonId)
.OnDelete(DeleteBehavior.Restrict);
    }
}
namespace Mizon.Database.Configurations;

internal sealed class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(64);

        builder.Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(64);

        builder.HasOne(x => x.ProfileMedia)
            .WithMany()
            .HasForeignKey(x => x.ProfileMediaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

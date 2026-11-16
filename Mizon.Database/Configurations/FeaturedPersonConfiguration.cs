namespace Mizon.Database.Configurations;

internal sealed class FeaturedPersonConfiguration : IEntityTypeConfiguration<FeaturedPerson>
{
    public void Configure(EntityTypeBuilder<FeaturedPerson> builder)
    {
        builder.ToTable(table => table.HasCheckConstraint("CK_FeaturedPersons_SortOrder", "[SortOrder] > 0"));
        builder.HasIndex(x => new { x.FeaturedPersonTypeId, x.SortOrder }).IsUnique();
        builder.HasIndex(x => new { x.FeaturedPersonTypeId, x.PersonId }).IsUnique();
        builder.Property(x => x.AccentColor).HasMaxLength(7);
        builder.Property(x => x.ModelAttribution).HasMaxLength(240);
        builder.HasOne(x => x.FeaturedPersonType).WithMany(x => x.FeaturedPersons)
            .HasForeignKey(x => x.FeaturedPersonTypeId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.Person).WithMany(x => x.FeaturedPersons)
            .HasForeignKey(x => x.PersonId).OnDelete(DeleteBehavior.Cascade);
    }
}

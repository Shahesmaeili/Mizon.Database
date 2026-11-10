namespace Mizon.Database.Configurations;

internal sealed class MusicCommentConfiguration : IEntityTypeConfiguration<MusicComment>
{
    public void Configure(EntityTypeBuilder<MusicComment> builder)
    {
        builder.Property(x => x.Text)
            .HasMaxLength(2000)
            .IsRequired();

        builder.HasOne(x => x.Music)
            .WithMany(x => x.MusicComments)
            .HasForeignKey(x => x.MusicId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Client)
            .WithMany(x => x.MusicComments)
            .HasForeignKey(x => x.ClientId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new { x.MusicId, x.Timestamp });
    }
}

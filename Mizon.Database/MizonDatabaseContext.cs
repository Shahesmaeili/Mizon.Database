using Mizon.Database.Configurations;

namespace Mizon.Database;

#pragma warning disable IL2026
public sealed class MizonDatabaseContext(DbContextOptions<MizonDatabaseContext> options) 
    : DbContext(options)
{
#pragma warning restore IL2026


    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        ApplyEntityMetadata();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        if (cancellationToken.IsCancellationRequested)
            return Task.FromCanceled<int>(cancellationToken);

        ApplyEntityMetadata();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    private void ApplyEntityMetadata()
    {
        var now = DateTimeOffset.UtcNow;

        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.State == EntityState.Added)
            {
                if (entry.Entity is ICreate create)
                    create.CreateDateTime = now;

                if (entry.Entity is IPublicId publicId && publicId.PublicId == Guid.Empty)
                    publicId.PublicId = Guid.CreateVersion7();
            }

            if (entry.State == EntityState.Modified)
            {
                if (entry.Entity is IUpdate)
                    entry.Property(nameof(IUpdate.UpdateDateTime)).CurrentValue = now;
            }
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.ApplyConfiguration(new ClientConfiguration());
        modelBuilder.ApplyConfiguration(new ClientMoodTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ClientMoodEffectConfiguration());
        modelBuilder.ApplyConfiguration(new ClientPrivacyTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ClientPrivacyHistoryConfiguration());
        modelBuilder.ApplyConfiguration(new ClientFollowStatusTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ClientFollowActionTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ClientFollowConfiguration());
        modelBuilder.ApplyConfiguration(new ClientFollowHistoryConfiguration());
        modelBuilder.ApplyConfiguration(new ClientEmailConfiguration());
        modelBuilder.ApplyConfiguration(new ClientPasswordConfiguration());
        modelBuilder.ApplyConfiguration(new ClientProfileConfiguration());
        modelBuilder.ApplyConfiguration(new ClientSessionConfiguration());
        modelBuilder.ApplyConfiguration(new ClientSessionIpConfiguration());
        modelBuilder.ApplyConfiguration(new ClientUsernameConfiguration());

        modelBuilder.ApplyConfiguration(new ImageFormatConfiguration());
        modelBuilder.ApplyConfiguration(new LanguageConfiguration());
        modelBuilder.ApplyConfiguration(new MediaConfiguration());
        modelBuilder.ApplyConfiguration(new MediaEncryptionTypeConfiguration());
        modelBuilder.ApplyConfiguration(new MediaKeyConfiguration());
        modelBuilder.ApplyConfiguration(new MediaStorageTypeConfiguration());
        modelBuilder.ApplyConfiguration(new MusicAlbumConfiguration());
        modelBuilder.ApplyConfiguration(new MusicConfiguration());
        modelBuilder.ApplyConfiguration(new MusicFeatureConfiguration());
        modelBuilder.ApplyConfiguration(new MusicFeatureContentTypeConfiguration());
        modelBuilder.ApplyConfiguration(new MusicContributorConfiguration());
        modelBuilder.ApplyConfiguration(new MusicContributorTypeConfiguration());
        modelBuilder.ApplyConfiguration(new MusicCoverConfiguration());
        modelBuilder.ApplyConfiguration(new MusicFileConfiguration());
        modelBuilder.ApplyConfiguration(new MusicFileQualityConfiguration());
        modelBuilder.ApplyConfiguration(new MusicFileQualityBitDepthConfiguration());
        modelBuilder.ApplyConfiguration(new MusicFileQualityChannelConfiguration());
        modelBuilder.ApplyConfiguration(new MusicFileQualityCodecConfiguration());
        modelBuilder.ApplyConfiguration(new MusicFileQualityEncoderConfiguration());
        modelBuilder.ApplyConfiguration(new MusicFileQualityEncoderModeConfiguration());
        modelBuilder.ApplyConfiguration(new MusicFileQualityFormatConfiguration());
        modelBuilder.ApplyConfiguration(new MusicFileQualitySampleFormatConfiguration());
        modelBuilder.ApplyConfiguration(new MusicFileWaveformConfiguration());
        modelBuilder.ApplyConfiguration(new MusicFileStemConfiguration());
        modelBuilder.ApplyConfiguration(new MusicFileStemTypeConfiguration());
        modelBuilder.ApplyConfiguration(new MusicFileStemPitchConfiguration());
        modelBuilder.ApplyConfiguration(new PersonConfiguration());


        modelBuilder.ApplyConfiguration(new MusicGenreConfiguration());
        modelBuilder.ApplyConfiguration(new MusicGenreTypeConfiguration());
        modelBuilder.ApplyConfiguration(new MusicLabelConfiguration());
        modelBuilder.ApplyConfiguration(new MusicLanguageConfiguration());
        modelBuilder.ApplyConfiguration(new MusicLikeConfiguration());
        modelBuilder.ApplyConfiguration(new MusicReactionConfiguration());
        modelBuilder.ApplyConfiguration(new MusicReactionTypeConfiguration());
        modelBuilder.ApplyConfiguration(new MusicPlaylistConfiguration());
        modelBuilder.ApplyConfiguration(new MusicPlaylistMusicConfiguration());

        

        modelBuilder.ApplyConfiguration(new MusicViewConfiguration());
        modelBuilder.ApplyConfiguration(new MusicPlayConfiguration());
        FollowingActivityConfiguration.Configure(modelBuilder);
        modelBuilder.ApplyConfiguration(new StoryConfiguration());
        modelBuilder.ApplyConfiguration(new StoryContentTypeConfiguration());
        modelBuilder.ApplyConfiguration(new StoryViewConfiguration());
        modelBuilder.ApplyConfiguration(new StoryLikeConfiguration());
        modelBuilder.ApplyConfiguration(new StoryWidgetConfiguration());
        modelBuilder.ApplyConfiguration(new StoryWidgetTypeConfiguration());
        modelBuilder.ApplyConfiguration(new StoryWidgetStyleConfiguration());
        modelBuilder.ApplyConfiguration(new StoryMusicWidgetConfiguration());
        modelBuilder.ApplyConfiguration(new StoryClientWidgetConfiguration());


        modelBuilder.ApplyConfiguration(new PlatformConfiguration());
        modelBuilder.ApplyConfiguration(new PlatformVersionConfiguration());


        // Index for PublicId
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(IPublicId).IsAssignableFrom(entityType.ClrType))
            {
                modelBuilder
                    .Entity(entityType.ClrType)
                    .HasIndex(nameof(IPublicId.PublicId))
                    .IsUnique();
            }
        }
    }


    public DbSet<Client> Clients => Set<Client>();
    public DbSet<ClientMoodType> ClientMoodTypes => Set<ClientMoodType>();
    public DbSet<ClientMoodEffect> ClientMoodEffects => Set<ClientMoodEffect>();
    public DbSet<ClientPrivacyType> ClientPrivacyTypes => Set<ClientPrivacyType>();
    public DbSet<ClientPrivacyHistory> ClientPrivacyHistories => Set<ClientPrivacyHistory>();
    public DbSet<ClientFollowStatusType> ClientFollowStatusTypes => Set<ClientFollowStatusType>();
    public DbSet<ClientFollowActionType> ClientFollowActionTypes => Set<ClientFollowActionType>();
    public DbSet<ClientFollow> ClientFollows => Set<ClientFollow>();
    public DbSet<ClientFollowHistory> ClientFollowHistories => Set<ClientFollowHistory>();
    public DbSet<ClientEmail> ClientEmails => Set<ClientEmail>();
    public DbSet<ClientPassword> ClientPasswords => Set<ClientPassword>();
    public DbSet<ClientProfile> ClientProfiles => Set<ClientProfile>();
    public DbSet<ClientSession> ClientSessions => Set<ClientSession>();
    public DbSet<ClientSessionIp> ClientSessionIps => Set<ClientSessionIp>();
    public DbSet<ClientUsername> ClientUsernames => Set<ClientUsername>();

    public DbSet<ImageFormat> ImageFormats => Set<ImageFormat>();
    public DbSet<Language> Languages => Set<Language>();
    public DbSet<Media> Medias => Set<Media>();
    public DbSet<MediaEncryptionType> MediaEncryptionTypes => Set<MediaEncryptionType>();
    public DbSet<MediaKey> MediaKeys => Set<MediaKey>();
    public DbSet<MediaStorageType> MediaStorageTypes => Set<MediaStorageType>();
    public DbSet<Music> Musics => Set<Music>();
    public DbSet<MusicFeature> MusicFeatures => Set<MusicFeature>();
    public DbSet<MusicFeatureContentType> MusicFeatureContentTypes => Set<MusicFeatureContentType>();
    public DbSet<MusicAlbum> MusicAlbums => Set<MusicAlbum>();

    public DbSet<MusicContributor> MusicContributors => Set<MusicContributor>();
    public DbSet<MusicContributorType> MusicContributorTypes => Set<MusicContributorType>();
    public DbSet<MusicCover> MusicCovers => Set<MusicCover>();

    public DbSet<MusicFile> MusicFiles => Set<MusicFile>();
    public DbSet<MusicFileQuality> MusicFileQualities => Set<MusicFileQuality>();
    public DbSet<MusicFileQualityBitDepth> MusicFileQualityBitDepths => Set<MusicFileQualityBitDepth>();
    public DbSet<MusicFileQualityChannel> MusicFileQualityChannels => Set<MusicFileQualityChannel>();
    public DbSet<MusicFileQualityCodec> MusicFileQualityCodecs => Set<MusicFileQualityCodec>();
    public DbSet<MusicFileQualityEncoder> MusicFileQualityEncoders => Set<MusicFileQualityEncoder>();
    public DbSet<MusicFileQualityEncoderMode> MusicFileQualityEncoderModes => Set<MusicFileQualityEncoderMode>();
    public DbSet<MusicFileQualityFormat> MusicFileQualityFormats => Set<MusicFileQualityFormat>();
    public DbSet<MusicFileQualitySampleFormat> MusicFileQualitySampleFormats => Set<MusicFileQualitySampleFormat>();
    public DbSet<MusicFileWaveform> MusicFileWaveforms => Set<MusicFileWaveform>();
    public DbSet<MusicFileStem> MusicFileStems => Set<MusicFileStem>();
    public DbSet<MusicFileStemType> MusicFileStemTypes => Set<MusicFileStemType>();
    public DbSet<MusicFileStemPitch> MusicFileStemPitches => Set<MusicFileStemPitch>();

    
    public DbSet<MusicGenre> MusicGenres => Set<MusicGenre>();
    public DbSet<MusicGenreType> MusicGenreTypes => Set<MusicGenreType>();
    public DbSet<MusicLabel> MusicLabels => Set<MusicLabel>();
    public DbSet<MusicLanguage> MusicLanguages => Set<MusicLanguage>();
    public DbSet<MusicLike> MusicLikes => Set<MusicLike>();
    public DbSet<MusicReaction> MusicReactions => Set<MusicReaction>();
    public DbSet<MusicComment> MusicComments => Set<MusicComment>();
    public DbSet<MusicReactionType> MusicReactionTypes => Set<MusicReactionType>();
    public DbSet<MusicPlaylist> MusicPlaylists => Set<MusicPlaylist>();
    public DbSet<MusicPlaylistMusic> MusicPlaylistMusics => Set<MusicPlaylistMusic>();

    public DbSet<MusicLyric> MusicLyrics => Set<MusicLyric>();

    public DbSet<MusicLyricLine> MusicLyricLines => Set<MusicLyricLine>();
    public DbSet<MusicLyricLineWord> MusicLyricLineWords => Set<MusicLyricLineWord>();
    public DbSet<MusicView> MusicViews => Set<MusicView>();
    public DbSet<MusicPlay> MusicPlays => Set<MusicPlay>();
    public DbSet<Story> Stories => Set<Story>();
    public DbSet<StoryContentType> StoryContentTypes => Set<StoryContentType>();
    public DbSet<StoryView> StoryViews => Set<StoryView>();
    public DbSet<StoryLike> StoryLikes => Set<StoryLike>();
    public DbSet<StoryWidget> StoryWidgets => Set<StoryWidget>();
    public DbSet<StoryWidgetType> StoryWidgetTypes => Set<StoryWidgetType>();
    public DbSet<StoryWidgetStyle> StoryWidgetStyles => Set<StoryWidgetStyle>();
    public DbSet<StoryMusicWidget> StoryMusicWidgets => Set<StoryMusicWidget>();
    public DbSet<StoryClientWidget> StoryClientWidgets => Set<StoryClientWidget>();
    public DbSet<Person> Persons => Set<Person>();


    public DbSet<Platform> Platforms => Set<Platform>();
    public DbSet<PlatformVersion> PlatformVersions => Set<PlatformVersion>();

}

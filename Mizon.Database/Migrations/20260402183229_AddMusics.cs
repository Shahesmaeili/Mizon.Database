using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mizon.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddMusics : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientProfiles_ImageFormat_ImageFormatId",
                table: "ClientProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageFormat",
                table: "ImageFormat");

            migrationBuilder.RenameTable(
                name: "ImageFormat",
                newName: "ImageFormats");

            migrationBuilder.RenameColumn(
                name: "BlurHash",
                table: "ClientProfiles",
                newName: "Blurhash");

            migrationBuilder.RenameIndex(
                name: "IX_ImageFormat_PublicId",
                table: "ImageFormats",
                newName: "IX_ImageFormats_PublicId");

            migrationBuilder.AddColumn<int>(
                name: "MediaId",
                table: "ClientProfiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PrimaryAccentColor",
                table: "ClientProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "ImageFormats",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageFormats",
                table: "ImageFormats",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    PersianTitle = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MediaEncryptionTypes",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaEncryptionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MediaKeys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KeyData = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaKeys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MediaStorageTypes",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaStorageTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MusicAlbums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    PersianTitle = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicAlbums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MusicContributorTypes",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersianTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicContributorTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MusicGenreTypes",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    PersianTitle = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicGenreTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MusicLabels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    PersianTitle = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicLabels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoragePath = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    EncryptionIV = table.Column<byte[]>(type: "varbinary(16)", maxLength: 16, nullable: false),
                    MediaKeyId = table.Column<int>(type: "int", nullable: false),
                    MediaEncryptionTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    MediaStorageTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    TotalChunks = table.Column<int>(type: "int", nullable: false),
                    ChunkSize = table.Column<int>(type: "int", nullable: false),
                    FileHash = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medias_MediaEncryptionTypes_MediaEncryptionTypeId",
                        column: x => x.MediaEncryptionTypeId,
                        principalTable: "MediaEncryptionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Medias_MediaKeys_MediaKeyId",
                        column: x => x.MediaKeyId,
                        principalTable: "MediaKeys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Medias_MediaStorageTypes_MediaStorageTypeId",
                        column: x => x.MediaStorageTypeId,
                        principalTable: "MediaStorageTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Musics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    PersianTitle = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    ReleaseDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    MusicLabelId = table.Column<int>(type: "int", nullable: true),
                    MusicAlbumId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Musics_MusicAlbums_MusicAlbumId",
                        column: x => x.MusicAlbumId,
                        principalTable: "MusicAlbums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Musics_MusicLabels_MusicLabelId",
                        column: x => x.MusicLabelId,
                        principalTable: "MusicLabels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MusicContributors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusicId = table.Column<int>(type: "int", nullable: false),
                    MusicContributorTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicContributors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MusicContributors_MusicContributorTypes_MusicContributorTypeId",
                        column: x => x.MusicContributorTypeId,
                        principalTable: "MusicContributorTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MusicContributors_Musics_MusicId",
                        column: x => x.MusicId,
                        principalTable: "Musics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MusicContributors_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MusicCovers",
                columns: table => new
                {
                    MusicId = table.Column<int>(type: "int", nullable: false),
                    MediaId = table.Column<int>(type: "int", nullable: false),
                    Blurhash = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Width = table.Column<short>(type: "smallint", nullable: false),
                    Height = table.Column<short>(type: "smallint", nullable: false),
                    ImageFormatId = table.Column<byte>(type: "tinyint", nullable: false),
                    PrimaryAccentColor = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicCovers", x => x.MusicId);
                    table.ForeignKey(
                        name: "FK_MusicCovers_ImageFormats_ImageFormatId",
                        column: x => x.ImageFormatId,
                        principalTable: "ImageFormats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MusicCovers_Medias_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MusicCovers_Musics_MusicId",
                        column: x => x.MusicId,
                        principalTable: "Musics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MusicGenres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusicId = table.Column<int>(type: "int", nullable: false),
                    MusicGenreTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicGenres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MusicGenres_MusicGenreTypes_MusicGenreTypeId",
                        column: x => x.MusicGenreTypeId,
                        principalTable: "MusicGenreTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MusicGenres_Musics_MusicId",
                        column: x => x.MusicId,
                        principalTable: "Musics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MusicLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusicId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<byte>(type: "tinyint", nullable: false),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MusicLanguages_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MusicLanguages_Musics_MusicId",
                        column: x => x.MusicId,
                        principalTable: "Musics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MusicLikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    MusicId = table.Column<int>(type: "int", nullable: false),
                    PlatformVersionId = table.Column<short>(type: "smallint", nullable: false),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicLikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MusicLikes_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MusicLikes_Musics_MusicId",
                        column: x => x.MusicId,
                        principalTable: "Musics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MusicLikes_PlatformVersions_PlatformVersionId",
                        column: x => x.PlatformVersionId,
                        principalTable: "PlatformVersions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MusicLyrics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MusicId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<byte>(type: "tinyint", nullable: false),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicLyrics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MusicLyrics_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicLyrics_Musics_MusicId",
                        column: x => x.MusicId,
                        principalTable: "Musics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MusicViews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    MusicId = table.Column<int>(type: "int", nullable: false),
                    PlatformVersionId = table.Column<short>(type: "smallint", nullable: false),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicViews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MusicViews_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MusicViews_Musics_MusicId",
                        column: x => x.MusicId,
                        principalTable: "Musics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MusicViews_PlatformVersions_PlatformVersionId",
                        column: x => x.PlatformVersionId,
                        principalTable: "PlatformVersions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MusicLyricLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MusicLyricId = table.Column<int>(type: "int", nullable: false),
                    StartTimeInMilliseconds = table.Column<int>(type: "int", nullable: false),
                    EndTimeInMilliseconds = table.Column<int>(type: "int", nullable: false),
                    LineOrder = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicLyricLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MusicLyricLines_MusicLyrics_MusicLyricId",
                        column: x => x.MusicLyricId,
                        principalTable: "MusicLyrics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MusicLyricLineWords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MusicLyricLineId = table.Column<int>(type: "int", nullable: false),
                    StartTimeInMilliseconds = table.Column<int>(type: "int", nullable: false),
                    EndTimeInMilliseconds = table.Column<int>(type: "int", nullable: false),
                    WordOrder = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicLyricLineWords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MusicLyricLineWords_MusicLyricLines_MusicLyricLineId",
                        column: x => x.MusicLyricLineId,
                        principalTable: "MusicLyricLines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientProfiles_MediaId",
                table: "ClientProfiles",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_PublicId",
                table: "Languages",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MediaEncryptionTypes_PublicId",
                table: "MediaEncryptionTypes",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MediaKeys_PublicId",
                table: "MediaKeys",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medias_MediaEncryptionTypeId",
                table: "Medias",
                column: "MediaEncryptionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Medias_MediaKeyId",
                table: "Medias",
                column: "MediaKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_Medias_MediaStorageTypeId",
                table: "Medias",
                column: "MediaStorageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Medias_PublicId",
                table: "Medias",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MediaStorageTypes_PublicId",
                table: "MediaStorageTypes",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MusicAlbums_PublicId",
                table: "MusicAlbums",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MusicContributors_MusicContributorTypeId",
                table: "MusicContributors",
                column: "MusicContributorTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicContributors_MusicId",
                table: "MusicContributors",
                column: "MusicId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicContributors_PersonId",
                table: "MusicContributors",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicContributorTypes_PublicId",
                table: "MusicContributorTypes",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MusicCovers_ImageFormatId",
                table: "MusicCovers",
                column: "ImageFormatId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicCovers_MediaId",
                table: "MusicCovers",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicGenres_MusicGenreTypeId",
                table: "MusicGenres",
                column: "MusicGenreTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicGenres_MusicId",
                table: "MusicGenres",
                column: "MusicId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicGenreTypes_PublicId",
                table: "MusicGenreTypes",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MusicLabels_PublicId",
                table: "MusicLabels",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MusicLanguages_LanguageId",
                table: "MusicLanguages",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicLanguages_MusicId",
                table: "MusicLanguages",
                column: "MusicId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicLikes_ClientId",
                table: "MusicLikes",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicLikes_MusicId",
                table: "MusicLikes",
                column: "MusicId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicLikes_PlatformVersionId",
                table: "MusicLikes",
                column: "PlatformVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicLyricLines_MusicLyricId",
                table: "MusicLyricLines",
                column: "MusicLyricId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicLyricLines_PublicId",
                table: "MusicLyricLines",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MusicLyricLineWords_MusicLyricLineId",
                table: "MusicLyricLineWords",
                column: "MusicLyricLineId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicLyricLineWords_PublicId",
                table: "MusicLyricLineWords",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MusicLyrics_LanguageId",
                table: "MusicLyrics",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicLyrics_MusicId",
                table: "MusicLyrics",
                column: "MusicId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicLyrics_PublicId",
                table: "MusicLyrics",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Musics_MusicAlbumId",
                table: "Musics",
                column: "MusicAlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Musics_MusicLabelId",
                table: "Musics",
                column: "MusicLabelId");

            migrationBuilder.CreateIndex(
                name: "IX_Musics_PublicId",
                table: "Musics",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MusicViews_ClientId",
                table: "MusicViews",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicViews_MusicId",
                table: "MusicViews",
                column: "MusicId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicViews_PlatformVersionId",
                table: "MusicViews",
                column: "PlatformVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PublicId",
                table: "Persons",
                column: "PublicId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientProfiles_ImageFormats_ImageFormatId",
                table: "ClientProfiles",
                column: "ImageFormatId",
                principalTable: "ImageFormats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientProfiles_Medias_MediaId",
                table: "ClientProfiles",
                column: "MediaId",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientProfiles_ImageFormats_ImageFormatId",
                table: "ClientProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientProfiles_Medias_MediaId",
                table: "ClientProfiles");

            migrationBuilder.DropTable(
                name: "MusicContributors");

            migrationBuilder.DropTable(
                name: "MusicCovers");

            migrationBuilder.DropTable(
                name: "MusicGenres");

            migrationBuilder.DropTable(
                name: "MusicLanguages");

            migrationBuilder.DropTable(
                name: "MusicLikes");

            migrationBuilder.DropTable(
                name: "MusicLyricLineWords");

            migrationBuilder.DropTable(
                name: "MusicViews");

            migrationBuilder.DropTable(
                name: "MusicContributorTypes");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Medias");

            migrationBuilder.DropTable(
                name: "MusicGenreTypes");

            migrationBuilder.DropTable(
                name: "MusicLyricLines");

            migrationBuilder.DropTable(
                name: "MediaEncryptionTypes");

            migrationBuilder.DropTable(
                name: "MediaKeys");

            migrationBuilder.DropTable(
                name: "MediaStorageTypes");

            migrationBuilder.DropTable(
                name: "MusicLyrics");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Musics");

            migrationBuilder.DropTable(
                name: "MusicAlbums");

            migrationBuilder.DropTable(
                name: "MusicLabels");

            migrationBuilder.DropIndex(
                name: "IX_ClientProfiles_MediaId",
                table: "ClientProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageFormats",
                table: "ImageFormats");

            migrationBuilder.DropColumn(
                name: "MediaId",
                table: "ClientProfiles");

            migrationBuilder.DropColumn(
                name: "PrimaryAccentColor",
                table: "ClientProfiles");

            migrationBuilder.RenameTable(
                name: "ImageFormats",
                newName: "ImageFormat");

            migrationBuilder.RenameColumn(
                name: "Blurhash",
                table: "ClientProfiles",
                newName: "BlurHash");

            migrationBuilder.RenameIndex(
                name: "IX_ImageFormats_PublicId",
                table: "ImageFormat",
                newName: "IX_ImageFormat_PublicId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "ImageFormat",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(16)",
                oldMaxLength: 16);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageFormat",
                table: "ImageFormat",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientProfiles_ImageFormat_ImageFormatId",
                table: "ClientProfiles",
                column: "ImageFormatId",
                principalTable: "ImageFormat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

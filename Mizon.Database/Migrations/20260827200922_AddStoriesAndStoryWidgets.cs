using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mizon.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddStoriesAndStoryWidgets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    ContentMediaId = table.Column<int>(type: "int", nullable: false),
                    PreviewMediaId = table.Column<int>(type: "int", nullable: true),
                    ContentType = table.Column<byte>(type: "tinyint", nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ExpireDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stories_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stories_Medias_ContentMediaId",
                        column: x => x.ContentMediaId,
                        principalTable: "Medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stories_Medias_PreviewMediaId",
                        column: x => x.PreviewMediaId,
                        principalTable: "Medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoryLikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    StoryId = table.Column<int>(type: "int", nullable: false),
                    PlatformVersionId = table.Column<short>(type: "smallint", nullable: false),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoryLikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoryLikes_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoryLikes_PlatformVersions_PlatformVersionId",
                        column: x => x.PlatformVersionId,
                        principalTable: "PlatformVersions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoryLikes_Stories_StoryId",
                        column: x => x.StoryId,
                        principalTable: "Stories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoryViews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    StoryId = table.Column<int>(type: "int", nullable: false),
                    PlatformVersionId = table.Column<short>(type: "smallint", nullable: false),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoryViews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoryViews_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoryViews_PlatformVersions_PlatformVersionId",
                        column: x => x.PlatformVersionId,
                        principalTable: "PlatformVersions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoryViews_Stories_StoryId",
                        column: x => x.StoryId,
                        principalTable: "Stories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoryWidgets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoryId = table.Column<int>(type: "int", nullable: false),
                    WidgetType = table.Column<byte>(type: "tinyint", nullable: false),
                    Style = table.Column<short>(type: "smallint", nullable: false),
                    X = table.Column<float>(type: "real", nullable: false),
                    Y = table.Column<float>(type: "real", nullable: false),
                    Width = table.Column<float>(type: "real", nullable: false),
                    Height = table.Column<float>(type: "real", nullable: false),
                    Rotation = table.Column<float>(type: "real", nullable: false),
                    ZIndex = table.Column<short>(type: "smallint", nullable: false),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoryWidgets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoryWidgets_Stories_StoryId",
                        column: x => x.StoryId,
                        principalTable: "Stories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoryClientWidgets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoryWidgetId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoryClientWidgets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoryClientWidgets_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoryClientWidgets_StoryWidgets_StoryWidgetId",
                        column: x => x.StoryWidgetId,
                        principalTable: "StoryWidgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoryMusicWidgets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoryWidgetId = table.Column<int>(type: "int", nullable: false),
                    MusicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoryMusicWidgets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoryMusicWidgets_Musics_MusicId",
                        column: x => x.MusicId,
                        principalTable: "Musics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoryMusicWidgets_StoryWidgets_StoryWidgetId",
                        column: x => x.StoryWidgetId,
                        principalTable: "StoryWidgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stories_ClientId_CreateDateTime",
                table: "Stories",
                columns: new[] { "ClientId", "CreateDateTime" });

            migrationBuilder.CreateIndex(
                name: "IX_Stories_ContentMediaId",
                table: "Stories",
                column: "ContentMediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Stories_IsActive_ExpireDateTime",
                table: "Stories",
                columns: new[] { "IsActive", "ExpireDateTime" });

            migrationBuilder.CreateIndex(
                name: "IX_Stories_PreviewMediaId",
                table: "Stories",
                column: "PreviewMediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Stories_PublicId",
                table: "Stories",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StoryClientWidgets_ClientId",
                table: "StoryClientWidgets",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_StoryClientWidgets_StoryWidgetId",
                table: "StoryClientWidgets",
                column: "StoryWidgetId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StoryLikes_ClientId",
                table: "StoryLikes",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_StoryLikes_PlatformVersionId",
                table: "StoryLikes",
                column: "PlatformVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_StoryLikes_StoryId_ClientId",
                table: "StoryLikes",
                columns: new[] { "StoryId", "ClientId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StoryMusicWidgets_MusicId",
                table: "StoryMusicWidgets",
                column: "MusicId");

            migrationBuilder.CreateIndex(
                name: "IX_StoryMusicWidgets_StoryWidgetId",
                table: "StoryMusicWidgets",
                column: "StoryWidgetId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StoryViews_ClientId",
                table: "StoryViews",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_StoryViews_PlatformVersionId",
                table: "StoryViews",
                column: "PlatformVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_StoryViews_StoryId_ClientId",
                table: "StoryViews",
                columns: new[] { "StoryId", "ClientId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StoryWidgets_PublicId",
                table: "StoryWidgets",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StoryWidgets_StoryId_ZIndex",
                table: "StoryWidgets",
                columns: new[] { "StoryId", "ZIndex" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoryClientWidgets");

            migrationBuilder.DropTable(
                name: "StoryLikes");

            migrationBuilder.DropTable(
                name: "StoryMusicWidgets");

            migrationBuilder.DropTable(
                name: "StoryViews");

            migrationBuilder.DropTable(
                name: "StoryWidgets");

            migrationBuilder.DropTable(
                name: "Stories");
        }
    }
}

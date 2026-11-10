using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mizon.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddMusicPlaysAndFollowingActivityIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MusicReactions_ClientId",
                table: "MusicReactions");

            migrationBuilder.DropIndex(
                name: "IX_MusicLikes_ClientId",
                table: "MusicLikes");

            migrationBuilder.DropIndex(
                name: "IX_MusicComments_ClientId",
                table: "MusicComments");

            migrationBuilder.CreateTable(
                name: "MusicPlays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    MusicId = table.Column<int>(type: "int", nullable: false),
                    PlatformVersionId = table.Column<short>(type: "smallint", nullable: false),
                    PlaybackPublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicPlays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MusicPlays_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MusicPlays_Musics_MusicId",
                        column: x => x.MusicId,
                        principalTable: "Musics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MusicPlays_PlatformVersions_PlatformVersionId",
                        column: x => x.PlatformVersionId,
                        principalTable: "PlatformVersions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MusicReactions_ClientId_CreateDateTime_Id",
                table: "MusicReactions",
                columns: new[] { "ClientId", "CreateDateTime", "Id" },
                descending: new[] { false, true, true });

            migrationBuilder.CreateIndex(
                name: "IX_MusicPlaylists_ClientId_CreateDateTime_Id",
                table: "MusicPlaylists",
                columns: new[] { "ClientId", "CreateDateTime", "Id" },
                descending: new[] { false, true, true });

            migrationBuilder.CreateIndex(
                name: "IX_MusicLikes_ClientId_CreateDateTime_Id",
                table: "MusicLikes",
                columns: new[] { "ClientId", "CreateDateTime", "Id" },
                descending: new[] { false, true, true });

            migrationBuilder.CreateIndex(
                name: "IX_MusicComments_ClientId_CreateDateTime_Id",
                table: "MusicComments",
                columns: new[] { "ClientId", "CreateDateTime", "Id" },
                descending: new[] { false, true, true });

            migrationBuilder.CreateIndex(
                name: "IX_MusicPlays_ClientId_CreateDateTime_Id",
                table: "MusicPlays",
                columns: new[] { "ClientId", "CreateDateTime", "Id" },
                descending: new[] { false, true, true });

            migrationBuilder.CreateIndex(
                name: "IX_MusicPlays_ClientId_PlaybackPublicId",
                table: "MusicPlays",
                columns: new[] { "ClientId", "PlaybackPublicId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MusicPlays_MusicId",
                table: "MusicPlays",
                column: "MusicId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicPlays_PlatformVersionId",
                table: "MusicPlays",
                column: "PlatformVersionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MusicPlays");

            migrationBuilder.DropIndex(
                name: "IX_MusicReactions_ClientId_CreateDateTime_Id",
                table: "MusicReactions");

            migrationBuilder.DropIndex(
                name: "IX_MusicPlaylists_ClientId_CreateDateTime_Id",
                table: "MusicPlaylists");

            migrationBuilder.DropIndex(
                name: "IX_MusicLikes_ClientId_CreateDateTime_Id",
                table: "MusicLikes");

            migrationBuilder.DropIndex(
                name: "IX_MusicComments_ClientId_CreateDateTime_Id",
                table: "MusicComments");

            migrationBuilder.CreateIndex(
                name: "IX_MusicReactions_ClientId",
                table: "MusicReactions",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicLikes_ClientId",
                table: "MusicLikes",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicComments_ClientId",
                table: "MusicComments",
                column: "ClientId");
        }
    }
}

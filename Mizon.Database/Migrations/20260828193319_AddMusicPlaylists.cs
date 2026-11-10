using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mizon.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddMusicPlaylists : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MusicPlaylists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicPlaylists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MusicPlaylists_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MusicPlaylistMusics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusicPlaylistId = table.Column<int>(type: "int", nullable: false),
                    MusicId = table.Column<int>(type: "int", nullable: false),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicPlaylistMusics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MusicPlaylistMusics_MusicPlaylists_MusicPlaylistId",
                        column: x => x.MusicPlaylistId,
                        principalTable: "MusicPlaylists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicPlaylistMusics_Musics_MusicId",
                        column: x => x.MusicId,
                        principalTable: "Musics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MusicPlaylistMusics_MusicId",
                table: "MusicPlaylistMusics",
                column: "MusicId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicPlaylistMusics_MusicPlaylistId_CreateDateTime",
                table: "MusicPlaylistMusics",
                columns: new[] { "MusicPlaylistId", "CreateDateTime" });

            migrationBuilder.CreateIndex(
                name: "IX_MusicPlaylistMusics_MusicPlaylistId_MusicId",
                table: "MusicPlaylistMusics",
                columns: new[] { "MusicPlaylistId", "MusicId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MusicPlaylists_ClientId_CreateDateTime",
                table: "MusicPlaylists",
                columns: new[] { "ClientId", "CreateDateTime" });

            migrationBuilder.CreateIndex(
                name: "IX_MusicPlaylists_PublicId",
                table: "MusicPlaylists",
                column: "PublicId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MusicPlaylistMusics");

            migrationBuilder.DropTable(
                name: "MusicPlaylists");
        }
    }
}

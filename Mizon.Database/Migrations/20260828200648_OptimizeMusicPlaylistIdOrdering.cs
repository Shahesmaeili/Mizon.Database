using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mizon.Database.Migrations
{
    /// <inheritdoc />
    public partial class OptimizeMusicPlaylistIdOrdering : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MusicPlaylists_ClientId_CreateDateTime",
                table: "MusicPlaylists");

            migrationBuilder.DropIndex(
                name: "IX_MusicPlaylistMusics_MusicPlaylistId_CreateDateTime",
                table: "MusicPlaylistMusics");

            migrationBuilder.CreateIndex(
                name: "IX_MusicPlaylists_ClientId_Id",
                table: "MusicPlaylists",
                columns: new[] { "ClientId", "Id" });

            migrationBuilder.CreateIndex(
                name: "IX_MusicPlaylistMusics_MusicPlaylistId_Id",
                table: "MusicPlaylistMusics",
                columns: new[] { "MusicPlaylistId", "Id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MusicPlaylists_ClientId_Id",
                table: "MusicPlaylists");

            migrationBuilder.DropIndex(
                name: "IX_MusicPlaylistMusics_MusicPlaylistId_Id",
                table: "MusicPlaylistMusics");

            migrationBuilder.CreateIndex(
                name: "IX_MusicPlaylists_ClientId_CreateDateTime",
                table: "MusicPlaylists",
                columns: new[] { "ClientId", "CreateDateTime" });

            migrationBuilder.CreateIndex(
                name: "IX_MusicPlaylistMusics_MusicPlaylistId_CreateDateTime",
                table: "MusicPlaylistMusics",
                columns: new[] { "MusicPlaylistId", "CreateDateTime" });
        }
    }
}

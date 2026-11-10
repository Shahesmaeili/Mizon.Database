using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mizon.Database.Migrations;

public partial class AddMusicLibraryActivityOrdering : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        // Existing memberships predate parent activity tracking. Preserve any newer
        // explicit update and recover the latest addition time for existing lists.
        migrationBuilder.Sql("""
            UPDATE playlist
            SET UpdateDateTime = additions.LastAddedAt
            FROM MusicPlaylists AS playlist
            INNER JOIN (
                SELECT MusicPlaylistId, MAX(CreateDateTime) AS LastAddedAt
                FROM MusicPlaylistMusics
                GROUP BY MusicPlaylistId
            ) AS additions ON additions.MusicPlaylistId = playlist.Id
            WHERE additions.LastAddedAt > COALESCE(playlist.UpdateDateTime, playlist.CreateDateTime);
            """);

        migrationBuilder.AddColumn<DateTimeOffset>(
            name: "LastActivityDateTime",
            table: "MusicPlaylists",
            type: "datetimeoffset",
            nullable: false,
            computedColumnSql: "COALESCE([UpdateDateTime], [CreateDateTime])",
            stored: true);

        migrationBuilder.CreateIndex(
                name: "IX_MusicPlaylists_ClientId_LastActivityDateTime_Id",
                table: "MusicPlaylists",
                columns: new[] { "ClientId", "LastActivityDateTime", "Id" },
                descending: new[] { false, true, true })
            .Annotation("SqlServer:Include", new[] { "PublicId", "Title" });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropIndex(
            name: "IX_MusicPlaylists_ClientId_LastActivityDateTime_Id",
            table: "MusicPlaylists");

        migrationBuilder.DropColumn(
            name: "LastActivityDateTime",
            table: "MusicPlaylists");
    }
}
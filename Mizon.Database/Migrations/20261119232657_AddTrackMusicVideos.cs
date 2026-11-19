using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mizon.Database.Migrations;

/// <inheritdoc />
public partial class _20261119232657_AddTrackMusicVideos : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "MusicVideos",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                MusicId = table.Column<int>(type: "int", nullable: false),
                MediaId = table.Column<int>(type: "int", nullable: false),
                CoverMediaId = table.Column<int>(type: "int", nullable: true),
                IsActive = table.Column<bool>(type: "bit", nullable: false),
                CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_MusicVideos", x => x.Id);
                table.ForeignKey(
                    name: "FK_MusicVideos_Medias_CoverMediaId",
                    column: x => x.CoverMediaId,
                    principalTable: "Medias",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_MusicVideos_Medias_MediaId",
                    column: x => x.MediaId,
                    principalTable: "Medias",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_MusicVideos_Musics_MusicId",
                    column: x => x.MusicId,
                    principalTable: "Musics",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateIndex(
            name: "IX_MusicVideos_CoverMediaId",
            table: "MusicVideos",
            column: "CoverMediaId");

        migrationBuilder.CreateIndex(
            name: "IX_MusicVideos_MediaId",
            table: "MusicVideos",
            column: "MediaId");

        migrationBuilder.CreateIndex(
            name: "IX_MusicVideos_MusicId",
            table: "MusicVideos",
            column: "MusicId",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_MusicVideos_PublicId",
            table: "MusicVideos",
            column: "PublicId",
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "MusicVideos");
    }
}

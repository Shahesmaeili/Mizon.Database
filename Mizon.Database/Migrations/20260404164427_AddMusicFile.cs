using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mizon.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddMusicFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MusicFile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MusicId = table.Column<int>(type: "int", nullable: false),
                    MediaId = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MusicFile_Medias_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicFile_Musics_MusicId",
                        column: x => x.MusicId,
                        principalTable: "Musics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MusicFileWaveform",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusicFileId = table.Column<int>(type: "int", nullable: false),
                    OffsetInMilliseconds = table.Column<int>(type: "int", nullable: false),
                    MinimumAmplitude = table.Column<short>(type: "smallint", nullable: false),
                    MaximumAmplitude = table.Column<short>(type: "smallint", nullable: false),
                    RMS = table.Column<float>(type: "real", nullable: false),
                    Peak = table.Column<short>(type: "smallint", nullable: false),
                    Transient = table.Column<float>(type: "real", nullable: false),
                    IsClipping = table.Column<bool>(type: "bit", nullable: false),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicFileWaveform", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MusicFileWaveform_MusicFile_MusicFileId",
                        column: x => x.MusicFileId,
                        principalTable: "MusicFile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MusicFile_MediaId",
                table: "MusicFile",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicFile_MusicId",
                table: "MusicFile",
                column: "MusicId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicFile_PublicId",
                table: "MusicFile",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MusicFileWaveform_MusicFileId",
                table: "MusicFileWaveform",
                column: "MusicFileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MusicFileWaveform");

            migrationBuilder.DropTable(
                name: "MusicFile");
        }
    }
}

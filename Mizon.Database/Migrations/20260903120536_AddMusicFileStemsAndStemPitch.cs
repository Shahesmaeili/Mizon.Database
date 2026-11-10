using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mizon.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddMusicFileStemsAndStemPitch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MusicFileStemTypes",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    PersianTitle = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicFileStemTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MusicFileStems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MusicFileId = table.Column<int>(type: "int", nullable: false),
                    MusicFileStemTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    MediaId = table.Column<int>(type: "int", nullable: false),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicFileStems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MusicFileStems_Medias_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MusicFileStems_MusicFileStemTypes_MusicFileStemTypeId",
                        column: x => x.MusicFileStemTypeId,
                        principalTable: "MusicFileStemTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MusicFileStems_MusicFiles_MusicFileId",
                        column: x => x.MusicFileId,
                        principalTable: "MusicFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MusicFileStemPitches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusicFileStemId = table.Column<int>(type: "int", nullable: false),
                    AverageF0Hz = table.Column<float>(type: "real", nullable: false),
                    StartTimeInMilliseconds = table.Column<int>(type: "int", nullable: false),
                    EndTimeInMilliseconds = table.Column<int>(type: "int", nullable: false),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicFileStemPitches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MusicFileStemPitches_MusicFileStems_MusicFileStemId",
                        column: x => x.MusicFileStemId,
                        principalTable: "MusicFileStems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MusicFileStemPitches_MusicFileStemId_StartTimeInMilliseconds",
                table: "MusicFileStemPitches",
                columns: new[] { "MusicFileStemId", "StartTimeInMilliseconds" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MusicFileStems_MediaId",
                table: "MusicFileStems",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicFileStems_MusicFileId_MusicFileStemTypeId",
                table: "MusicFileStems",
                columns: new[] { "MusicFileId", "MusicFileStemTypeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MusicFileStems_MusicFileStemTypeId",
                table: "MusicFileStems",
                column: "MusicFileStemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicFileStems_PublicId",
                table: "MusicFileStems",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MusicFileStemTypes_PublicId",
                table: "MusicFileStemTypes",
                column: "PublicId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MusicFileStemPitches");

            migrationBuilder.DropTable(
                name: "MusicFileStems");

            migrationBuilder.DropTable(
                name: "MusicFileStemTypes");
        }
    }
}

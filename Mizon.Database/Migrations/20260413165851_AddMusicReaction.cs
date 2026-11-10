using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mizon.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddMusicReaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MusicFile_Medias_MediaId",
                table: "MusicFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_MusicFile_Musics_MusicId",
                table: "MusicFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_MusicFileWaveform_MusicFile_MusicFileId",
                table: "MusicFileWaveform");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MusicFileWaveform",
                table: "MusicFileWaveform");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MusicFile",
                table: "MusicFiles");

            migrationBuilder.RenameTable(
                name: "MusicFileWaveform",
                newName: "MusicFileWaveforms");

            //migrationBuilder.RenameTable(
            //    name: "MusicFile",
            //    newName: "MusicFiles");

            migrationBuilder.RenameIndex(
                name: "IX_MusicFileWaveform_MusicFileId",
                table: "MusicFileWaveforms",
                newName: "IX_MusicFileWaveforms_MusicFileId");

            migrationBuilder.RenameIndex(
                name: "IX_MusicFile_PublicId",
                table: "MusicFiles",
                newName: "IX_MusicFiles_PublicId");

            migrationBuilder.RenameIndex(
                name: "IX_MusicFile_MusicId",
                table: "MusicFiles",
                newName: "IX_MusicFiles_MusicId");

            migrationBuilder.RenameIndex(
                name: "IX_MusicFile_MediaId",
                table: "MusicFiles",
                newName: "IX_MusicFiles_MediaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MusicFileWaveforms",
                table: "MusicFileWaveforms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MusicFiles",
                table: "MusicFiles",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "MusicReactionTypes",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Emoji = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicReactionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MusicReactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    MusicId = table.Column<int>(type: "int", nullable: false),
                    MusicReactionTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    PlatformVersionId = table.Column<short>(type: "smallint", nullable: false),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicReactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MusicReactions_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MusicReactions_MusicReactionTypes_MusicReactionTypeId",
                        column: x => x.MusicReactionTypeId,
                        principalTable: "MusicReactionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MusicReactions_Musics_MusicId",
                        column: x => x.MusicId,
                        principalTable: "Musics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MusicReactions_PlatformVersions_PlatformVersionId",
                        column: x => x.PlatformVersionId,
                        principalTable: "PlatformVersions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MusicReactions_ClientId",
                table: "MusicReactions",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicReactions_MusicId",
                table: "MusicReactions",
                column: "MusicId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicReactions_MusicReactionTypeId",
                table: "MusicReactions",
                column: "MusicReactionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicReactions_PlatformVersionId",
                table: "MusicReactions",
                column: "PlatformVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicReactionTypes_PublicId",
                table: "MusicReactionTypes",
                column: "PublicId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MusicFiles_Medias_MediaId",
                table: "MusicFiles",
                column: "MediaId",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MusicFiles_Musics_MusicId",
                table: "MusicFiles",
                column: "MusicId",
                principalTable: "Musics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MusicFileWaveforms_MusicFiles_MusicFileId",
                table: "MusicFileWaveforms",
                column: "MusicFileId",
                principalTable: "MusicFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MusicFiles_Medias_MediaId",
                table: "MusicFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_MusicFiles_Musics_MusicId",
                table: "MusicFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_MusicFileWaveforms_MusicFiles_MusicFileId",
                table: "MusicFileWaveforms");

            migrationBuilder.DropTable(
                name: "MusicReactions");

            migrationBuilder.DropTable(
                name: "MusicReactionTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MusicFileWaveforms",
                table: "MusicFileWaveforms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MusicFiles",
                table: "MusicFiles");

            migrationBuilder.RenameTable(
                name: "MusicFileWaveforms",
                newName: "MusicFileWaveform");

            migrationBuilder.RenameTable(
                name: "MusicFiles",
                newName: "MusicFile");

            migrationBuilder.RenameIndex(
                name: "IX_MusicFileWaveforms_MusicFileId",
                table: "MusicFileWaveform",
                newName: "IX_MusicFileWaveform_MusicFileId");

            migrationBuilder.RenameIndex(
                name: "IX_MusicFiles_PublicId",
                table: "MusicFile",
                newName: "IX_MusicFile_PublicId");

            migrationBuilder.RenameIndex(
                name: "IX_MusicFiles_MusicId",
                table: "MusicFile",
                newName: "IX_MusicFile_MusicId");

            migrationBuilder.RenameIndex(
                name: "IX_MusicFiles_MediaId",
                table: "MusicFile",
                newName: "IX_MusicFile_MediaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MusicFileWaveform",
                table: "MusicFileWaveform",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MusicFile",
                table: "MusicFile",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MusicFile_Medias_MediaId",
                table: "MusicFile",
                column: "MediaId",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MusicFile_Musics_MusicId",
                table: "MusicFile",
                column: "MusicId",
                principalTable: "Musics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MusicFileWaveform_MusicFile_MusicFileId",
                table: "MusicFileWaveform",
                column: "MusicFileId",
                principalTable: "MusicFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

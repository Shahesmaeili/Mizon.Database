using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mizon.Database.Migrations;

/// <inheritdoc />
public partial class _20261120145502_AddMusicCommentDiscussion : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropIndex(
            name: "IX_MusicComments_MusicId",
            table: "MusicComments");

        migrationBuilder.AddColumn<int>(
            name: "ParentMusicCommentId",
            table: "MusicComments",
            type: "int",
            nullable: true);

        migrationBuilder.AddColumn<short>(
            name: "PlatformVersionId",
            table: "MusicComments",
            type: "smallint",
            nullable: true);

        migrationBuilder.AddUniqueConstraint(
            name: "AK_MusicComments_MusicId_Id",
            table: "MusicComments",
            columns: new[] { "MusicId", "Id" });

        migrationBuilder.CreateTable(
            name: "MusicCommentTags",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                MusicCommentId = table.Column<int>(type: "int", nullable: false),
                TaggedPersonId = table.Column<int>(type: "int", nullable: true),
                TaggedClientId = table.Column<int>(type: "int", nullable: true),
                TaggedMusicId = table.Column<int>(type: "int", nullable: true),
                TaggedMusicVideoId = table.Column<int>(type: "int", nullable: true),
                CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_MusicCommentTags", x => x.Id);
                table.CheckConstraint("CK_MusicCommentTags_OneTarget", "(CASE WHEN [TaggedPersonId] IS NULL THEN 0 ELSE 1 END + CASE WHEN [TaggedClientId] IS NULL THEN 0 ELSE 1 END + CASE WHEN [TaggedMusicId] IS NULL THEN 0 ELSE 1 END + CASE WHEN [TaggedMusicVideoId] IS NULL THEN 0 ELSE 1 END) = 1");
                table.ForeignKey(
                    name: "FK_MusicCommentTags_Clients_TaggedClientId",
                    column: x => x.TaggedClientId,
                    principalTable: "Clients",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_MusicCommentTags_MusicComments_MusicCommentId",
                    column: x => x.MusicCommentId,
                    principalTable: "MusicComments",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_MusicCommentTags_MusicVideos_TaggedMusicVideoId",
                    column: x => x.TaggedMusicVideoId,
                    principalTable: "MusicVideos",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_MusicCommentTags_Musics_TaggedMusicId",
                    column: x => x.TaggedMusicId,
                    principalTable: "Musics",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_MusicCommentTags_Persons_TaggedPersonId",
                    column: x => x.TaggedPersonId,
                    principalTable: "Persons",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "MusicCommentVotes",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                MusicCommentId = table.Column<int>(type: "int", nullable: false),
                ClientId = table.Column<int>(type: "int", nullable: false),
                IsLike = table.Column<bool>(type: "bit", nullable: false),
                CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_MusicCommentVotes", x => x.Id);
                table.ForeignKey(
                    name: "FK_MusicCommentVotes_Clients_ClientId",
                    column: x => x.ClientId,
                    principalTable: "Clients",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_MusicCommentVotes_MusicComments_MusicCommentId",
                    column: x => x.MusicCommentId,
                    principalTable: "MusicComments",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_MusicComments_MusicId_ParentMusicCommentId_Id",
            table: "MusicComments",
            columns: new[] { "MusicId", "ParentMusicCommentId", "Id" });

        migrationBuilder.CreateIndex(
            name: "IX_MusicComments_MusicId_Timestamp_Id",
            table: "MusicComments",
            columns: new[] { "MusicId", "Timestamp", "Id" });

        migrationBuilder.CreateIndex(
            name: "IX_MusicComments_PlatformVersionId",
            table: "MusicComments",
            column: "PlatformVersionId");

        migrationBuilder.CreateIndex(
            name: "IX_MusicCommentTags_MusicCommentId",
            table: "MusicCommentTags",
            column: "MusicCommentId");

        migrationBuilder.CreateIndex(
            name: "IX_MusicCommentTags_TaggedClientId",
            table: "MusicCommentTags",
            column: "TaggedClientId");

        migrationBuilder.CreateIndex(
            name: "IX_MusicCommentTags_TaggedMusicId",
            table: "MusicCommentTags",
            column: "TaggedMusicId");

        migrationBuilder.CreateIndex(
            name: "IX_MusicCommentTags_TaggedMusicVideoId",
            table: "MusicCommentTags",
            column: "TaggedMusicVideoId");

        migrationBuilder.CreateIndex(
            name: "IX_MusicCommentTags_TaggedPersonId",
            table: "MusicCommentTags",
            column: "TaggedPersonId");

        migrationBuilder.CreateIndex(
            name: "IX_MusicCommentVotes_ClientId",
            table: "MusicCommentVotes",
            column: "ClientId");

        migrationBuilder.CreateIndex(
            name: "IX_MusicCommentVotes_MusicCommentId_ClientId",
            table: "MusicCommentVotes",
            columns: new[] { "MusicCommentId", "ClientId" },
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_MusicCommentVotes_MusicCommentId_IsLike",
            table: "MusicCommentVotes",
            columns: new[] { "MusicCommentId", "IsLike" });

        migrationBuilder.AddForeignKey(
            name: "FK_MusicComments_MusicComments_MusicId_ParentMusicCommentId",
            table: "MusicComments",
            columns: new[] { "MusicId", "ParentMusicCommentId" },
            principalTable: "MusicComments",
            principalColumns: new[] { "MusicId", "Id" },
            onDelete: ReferentialAction.Restrict);

        migrationBuilder.AddForeignKey(
            name: "FK_MusicComments_PlatformVersions_PlatformVersionId",
            table: "MusicComments",
            column: "PlatformVersionId",
            principalTable: "PlatformVersions",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_MusicComments_MusicComments_MusicId_ParentMusicCommentId",
            table: "MusicComments");

        migrationBuilder.DropForeignKey(
            name: "FK_MusicComments_PlatformVersions_PlatformVersionId",
            table: "MusicComments");

        migrationBuilder.DropTable(
            name: "MusicCommentTags");

        migrationBuilder.DropTable(
            name: "MusicCommentVotes");

        migrationBuilder.DropUniqueConstraint(
            name: "AK_MusicComments_MusicId_Id",
            table: "MusicComments");

        migrationBuilder.DropIndex(
            name: "IX_MusicComments_MusicId_ParentMusicCommentId_Id",
            table: "MusicComments");

        migrationBuilder.DropIndex(
            name: "IX_MusicComments_MusicId_Timestamp_Id",
            table: "MusicComments");

        migrationBuilder.DropIndex(
            name: "IX_MusicComments_PlatformVersionId",
            table: "MusicComments");

        migrationBuilder.DropColumn(
            name: "ParentMusicCommentId",
            table: "MusicComments");

        migrationBuilder.DropColumn(
            name: "PlatformVersionId",
            table: "MusicComments");

        migrationBuilder.CreateIndex(
            name: "IX_MusicComments_MusicId",
            table: "MusicComments",
            column: "MusicId");
    }
}

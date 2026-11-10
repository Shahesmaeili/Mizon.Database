using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mizon.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddMusicFeatures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MusicLikes_MusicId",
                table: "MusicLikes");

            migrationBuilder.CreateTable(
                name: "MusicFeatureContentTypes",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    PersianTitle = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicFeatureContentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MusicFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MusicId = table.Column<int>(type: "int", nullable: false),
                    ContentMediaId = table.Column<int>(type: "int", nullable: false),
                    PreviewMediaId = table.Column<int>(type: "int", nullable: true),
                    MusicFeatureContentTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    DisplaySeconds = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    StartDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ExpireDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MusicFeatures_Medias_ContentMediaId",
                        column: x => x.ContentMediaId,
                        principalTable: "Medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MusicFeatures_Medias_PreviewMediaId",
                        column: x => x.PreviewMediaId,
                        principalTable: "Medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MusicFeatures_MusicFeatureContentTypes_MusicFeatureContentTypeId",
                        column: x => x.MusicFeatureContentTypeId,
                        principalTable: "MusicFeatureContentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MusicFeatures_Musics_MusicId",
                        column: x => x.MusicId,
                        principalTable: "Musics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "MusicFeatureContentTypes",
                columns: new[] { "Id", "Code", "CreateDateTime", "PersianTitle", "PublicId", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { (byte)1, "image", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "تصویر", new Guid("d829f512-1ce7-4c64-b562-133f3594f001"), "Image", null },
                    { (byte)2, "video", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "ویدیو", new Guid("d829f512-1ce7-4c64-b562-133f3594f002"), "Video", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MusicLikes_MusicId_ClientId",
                table: "MusicLikes",
                columns: new[] { "MusicId", "ClientId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MusicFeatureContentTypes_Code",
                table: "MusicFeatureContentTypes",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MusicFeatureContentTypes_PublicId",
                table: "MusicFeatureContentTypes",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MusicFeatures_ContentMediaId",
                table: "MusicFeatures",
                column: "ContentMediaId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicFeatures_IsActive_Id",
                table: "MusicFeatures",
                columns: new[] { "IsActive", "Id" },
                descending: new[] { false, true });

            migrationBuilder.CreateIndex(
                name: "IX_MusicFeatures_MusicFeatureContentTypeId",
                table: "MusicFeatures",
                column: "MusicFeatureContentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicFeatures_MusicId",
                table: "MusicFeatures",
                column: "MusicId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicFeatures_PreviewMediaId",
                table: "MusicFeatures",
                column: "PreviewMediaId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicFeatures_PublicId",
                table: "MusicFeatures",
                column: "PublicId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MusicFeatures");

            migrationBuilder.DropTable(
                name: "MusicFeatureContentTypes");

            migrationBuilder.DropIndex(
                name: "IX_MusicLikes_MusicId_ClientId",
                table: "MusicLikes");

            migrationBuilder.CreateIndex(
                name: "IX_MusicLikes_MusicId",
                table: "MusicLikes",
                column: "MusicId");
        }
    }
}

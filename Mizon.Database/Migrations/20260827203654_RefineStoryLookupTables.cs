using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mizon.Database.Migrations
{
    /// <inheritdoc />
    public partial class RefineStoryLookupTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Caption",
                table: "Stories");

            migrationBuilder.RenameColumn(
                name: "WidgetType",
                table: "StoryWidgets",
                newName: "StoryWidgetTypeId");

            migrationBuilder.RenameColumn(
                name: "Style",
                table: "StoryWidgets",
                newName: "StoryWidgetStyleId");

            migrationBuilder.RenameColumn(
                name: "ContentType",
                table: "Stories",
                newName: "StoryContentTypeId");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ExpireDateTime",
                table: "Stories",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Stories",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StoryContentTypes",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    PersianTitle = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoryContentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StoryWidgetTypes",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    PersianTitle = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoryWidgetTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StoryWidgetStyles",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoryWidgetTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    PersianTitle = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoryWidgetStyles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoryWidgetStyles_StoryWidgetTypes_StoryWidgetTypeId",
                        column: x => x.StoryWidgetTypeId,
                        principalTable: "StoryWidgetTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "StoryContentTypes",
                columns: new[] { "Id", "CreateDateTime", "PersianTitle", "PublicId", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { (byte)1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "تصویر", new Guid("c24a20a7-849b-41cb-a7a6-8a0df698a001"), "Image", null },
                    { (byte)2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "ویدیو", new Guid("c24a20a7-849b-41cb-a7a6-8a0df698a002"), "Video", null }
                });

            migrationBuilder.InsertData(
                table: "StoryWidgetTypes",
                columns: new[] { "Id", "CreateDateTime", "PersianTitle", "PublicId", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { (byte)1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "تگ کاربر", new Guid("e5b4a410-17c2-48c6-ae1e-7707b9240001"), "ClientTag", null },
                    { (byte)2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "تگ موسیقی", new Guid("e5b4a410-17c2-48c6-ae1e-7707b9240002"), "MusicTag", null }
                });

            migrationBuilder.InsertData(
                table: "StoryWidgetStyles",
                columns: new[] { "Id", "CreateDateTime", "PersianTitle", "PublicId", "StoryWidgetTypeId", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { (short)1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "کلاسیک", new Guid("b03f6d02-5661-4100-a3f3-571d1f030001"), (byte)1, "Classic", null },
                    { (short)2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "جمع‌وجور", new Guid("b03f6d02-5661-4100-a3f3-571d1f030002"), (byte)1, "Compact", null },
                    { (short)11, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "کلاسیک", new Guid("b03f6d02-5661-4100-a3f3-571d1f030011"), (byte)2, "Classic", null },
                    { (short)12, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "جمع‌وجور", new Guid("b03f6d02-5661-4100-a3f3-571d1f030012"), (byte)2, "Compact", null }
                });

            migrationBuilder.Sql("""
                UPDATE StoryWidgets
                SET StoryWidgetStyleId = CASE StoryWidgetTypeId
                    WHEN 2 THEN 11
                    ELSE 1
                END
                WHERE StoryWidgetStyleId NOT IN (1, 2, 11, 12);
                """);

            migrationBuilder.CreateIndex(
                name: "IX_StoryWidgets_StoryWidgetStyleId",
                table: "StoryWidgets",
                column: "StoryWidgetStyleId");

            migrationBuilder.CreateIndex(
                name: "IX_StoryWidgets_StoryWidgetTypeId",
                table: "StoryWidgets",
                column: "StoryWidgetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Stories_StoryContentTypeId",
                table: "Stories",
                column: "StoryContentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StoryContentTypes_PublicId",
                table: "StoryContentTypes",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StoryWidgetStyles_PublicId",
                table: "StoryWidgetStyles",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StoryWidgetStyles_StoryWidgetTypeId_Title",
                table: "StoryWidgetStyles",
                columns: new[] { "StoryWidgetTypeId", "Title" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StoryWidgetTypes_PublicId",
                table: "StoryWidgetTypes",
                column: "PublicId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Stories_StoryContentTypes_StoryContentTypeId",
                table: "Stories",
                column: "StoryContentTypeId",
                principalTable: "StoryContentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StoryWidgets_StoryWidgetStyles_StoryWidgetStyleId",
                table: "StoryWidgets",
                column: "StoryWidgetStyleId",
                principalTable: "StoryWidgetStyles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StoryWidgets_StoryWidgetTypes_StoryWidgetTypeId",
                table: "StoryWidgets",
                column: "StoryWidgetTypeId",
                principalTable: "StoryWidgetTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stories_StoryContentTypes_StoryContentTypeId",
                table: "Stories");

            migrationBuilder.DropForeignKey(
                name: "FK_StoryWidgets_StoryWidgetStyles_StoryWidgetStyleId",
                table: "StoryWidgets");

            migrationBuilder.DropForeignKey(
                name: "FK_StoryWidgets_StoryWidgetTypes_StoryWidgetTypeId",
                table: "StoryWidgets");

            migrationBuilder.DropTable(
                name: "StoryContentTypes");

            migrationBuilder.DropTable(
                name: "StoryWidgetStyles");

            migrationBuilder.DropTable(
                name: "StoryWidgetTypes");

            migrationBuilder.DropIndex(
                name: "IX_StoryWidgets_StoryWidgetStyleId",
                table: "StoryWidgets");

            migrationBuilder.DropIndex(
                name: "IX_StoryWidgets_StoryWidgetTypeId",
                table: "StoryWidgets");

            migrationBuilder.DropIndex(
                name: "IX_Stories_StoryContentTypeId",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Stories");

            migrationBuilder.RenameColumn(
                name: "StoryWidgetTypeId",
                table: "StoryWidgets",
                newName: "WidgetType");

            migrationBuilder.RenameColumn(
                name: "StoryWidgetStyleId",
                table: "StoryWidgets",
                newName: "Style");

            migrationBuilder.RenameColumn(
                name: "StoryContentTypeId",
                table: "Stories",
                newName: "ContentType");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ExpireDateTime",
                table: "Stories",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Caption",
                table: "Stories",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);
        }
    }
}

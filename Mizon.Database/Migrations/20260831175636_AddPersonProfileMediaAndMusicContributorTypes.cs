using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mizon.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddPersonProfileMediaAndMusicContributorTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfileMediaId",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "MusicContributorTypes",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PersianTitle",
                table: "MusicContributorTypes",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.Sql("""
                MERGE [MusicContributorTypes] AS target
                USING (VALUES
                    (CONVERT(tinyint, 1), CONVERT(uniqueidentifier, 'c5fb8a20-4dc5-45a6-9111-001000000001'), N'LeadVocal', N'خواننده اصلی'),
                    (CONVERT(tinyint, 2), CONVERT(uniqueidentifier, 'c5fb8a20-4dc5-45a6-9111-001000000002'), N'FeaturedVocal', N'خواننده مهمان'),
                    (CONVERT(tinyint, 3), CONVERT(uniqueidentifier, 'c5fb8a20-4dc5-45a6-9111-001000000003'), N'Composer', N'آهنگساز'),
                    (CONVERT(tinyint, 4), CONVERT(uniqueidentifier, 'c5fb8a20-4dc5-45a6-9111-001000000004'), N'Lyricist', N'ترانه‌سرا'),
                    (CONVERT(tinyint, 5), CONVERT(uniqueidentifier, 'c5fb8a20-4dc5-45a6-9111-001000000005'), N'Arranger', N'تنظیم‌کننده'),
                    (CONVERT(tinyint, 6), CONVERT(uniqueidentifier, 'c5fb8a20-4dc5-45a6-9111-001000000006'), N'Producer', N'تهیه‌کننده'),
                    (CONVERT(tinyint, 7), CONVERT(uniqueidentifier, 'c5fb8a20-4dc5-45a6-9111-001000000007'), N'MixingEngineer', N'مهندس میکس'),
                    (CONVERT(tinyint, 8), CONVERT(uniqueidentifier, 'c5fb8a20-4dc5-45a6-9111-001000000008'), N'MasteringEngineer', N'مهندس مسترینگ'),
                    (CONVERT(tinyint, 9), CONVERT(uniqueidentifier, 'c5fb8a20-4dc5-45a6-9111-001000000009'), N'Instrumentalist', N'نوازنده'),
                    (CONVERT(tinyint, 10), CONVERT(uniqueidentifier, 'c5fb8a20-4dc5-45a6-9111-001000000010'), N'Guitarist', N'گیتاریست'),
                    (CONVERT(tinyint, 11), CONVERT(uniqueidentifier, 'c5fb8a20-4dc5-45a6-9111-001000000011'), N'RecordingEngineer', N'مهندس ضبط'),
                    (CONVERT(tinyint, 12), CONVERT(uniqueidentifier, 'c5fb8a20-4dc5-45a6-9111-001000000012'), N'Director', N'کارگردان'),
                    (CONVERT(tinyint, 13), CONVERT(uniqueidentifier, 'c5fb8a20-4dc5-45a6-9111-001000000013'), N'Artwork', N'طراح کاور'),
                    (CONVERT(tinyint, 14), CONVERT(uniqueidentifier, 'c5fb8a20-4dc5-45a6-9111-001000000014'), N'Remixer', N'ریمیکسر'),
                    (CONVERT(tinyint, 15), CONVERT(uniqueidentifier, 'c5fb8a20-4dc5-45a6-9111-001000000015'), N'Publisher', N'ناشر')) AS source ([Id], [PublicId], [Title], [PersianTitle])
                ON target.[Id] = source.[Id]
                WHEN MATCHED THEN UPDATE SET [PublicId] = source.[PublicId], [Title] = source.[Title], [PersianTitle] = source.[PersianTitle], [UpdateDateTime] = SYSUTCDATETIME()
                WHEN NOT MATCHED THEN INSERT ([Id], [PublicId], [Title], [PersianTitle], [CreateDateTime], [UpdateDateTime]) VALUES (source.[Id], source.[PublicId], source.[Title], source.[PersianTitle], SYSUTCDATETIME(), NULL);
                """);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_ProfileMediaId",
                table: "Persons",
                column: "ProfileMediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Medias_ProfileMediaId",
                table: "Persons",
                column: "ProfileMediaId",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Medias_ProfileMediaId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_ProfileMediaId",
                table: "Persons");

            migrationBuilder.DeleteData(
                table: "MusicContributorTypes",
                keyColumn: "Id",
                keyValue: (byte)1);

            migrationBuilder.DeleteData(
                table: "MusicContributorTypes",
                keyColumn: "Id",
                keyValue: (byte)2);

            migrationBuilder.DeleteData(
                table: "MusicContributorTypes",
                keyColumn: "Id",
                keyValue: (byte)3);

            migrationBuilder.DeleteData(
                table: "MusicContributorTypes",
                keyColumn: "Id",
                keyValue: (byte)4);

            migrationBuilder.DeleteData(
                table: "MusicContributorTypes",
                keyColumn: "Id",
                keyValue: (byte)5);

            migrationBuilder.DeleteData(
                table: "MusicContributorTypes",
                keyColumn: "Id",
                keyValue: (byte)6);

            migrationBuilder.DeleteData(
                table: "MusicContributorTypes",
                keyColumn: "Id",
                keyValue: (byte)7);

            migrationBuilder.DeleteData(
                table: "MusicContributorTypes",
                keyColumn: "Id",
                keyValue: (byte)8);

            migrationBuilder.DeleteData(
                table: "MusicContributorTypes",
                keyColumn: "Id",
                keyValue: (byte)9);

            migrationBuilder.DeleteData(
                table: "MusicContributorTypes",
                keyColumn: "Id",
                keyValue: (byte)10);

            migrationBuilder.DeleteData(
                table: "MusicContributorTypes",
                keyColumn: "Id",
                keyValue: (byte)11);

            migrationBuilder.DeleteData(
                table: "MusicContributorTypes",
                keyColumn: "Id",
                keyValue: (byte)12);

            migrationBuilder.DeleteData(
                table: "MusicContributorTypes",
                keyColumn: "Id",
                keyValue: (byte)13);

            migrationBuilder.DeleteData(
                table: "MusicContributorTypes",
                keyColumn: "Id",
                keyValue: (byte)14);

            migrationBuilder.DeleteData(
                table: "MusicContributorTypes",
                keyColumn: "Id",
                keyValue: (byte)15);

            migrationBuilder.DropColumn(
                name: "ProfileMediaId",
                table: "Persons");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "MusicContributorTypes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<string>(
                name: "PersianTitle",
                table: "MusicContributorTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32,
                oldNullable: true);
        }
    }
}

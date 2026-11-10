using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mizon.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddMusicFileQualityChannelLayouts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChannelLayout",
                table: "MusicFileQualityChannels",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "MusicFileQualityChannels",
                keyColumn: "Id",
                keyValue: (byte)1,
                column: "ChannelLayout",
                value: "mono");

            migrationBuilder.UpdateData(
                table: "MusicFileQualityChannels",
                keyColumn: "Id",
                keyValue: (byte)2,
                column: "ChannelLayout",
                value: "stereo");

            migrationBuilder.UpdateData(
                table: "MusicFileQualityChannels",
                keyColumn: "Id",
                keyValue: (byte)3,
                column: "ChannelLayout",
                value: "5.1");

            migrationBuilder.UpdateData(
                table: "MusicFileQualityChannels",
                keyColumn: "Id",
                keyValue: (byte)4,
                column: "ChannelLayout",
                value: "7.1");

            migrationBuilder.InsertData(
                table: "MusicFileQualityChannels",
                columns: new[] { "Id", "ChannelCount", "ChannelLayout", "CreateDateTime", "PersianTitle", "PublicId", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { (byte)5, (byte)3, "2.1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "دو‌ویک", new Guid("b7bdc100-0000-4000-8000-000000000005"), "2.1", null },
                    { (byte)6, (byte)4, "quad", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "چهارکاناله", new Guid("b7bdc100-0000-4000-8000-000000000006"), "Quad", null },
                    { (byte)7, (byte)5, "5.0", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "پنج‌کاناله", new Guid("b7bdc100-0000-4000-8000-000000000007"), "5.0", null },
                    { (byte)8, (byte)7, "6.1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "شش‌ویک", new Guid("b7bdc100-0000-4000-8000-000000000008"), "6.1", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MusicFileQualityChannels",
                keyColumn: "Id",
                keyValue: (byte)5);

            migrationBuilder.DeleteData(
                table: "MusicFileQualityChannels",
                keyColumn: "Id",
                keyValue: (byte)6);

            migrationBuilder.DeleteData(
                table: "MusicFileQualityChannels",
                keyColumn: "Id",
                keyValue: (byte)7);

            migrationBuilder.DeleteData(
                table: "MusicFileQualityChannels",
                keyColumn: "Id",
                keyValue: (byte)8);

            migrationBuilder.DropColumn(
                name: "ChannelLayout",
                table: "MusicFileQualityChannels");
        }
    }
}

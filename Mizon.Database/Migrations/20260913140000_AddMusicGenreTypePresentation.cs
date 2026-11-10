using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mizon.Database.Migrations;

[Migration("20260913140000_AddMusicGenreTypePresentation")]
public partial class AddMusicGenreTypePresentation : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
            name: "AccentColorHex",
            table: "MusicGenreTypes",
            type: "nvarchar(9)",
            maxLength: 9,
            nullable: false,
            defaultValue: "#7DD3FC");

        migrationBuilder.AddColumn<string>(
            name: "IconSymbol",
            table: "MusicGenreTypes",
            type: "nvarchar(64)",
            maxLength: 64,
            nullable: false,
            defaultValue: "MusicNote1");

        migrationBuilder.UpdateData(
            table: "MusicGenreTypes",
            keyColumn: "Id",
            keyValue: (byte)1,
            columns: new[] { "AccentColorHex", "IconSymbol" },
            values: new object[] { "#EC4899", "MusicNote1" });

        migrationBuilder.UpdateData(
            table: "MusicGenreTypes",
            keyColumn: "Id",
            keyValue: (byte)2,
            columns: new[] { "AccentColorHex", "IconSymbol" },
            values: new object[] { "#F97316", "Mic" });

        migrationBuilder.UpdateData(
            table: "MusicGenreTypes",
            keyColumn: "Id",
            keyValue: (byte)3,
            columns: new[] { "AccentColorHex", "IconSymbol" },
            values: new object[] { "#FB7185", "Heart" });

        migrationBuilder.InsertData(
            table: "MusicGenreTypes",
            columns: new[] { "Id", "AccentColorHex", "CreateDateTime", "IconSymbol", "PersianTitle", "PublicId", "Title", "UpdateDateTime" },
            values: new object[,]
            {
                { (byte)4, "#EF4444", DateTimeOffset.MinValue, "Speaker2", "راک", new Guid("0195dd3c-9a3e-7c4a-8c6f-2e9c0f6b1a75"), "Rock", null },
                { (byte)5, "#A855F7", DateTimeOffset.MinValue, "MusicNote1", "آر اند بی", new Guid("0195dd3c-9a3e-7c4a-8c6f-2e9c0f6b1a76"), "R&B", null },
                { (byte)6, "#06B6D4", DateTimeOffset.MinValue, "Speaker2", "الکترونیک", new Guid("0195dd3c-9a3e-7c4a-8c6f-2e9c0f6b1a77"), "Electronic", null },
                { (byte)7, "#F59E0B", DateTimeOffset.MinValue, "MusicNote1", "دنس", new Guid("0195dd3c-9a3e-7c4a-8c6f-2e9c0f6b1a78"), "Dance", null },
                { (byte)8, "#14B8A6", DateTimeOffset.MinValue, "Speaker2", "هاوس", new Guid("0195dd3c-9a3e-7c4a-8c6f-2e9c0f6b1a79"), "House", null },
                { (byte)9, "#8B5CF6", DateTimeOffset.MinValue, "Speaker2", "تکنو", new Guid("0195dd3c-9a3e-7c4a-8c6f-2e9c0f6b1a7a"), "Techno", null },
                { (byte)10, "#38BDF8", DateTimeOffset.MinValue, "Speaker2", "ترنس", new Guid("0195dd3c-9a3e-7c4a-8c6f-2e9c0f6b1a7b"), "Trance", null },
                { (byte)11, "#6366F1", DateTimeOffset.MinValue, "Speaker2", "داب‌استپ", new Guid("0195dd3c-9a3e-7c4a-8c6f-2e9c0f6b1a7c"), "Dubstep", null },
                { (byte)12, "#D97706", DateTimeOffset.MinValue, "MusicNote1", "جز", new Guid("0195dd3c-9a3e-7c4a-8c6f-2e9c0f6b1a7d"), "Jazz", null },
                { (byte)13, "#2563EB", DateTimeOffset.MinValue, "MusicNote1", "بلوز", new Guid("0195dd3c-9a3e-7c4a-8c6f-2e9c0f6b1a7e"), "Blues", null },
                { (byte)14, "#64748B", DateTimeOffset.MinValue, "MusicNote1", "کلاسیک", new Guid("0195dd3c-9a3e-7c4a-8c6f-2e9c0f6b1a7f"), "Classical", null },
                { (byte)15, "#92400E", DateTimeOffset.MinValue, "Guitar", "کانتری", new Guid("0195dd3c-9a3e-7c4a-8c6f-2e9c0f6b1a80"), "Country", null },
                { (byte)16, "#65A30D", DateTimeOffset.MinValue, "Guitar", "فولک", new Guid("0195dd3c-9a3e-7c4a-8c6f-2e9c0f6b1a81"), "Folk", null },
                { (byte)17, "#94A3B8", DateTimeOffset.MinValue, "Speaker2", "متال", new Guid("0195dd3c-9a3e-7c4a-8c6f-2e9c0f6b1a82"), "Metal", null },
                { (byte)18, "#22C55E", DateTimeOffset.MinValue, "MusicNote1", "آلترناتیو", new Guid("0195dd3c-9a3e-7c4a-8c6f-2e9c0f6b1a83"), "Alternative", null },
                { (byte)19, "#10B981", DateTimeOffset.MinValue, "MusicNote1", "ایندی", new Guid("0195dd3c-9a3e-7c4a-8c6f-2e9c0f6b1a84"), "Indie", null },
                { (byte)20, "#16A34A", DateTimeOffset.MinValue, "MusicNote1", "رگه", new Guid("0195dd3c-9a3e-7c4a-8c6f-2e9c0f6b1a85"), "Reggae", null },
                { (byte)21, "#DC2626", DateTimeOffset.MinValue, "MusicNote1", "لاتین", new Guid("0195dd3c-9a3e-7c4a-8c6f-2e9c0f6b1a86"), "Latin", null },
                { (byte)22, "#0EA5E9", DateTimeOffset.MinValue, "Earth", "ملل", new Guid("0195dd3c-9a3e-7c4a-8c6f-2e9c0f6b1a87"), "World", null },
                { (byte)23, "#7C3AED", DateTimeOffset.MinValue, "Video", "موسیقی متن", new Guid("0195dd3c-9a3e-7c4a-8c6f-2e9c0f6b1a88"), "Soundtrack", null },
                { (byte)24, "#FACC15", DateTimeOffset.MinValue, "MusicNote1", "کودک", new Guid("0195dd3c-9a3e-7c4a-8c6f-2e9c0f6b1a89"), "Children's Music", null },
                { (byte)25, "#0EA5E9", DateTimeOffset.MinValue, "Mic", "گفتاری", new Guid("0195dd3c-9a3e-7c4a-8c6f-2e9c0f6b1a8a"), "Spoken Word", null },
                { (byte)26, "#F97316", DateTimeOffset.MinValue, "Emoji", "کمدی", new Guid("0195dd3c-9a3e-7c4a-8c6f-2e9c0f6b1a8b"), "Comedy", null },
                { (byte)27, "#64748B", DateTimeOffset.MinValue, "Mic", "پادکست", new Guid("0195dd3c-9a3e-7c4a-8c6f-2e9c0f6b1a8c"), "Podcast", null }
            });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        for (byte id = 4; id <= 27; id++)
        {
            migrationBuilder.DeleteData(
                table: "MusicGenreTypes",
                keyColumn: "Id",
                keyValue: id);
        }

        migrationBuilder.DropColumn(
            name: "AccentColorHex",
            table: "MusicGenreTypes");

        migrationBuilder.DropColumn(
            name: "IconSymbol",
            table: "MusicGenreTypes");
    }
}

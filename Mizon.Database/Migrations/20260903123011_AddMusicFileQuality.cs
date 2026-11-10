using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mizon.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddMusicFileQuality : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MusicFileQualityBitDepths",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    BitDepth = table.Column<byte>(type: "tinyint", nullable: false),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicFileQualityBitDepths", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MusicFileQualityChannels",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    PersianTitle = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    ChannelCount = table.Column<byte>(type: "tinyint", nullable: false),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicFileQualityChannels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MusicFileQualityCodecs",
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
                    table.PrimaryKey("PK_MusicFileQualityCodecs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MusicFileQualityEncoderModes",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicFileQualityEncoderModes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MusicFileQualityEncoders",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicFileQualityEncoders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MusicFileQualityFormats",
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
                    table.PrimaryKey("PK_MusicFileQualityFormats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MusicFileQualitySampleFormats",
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
                    table.PrimaryKey("PK_MusicFileQualitySampleFormats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MusicFileQualities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MusicFileId = table.Column<int>(type: "int", nullable: false),
                    BitrateKbps = table.Column<int>(type: "int", nullable: true),
                    IsVariableBitRate = table.Column<bool>(type: "bit", nullable: false),
                    SampleRateHz = table.Column<int>(type: "int", nullable: false),
                    ChannelCount = table.Column<byte>(type: "tinyint", nullable: false),
                    MusicFileQualityChannelId = table.Column<byte>(type: "tinyint", nullable: false),
                    MusicFileQualityCodecId = table.Column<byte>(type: "tinyint", nullable: false),
                    MusicFileQualityFormatId = table.Column<byte>(type: "tinyint", nullable: false),
                    MusicFileQualityBitDepthId = table.Column<byte>(type: "tinyint", nullable: true),
                    MusicFileQualitySampleFormatId = table.Column<byte>(type: "tinyint", nullable: true),
                    MusicFileQualityEncoderId = table.Column<byte>(type: "tinyint", nullable: true),
                    MusicFileQualityEncoderModeId = table.Column<byte>(type: "tinyint", nullable: true),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicFileQualities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MusicFileQualities_MusicFileQualityBitDepths_MusicFileQualityBitDepthId",
                        column: x => x.MusicFileQualityBitDepthId,
                        principalTable: "MusicFileQualityBitDepths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MusicFileQualities_MusicFileQualityChannels_MusicFileQualityChannelId",
                        column: x => x.MusicFileQualityChannelId,
                        principalTable: "MusicFileQualityChannels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MusicFileQualities_MusicFileQualityCodecs_MusicFileQualityCodecId",
                        column: x => x.MusicFileQualityCodecId,
                        principalTable: "MusicFileQualityCodecs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MusicFileQualities_MusicFileQualityEncoderModes_MusicFileQualityEncoderModeId",
                        column: x => x.MusicFileQualityEncoderModeId,
                        principalTable: "MusicFileQualityEncoderModes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MusicFileQualities_MusicFileQualityEncoders_MusicFileQualityEncoderId",
                        column: x => x.MusicFileQualityEncoderId,
                        principalTable: "MusicFileQualityEncoders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MusicFileQualities_MusicFileQualityFormats_MusicFileQualityFormatId",
                        column: x => x.MusicFileQualityFormatId,
                        principalTable: "MusicFileQualityFormats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MusicFileQualities_MusicFileQualitySampleFormats_MusicFileQualitySampleFormatId",
                        column: x => x.MusicFileQualitySampleFormatId,
                        principalTable: "MusicFileQualitySampleFormats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MusicFileQualities_MusicFiles_MusicFileId",
                        column: x => x.MusicFileId,
                        principalTable: "MusicFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MusicFileQualityBitDepths",
                columns: new[] { "Id", "BitDepth", "CreateDateTime", "PublicId", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { (byte)1, (byte)8, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b7bdc101-0000-4000-8000-000000000001"), "8-bit", null },
                    { (byte)2, (byte)16, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b7bdc101-0000-4000-8000-000000000002"), "16-bit", null },
                    { (byte)3, (byte)24, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b7bdc101-0000-4000-8000-000000000003"), "24-bit", null },
                    { (byte)4, (byte)32, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b7bdc101-0000-4000-8000-000000000004"), "32-bit", null }
                });

            migrationBuilder.InsertData(
                table: "MusicFileQualityChannels",
                columns: new[] { "Id", "ChannelCount", "CreateDateTime", "PersianTitle", "PublicId", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { (byte)1, (byte)1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "مونو", new Guid("b7bdc100-0000-4000-8000-000000000001"), "Mono", null },
                    { (byte)2, (byte)2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "استریو", new Guid("b7bdc100-0000-4000-8000-000000000002"), "Stereo", null },
                    { (byte)3, (byte)6, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "پنج‌ویک", new Guid("b7bdc100-0000-4000-8000-000000000003"), "5.1", null },
                    { (byte)4, (byte)8, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "هفت‌ویک", new Guid("b7bdc100-0000-4000-8000-000000000004"), "7.1", null }
                });

            migrationBuilder.InsertData(
                table: "MusicFileQualityCodecs",
                columns: new[] { "Id", "CreateDateTime", "PersianTitle", "PublicId", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { (byte)1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b7bdc102-0000-4000-8000-000000000001"), "MP3", null },
                    { (byte)2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b7bdc102-0000-4000-8000-000000000002"), "AAC", null },
                    { (byte)3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b7bdc102-0000-4000-8000-000000000003"), "FLAC", null },
                    { (byte)4, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b7bdc102-0000-4000-8000-000000000004"), "PCM", null },
                    { (byte)5, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b7bdc102-0000-4000-8000-000000000005"), "Opus", null },
                    { (byte)6, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b7bdc102-0000-4000-8000-000000000006"), "Vorbis", null },
                    { (byte)7, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b7bdc102-0000-4000-8000-000000000007"), "ALAC", null }
                });

            migrationBuilder.InsertData(
                table: "MusicFileQualityEncoderModes",
                columns: new[] { "Id", "CreateDateTime", "PublicId", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { (byte)1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b7bdc106-0000-4000-8000-000000000001"), "CBR", null },
                    { (byte)2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b7bdc106-0000-4000-8000-000000000002"), "VBR", null },
                    { (byte)3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b7bdc106-0000-4000-8000-000000000003"), "ABR", null },
                    { (byte)4, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b7bdc106-0000-4000-8000-000000000004"), "Lossless", null }
                });

            migrationBuilder.InsertData(
                table: "MusicFileQualityEncoders",
                columns: new[] { "Id", "CreateDateTime", "PublicId", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { (byte)1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b7bdc105-0000-4000-8000-000000000001"), "LAME", null },
                    { (byte)2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b7bdc105-0000-4000-8000-000000000002"), "FFmpeg", null },
                    { (byte)3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b7bdc105-0000-4000-8000-000000000003"), "libfdk_aac", null },
                    { (byte)4, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b7bdc105-0000-4000-8000-000000000004"), "libopus", null },
                    { (byte)5, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("b7bdc105-0000-4000-8000-000000000005"), "reference flac", null }
                });

            migrationBuilder.InsertData(
                table: "MusicFileQualityFormats",
                columns: new[] { "Id", "CreateDateTime", "PersianTitle", "PublicId", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { (byte)1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b7bdc103-0000-4000-8000-000000000001"), "MP3", null },
                    { (byte)2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b7bdc103-0000-4000-8000-000000000002"), "MP4", null },
                    { (byte)3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b7bdc103-0000-4000-8000-000000000003"), "WAV", null },
                    { (byte)4, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b7bdc103-0000-4000-8000-000000000004"), "FLAC", null },
                    { (byte)5, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b7bdc103-0000-4000-8000-000000000005"), "Ogg", null },
                    { (byte)6, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b7bdc103-0000-4000-8000-000000000006"), "WebM", null },
                    { (byte)7, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, new Guid("b7bdc103-0000-4000-8000-000000000007"), "Matroska", null }
                });

            migrationBuilder.InsertData(
                table: "MusicFileQualitySampleFormats",
                columns: new[] { "Id", "CreateDateTime", "PersianTitle", "PublicId", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { (byte)1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "۸ بیت بدون علامت", new Guid("b7bdc104-0000-4000-8000-000000000001"), "Unsigned 8-bit", null },
                    { (byte)2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "۱۶ بیت علامت‌دار", new Guid("b7bdc104-0000-4000-8000-000000000002"), "Signed 16-bit", null },
                    { (byte)3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "۲۴ بیت علامت‌دار", new Guid("b7bdc104-0000-4000-8000-000000000003"), "Signed 24-bit", null },
                    { (byte)4, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "۳۲ بیت علامت‌دار", new Guid("b7bdc104-0000-4000-8000-000000000004"), "Signed 32-bit", null },
                    { (byte)5, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "شناور ۳۲ بیت", new Guid("b7bdc104-0000-4000-8000-000000000005"), "Float 32-bit", null },
                    { (byte)6, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "شناور ۶۴ بیت", new Guid("b7bdc104-0000-4000-8000-000000000006"), "Float 64-bit", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MusicFileQualities_MusicFileId",
                table: "MusicFileQualities",
                column: "MusicFileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MusicFileQualities_MusicFileQualityBitDepthId",
                table: "MusicFileQualities",
                column: "MusicFileQualityBitDepthId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicFileQualities_MusicFileQualityChannelId",
                table: "MusicFileQualities",
                column: "MusicFileQualityChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicFileQualities_MusicFileQualityCodecId",
                table: "MusicFileQualities",
                column: "MusicFileQualityCodecId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicFileQualities_MusicFileQualityEncoderId",
                table: "MusicFileQualities",
                column: "MusicFileQualityEncoderId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicFileQualities_MusicFileQualityEncoderModeId",
                table: "MusicFileQualities",
                column: "MusicFileQualityEncoderModeId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicFileQualities_MusicFileQualityFormatId",
                table: "MusicFileQualities",
                column: "MusicFileQualityFormatId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicFileQualities_MusicFileQualitySampleFormatId",
                table: "MusicFileQualities",
                column: "MusicFileQualitySampleFormatId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicFileQualities_PublicId",
                table: "MusicFileQualities",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MusicFileQualityBitDepths_PublicId",
                table: "MusicFileQualityBitDepths",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MusicFileQualityChannels_PublicId",
                table: "MusicFileQualityChannels",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MusicFileQualityCodecs_PublicId",
                table: "MusicFileQualityCodecs",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MusicFileQualityEncoderModes_PublicId",
                table: "MusicFileQualityEncoderModes",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MusicFileQualityEncoders_PublicId",
                table: "MusicFileQualityEncoders",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MusicFileQualityFormats_PublicId",
                table: "MusicFileQualityFormats",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MusicFileQualitySampleFormats_PublicId",
                table: "MusicFileQualitySampleFormats",
                column: "PublicId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MusicFileQualities");

            migrationBuilder.DropTable(
                name: "MusicFileQualityBitDepths");

            migrationBuilder.DropTable(
                name: "MusicFileQualityChannels");

            migrationBuilder.DropTable(
                name: "MusicFileQualityCodecs");

            migrationBuilder.DropTable(
                name: "MusicFileQualityEncoderModes");

            migrationBuilder.DropTable(
                name: "MusicFileQualityEncoders");

            migrationBuilder.DropTable(
                name: "MusicFileQualityFormats");

            migrationBuilder.DropTable(
                name: "MusicFileQualitySampleFormats");
        }
    }
}

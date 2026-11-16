using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mizon.Database.Migrations;

/// <inheritdoc />
public partial class _20261116060818_AddFeaturedPersons : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropIndex(
            name: "IX_MusicPlays_MusicId",
            table: "MusicPlays");

        migrationBuilder.CreateTable(
            name: "FeaturedPersonTypes",
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
                table.PrimaryKey("PK_FeaturedPersonTypes", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "FeaturedPersons",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                FeaturedPersonTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                PersonId = table.Column<int>(type: "int", nullable: false),
                SortOrder = table.Column<short>(type: "smallint", nullable: false),
                AccentColor = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                ModelAttribution = table.Column<string>(type: "nvarchar(240)", maxLength: 240, nullable: true),
                ModelYawInDegrees = table.Column<float>(type: "real", nullable: false),
                ModelViewScale = table.Column<float>(type: "real", nullable: false),
                ModelVerticalFocus = table.Column<float>(type: "real", nullable: false),
                CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_FeaturedPersons", x => x.Id);
                table.CheckConstraint("CK_FeaturedPersons_SortOrder", "[SortOrder] > 0");
                table.ForeignKey(
                    name: "FK_FeaturedPersons_FeaturedPersonTypes_FeaturedPersonTypeId",
                    column: x => x.FeaturedPersonTypeId,
                    principalTable: "FeaturedPersonTypes",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_FeaturedPersons_Persons_PersonId",
                    column: x => x.PersonId,
                    principalTable: "Persons",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_MusicPlays_MusicId_CreateDateTime",
            table: "MusicPlays",
            columns: new[] { "MusicId", "CreateDateTime" })
            .Annotation("SqlServer:Include", new[] { "ClientId" });

        migrationBuilder.CreateIndex(
            name: "IX_FeaturedPersons_FeaturedPersonTypeId_PersonId",
            table: "FeaturedPersons",
            columns: new[] { "FeaturedPersonTypeId", "PersonId" },
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_FeaturedPersons_FeaturedPersonTypeId_SortOrder",
            table: "FeaturedPersons",
            columns: new[] { "FeaturedPersonTypeId", "SortOrder" },
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_FeaturedPersons_PersonId",
            table: "FeaturedPersons",
            column: "PersonId");

        migrationBuilder.CreateIndex(
            name: "IX_FeaturedPersons_PublicId",
            table: "FeaturedPersons",
            column: "PublicId",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_FeaturedPersonTypes_Code",
            table: "FeaturedPersonTypes",
            column: "Code",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_FeaturedPersonTypes_PublicId",
            table: "FeaturedPersonTypes",
            column: "PublicId",
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "FeaturedPersons");

        migrationBuilder.DropTable(
            name: "FeaturedPersonTypes");

        migrationBuilder.DropIndex(
            name: "IX_MusicPlays_MusicId_CreateDateTime",
            table: "MusicPlays");

        migrationBuilder.CreateIndex(
            name: "IX_MusicPlays_MusicId",
            table: "MusicPlays",
            column: "MusicId");
    }
}

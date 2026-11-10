using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mizon.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddClientMoods : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientMoodTypeId",
                table: "Clients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ClientMoodTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Emoji = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false, collation: "Latin1_General_100_BIN2"),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    PersianTitle = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    AnimationMediaId = table.Column<int>(type: "int", nullable: false),
                    PreviewMediaId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientMoodTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientMoodTypes_Medias_AnimationMediaId",
                        column: x => x.AnimationMediaId,
                        principalTable: "Medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientMoodTypes_Medias_PreviewMediaId",
                        column: x => x.PreviewMediaId,
                        principalTable: "Medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientMoodEffects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientMoodTypeId = table.Column<int>(type: "int", nullable: false),
                    MediaId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientMoodEffects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientMoodEffects_ClientMoodTypes_ClientMoodTypeId",
                        column: x => x.ClientMoodTypeId,
                        principalTable: "ClientMoodTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientMoodEffects_Medias_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClientMoodTypeId",
                table: "Clients",
                column: "ClientMoodTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientMoodEffects_ClientMoodTypeId_MediaId",
                table: "ClientMoodEffects",
                columns: new[] { "ClientMoodTypeId", "MediaId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientMoodEffects_MediaId",
                table: "ClientMoodEffects",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientMoodEffects_PublicId",
                table: "ClientMoodEffects",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientMoodTypes_AnimationMediaId",
                table: "ClientMoodTypes",
                column: "AnimationMediaId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientMoodTypes_Emoji",
                table: "ClientMoodTypes",
                column: "Emoji",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientMoodTypes_PreviewMediaId",
                table: "ClientMoodTypes",
                column: "PreviewMediaId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientMoodTypes_PublicId",
                table: "ClientMoodTypes",
                column: "PublicId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_ClientMoodTypes_ClientMoodTypeId",
                table: "Clients",
                column: "ClientMoodTypeId",
                principalTable: "ClientMoodTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_ClientMoodTypes_ClientMoodTypeId",
                table: "Clients");

            migrationBuilder.DropTable(
                name: "ClientMoodEffects");

            migrationBuilder.DropTable(
                name: "ClientMoodTypes");

            migrationBuilder.DropIndex(
                name: "IX_Clients_ClientMoodTypeId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ClientMoodTypeId",
                table: "Clients");
        }
    }
}

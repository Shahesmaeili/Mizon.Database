using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mizon.Database.Migrations;

/// <inheritdoc />
public partial class AddPersonProfileMediaAndClientLink : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropIndex(
            name: "IX_MusicContributors_PersonId",
            table: "MusicContributors");

        migrationBuilder.AddColumn<int>(
            name: "CoverMediaId",
            table: "Persons",
            type: "int",
            nullable: true);

        migrationBuilder.AddColumn<int>(
            name: "LinkedClientId",
            table: "Persons",
            type: "int",
            nullable: true);

        migrationBuilder.AddColumn<int>(
            name: "ModelMediaId",
            table: "Persons",
            type: "int",
            nullable: true);

        migrationBuilder.CreateIndex(
            name: "IX_Persons_CoverMediaId",
            table: "Persons",
            column: "CoverMediaId");

        migrationBuilder.CreateIndex(
            name: "IX_Persons_LinkedClientId",
            table: "Persons",
            column: "LinkedClientId",
            unique: true,
            filter: "[LinkedClientId] IS NOT NULL");

        migrationBuilder.CreateIndex(
            name: "IX_Persons_ModelMediaId",
            table: "Persons",
            column: "ModelMediaId");

        migrationBuilder.CreateIndex(
            name: "IX_MusicContributors_PersonId_MusicId",
            table: "MusicContributors",
            columns: new[] { "PersonId", "MusicId" });

        migrationBuilder.AddForeignKey(
            name: "FK_Persons_Clients_LinkedClientId",
            table: "Persons",
            column: "LinkedClientId",
            principalTable: "Clients",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);

        migrationBuilder.AddForeignKey(
            name: "FK_Persons_Medias_CoverMediaId",
            table: "Persons",
            column: "CoverMediaId",
            principalTable: "Medias",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);

        migrationBuilder.AddForeignKey(
            name: "FK_Persons_Medias_ModelMediaId",
            table: "Persons",
            column: "ModelMediaId",
            principalTable: "Medias",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Persons_Clients_LinkedClientId",
            table: "Persons");

        migrationBuilder.DropForeignKey(
            name: "FK_Persons_Medias_CoverMediaId",
            table: "Persons");

        migrationBuilder.DropForeignKey(
            name: "FK_Persons_Medias_ModelMediaId",
            table: "Persons");

        migrationBuilder.DropIndex(
            name: "IX_Persons_CoverMediaId",
            table: "Persons");

        migrationBuilder.DropIndex(
            name: "IX_Persons_LinkedClientId",
            table: "Persons");

        migrationBuilder.DropIndex(
            name: "IX_Persons_ModelMediaId",
            table: "Persons");

        migrationBuilder.DropIndex(
            name: "IX_MusicContributors_PersonId_MusicId",
            table: "MusicContributors");

        migrationBuilder.DropColumn(
            name: "CoverMediaId",
            table: "Persons");

        migrationBuilder.DropColumn(
            name: "LinkedClientId",
            table: "Persons");

        migrationBuilder.DropColumn(
            name: "ModelMediaId",
            table: "Persons");

        migrationBuilder.CreateIndex(
            name: "IX_MusicContributors_PersonId",
            table: "MusicContributors",
            column: "PersonId");
    }
}

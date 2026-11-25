using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mizon.Database.Migrations;

/// <inheritdoc />
public partial class _20261125180141_AddClientSessionConfirmation : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<bool>(
            name: "IsConfirmationPending",
            table: "ClientSessions",
            type: "bit",
            nullable: false,
            defaultValue: false);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "IsConfirmationPending",
            table: "ClientSessions");
    }
}

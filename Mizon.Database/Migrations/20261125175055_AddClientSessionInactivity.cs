using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mizon.Database.Migrations;

/// <inheritdoc />
public partial class _20261125175055_AddClientSessionInactivity : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropIndex(
            name: "IX_ClientSessions_ClientId",
            table: "ClientSessions");

        migrationBuilder.AddColumn<int>(
            name: "ClientSessionInactivityDays",
            table: "Clients",
            type: "int",
            nullable: true);

        migrationBuilder.CreateIndex(
            name: "IX_ClientSessions_ClientId_LogoutDateTime_LastSeenDateTime",
            table: "ClientSessions",
            columns: new[] { "ClientId", "LogoutDateTime", "LastSeenDateTime" });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropIndex(
            name: "IX_ClientSessions_ClientId_LogoutDateTime_LastSeenDateTime",
            table: "ClientSessions");

        migrationBuilder.DropColumn(
            name: "ClientSessionInactivityDays",
            table: "Clients");

        migrationBuilder.CreateIndex(
            name: "IX_ClientSessions_ClientId",
            table: "ClientSessions",
            column: "ClientId");
    }
}

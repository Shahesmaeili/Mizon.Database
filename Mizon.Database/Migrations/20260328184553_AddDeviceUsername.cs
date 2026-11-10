using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mizon.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddDeviceUsername : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeviceTitle",
                table: "ClientSessions",
                newName: "DeviceUsername");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeviceUsername",
                table: "ClientSessions",
                newName: "DeviceTitle");
        }
    }
}

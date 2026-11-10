using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mizon.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddClientFollowingAndPrivacyHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "ClientPrivacyTypeId",
                table: "Clients",
                type: "tinyint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ClientFollowActionTypes",
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
                    table.PrimaryKey("PK_ClientFollowActionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientFollowStatusTypes",
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
                    table.PrimaryKey("PK_ClientFollowStatusTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientPrivacyTypes",
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
                    table.PrimaryKey("PK_ClientPrivacyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientFollows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FollowerClientId = table.Column<int>(type: "int", nullable: false),
                    FollowedClientId = table.Column<int>(type: "int", nullable: true),
                    FollowedPersonId = table.Column<int>(type: "int", nullable: true),
                    ClientFollowStatusTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    RequestDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    AcceptDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    FollowDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EndDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientFollows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientFollows_ClientFollowStatusTypes_ClientFollowStatusTypeId",
                        column: x => x.ClientFollowStatusTypeId,
                        principalTable: "ClientFollowStatusTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientFollows_Clients_FollowedClientId",
                        column: x => x.FollowedClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientFollows_Clients_FollowerClientId",
                        column: x => x.FollowerClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientFollows_Persons_FollowedPersonId",
                        column: x => x.FollowedPersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientPrivacyHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    PreviousClientPrivacyTypeId = table.Column<byte>(type: "tinyint", nullable: true),
                    ClientPrivacyTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    ActorClientId = table.Column<int>(type: "int", nullable: true),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientPrivacyHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientPrivacyHistories_ClientPrivacyTypes_ClientPrivacyTypeId",
                        column: x => x.ClientPrivacyTypeId,
                        principalTable: "ClientPrivacyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientPrivacyHistories_ClientPrivacyTypes_PreviousClientPrivacyTypeId",
                        column: x => x.PreviousClientPrivacyTypeId,
                        principalTable: "ClientPrivacyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientPrivacyHistories_Clients_ActorClientId",
                        column: x => x.ActorClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientPrivacyHistories_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientFollowHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientFollowId = table.Column<int>(type: "int", nullable: false),
                    ClientFollowActionTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    PreviousClientFollowStatusTypeId = table.Column<byte>(type: "tinyint", nullable: true),
                    ClientFollowStatusTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    ActorClientId = table.Column<int>(type: "int", nullable: true),
                    CreateDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientFollowHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientFollowHistories_ClientFollowActionTypes_ClientFollowActionTypeId",
                        column: x => x.ClientFollowActionTypeId,
                        principalTable: "ClientFollowActionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientFollowHistories_ClientFollowStatusTypes_ClientFollowStatusTypeId",
                        column: x => x.ClientFollowStatusTypeId,
                        principalTable: "ClientFollowStatusTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientFollowHistories_ClientFollowStatusTypes_PreviousClientFollowStatusTypeId",
                        column: x => x.PreviousClientFollowStatusTypeId,
                        principalTable: "ClientFollowStatusTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientFollowHistories_ClientFollows_ClientFollowId",
                        column: x => x.ClientFollowId,
                        principalTable: "ClientFollows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientFollowHistories_Clients_ActorClientId",
                        column: x => x.ActorClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClientPrivacyTypeId",
                table: "Clients",
                column: "ClientPrivacyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientFollowActionTypes_PublicId",
                table: "ClientFollowActionTypes",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientFollowHistories_ActorClientId",
                table: "ClientFollowHistories",
                column: "ActorClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientFollowHistories_ClientFollowActionTypeId",
                table: "ClientFollowHistories",
                column: "ClientFollowActionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientFollowHistories_ClientFollowId_Id",
                table: "ClientFollowHistories",
                columns: new[] { "ClientFollowId", "Id" });

            migrationBuilder.CreateIndex(
                name: "IX_ClientFollowHistories_ClientFollowStatusTypeId",
                table: "ClientFollowHistories",
                column: "ClientFollowStatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientFollowHistories_PreviousClientFollowStatusTypeId",
                table: "ClientFollowHistories",
                column: "PreviousClientFollowStatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientFollows_ClientFollowStatusTypeId",
                table: "ClientFollows",
                column: "ClientFollowStatusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientFollows_FollowedClientId_ClientFollowStatusTypeId_Id",
                table: "ClientFollows",
                columns: new[] { "FollowedClientId", "ClientFollowStatusTypeId", "Id" },
                filter: "[FollowedClientId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ClientFollows_FollowedPersonId_ClientFollowStatusTypeId_Id",
                table: "ClientFollows",
                columns: new[] { "FollowedPersonId", "ClientFollowStatusTypeId", "Id" },
                filter: "[FollowedPersonId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ClientFollows_FollowerClientId_ClientFollowStatusTypeId_Id",
                table: "ClientFollows",
                columns: new[] { "FollowerClientId", "ClientFollowStatusTypeId", "Id" });

            migrationBuilder.CreateIndex(
                name: "IX_ClientFollows_FollowerClientId_FollowedClientId",
                table: "ClientFollows",
                columns: new[] { "FollowerClientId", "FollowedClientId" },
                unique: true,
                filter: "[FollowedClientId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ClientFollows_FollowerClientId_FollowedPersonId",
                table: "ClientFollows",
                columns: new[] { "FollowerClientId", "FollowedPersonId" },
                unique: true,
                filter: "[FollowedPersonId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ClientFollows_PublicId",
                table: "ClientFollows",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientFollowStatusTypes_PublicId",
                table: "ClientFollowStatusTypes",
                column: "PublicId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientPrivacyHistories_ActorClientId",
                table: "ClientPrivacyHistories",
                column: "ActorClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientPrivacyHistories_ClientId_Id",
                table: "ClientPrivacyHistories",
                columns: new[] { "ClientId", "Id" });

            migrationBuilder.CreateIndex(
                name: "IX_ClientPrivacyHistories_ClientPrivacyTypeId",
                table: "ClientPrivacyHistories",
                column: "ClientPrivacyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientPrivacyHistories_PreviousClientPrivacyTypeId",
                table: "ClientPrivacyHistories",
                column: "PreviousClientPrivacyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientPrivacyTypes_PublicId",
                table: "ClientPrivacyTypes",
                column: "PublicId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_ClientPrivacyTypes_ClientPrivacyTypeId",
                table: "Clients",
                column: "ClientPrivacyTypeId",
                principalTable: "ClientPrivacyTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_ClientPrivacyTypes_ClientPrivacyTypeId",
                table: "Clients");

            migrationBuilder.DropTable(
                name: "ClientFollowHistories");

            migrationBuilder.DropTable(
                name: "ClientPrivacyHistories");

            migrationBuilder.DropTable(
                name: "ClientFollowActionTypes");

            migrationBuilder.DropTable(
                name: "ClientFollows");

            migrationBuilder.DropTable(
                name: "ClientPrivacyTypes");

            migrationBuilder.DropTable(
                name: "ClientFollowStatusTypes");

            migrationBuilder.DropIndex(
                name: "IX_Clients_ClientPrivacyTypeId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ClientPrivacyTypeId",
                table: "Clients");
        }
    }
}

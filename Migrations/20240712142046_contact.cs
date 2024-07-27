using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstate.Migrations
{
    /// <inheritdoc />
    public partial class contact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PrivateSeller",
                table: "PrivateSeller");

            migrationBuilder.RenameTable(
                name: "PrivateSeller",
                newName: "PrivateSellers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrivateSellers",
                table: "PrivateSellers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    roleid = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PrivateSellers",
                table: "PrivateSellers");

            migrationBuilder.RenameTable(
                name: "PrivateSellers",
                newName: "PrivateSeller");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrivateSeller",
                table: "PrivateSeller",
                column: "Id");
        }
    }
}

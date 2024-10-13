using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeichuHackaThon2024Model.Migrations
{
    /// <inheritdoc />
    public partial class Add_Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Distance",
                table: "Paths");

            migrationBuilder.RenameColumn(
                name: "TransportCompEnumType",
                table: "Paths",
                newName: "TransportType");

            migrationBuilder.RenameColumn(
                name: "AttractionsEnumType",
                table: "Paths",
                newName: "RouteId");

            migrationBuilder.RenameColumn(
                name: "Sysno",
                table: "Paths",
                newName: "SysId");

            migrationBuilder.AddColumn<string>(
                name: "EndPoint",
                table: "Paths",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StartPoint",
                table: "Paths",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndPoint",
                table: "Paths");

            migrationBuilder.DropColumn(
                name: "StartPoint",
                table: "Paths");

            migrationBuilder.RenameColumn(
                name: "TransportType",
                table: "Paths",
                newName: "TransportCompEnumType");

            migrationBuilder.RenameColumn(
                name: "RouteId",
                table: "Paths",
                newName: "AttractionsEnumType");

            migrationBuilder.RenameColumn(
                name: "SysId",
                table: "Paths",
                newName: "Sysno");

            migrationBuilder.AddColumn<float>(
                name: "Distance",
                table: "Paths",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}

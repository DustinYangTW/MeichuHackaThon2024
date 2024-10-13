using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeichuHackaThon2024Model.Migrations
{
    /// <inheritdoc />
    public partial class Add_Path_Detail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                newName: "PathId");

            migrationBuilder.RenameColumn(
                name: "RouteId",
                table: "Paths",
                newName: "PathDetailId");

            migrationBuilder.RenameColumn(
                name: "CrowdingEnumType",
                table: "Paths",
                newName: "Crowding");

            migrationBuilder.AlterColumn<double>(
                name: "CostTime",
                table: "Paths",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "Paths",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Paths",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Destination",
                table: "Paths");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Paths");

            migrationBuilder.RenameColumn(
                name: "PathId",
                table: "Paths",
                newName: "TransportType");

            migrationBuilder.RenameColumn(
                name: "PathDetailId",
                table: "Paths",
                newName: "RouteId");

            migrationBuilder.RenameColumn(
                name: "Crowding",
                table: "Paths",
                newName: "CrowdingEnumType");

            migrationBuilder.AlterColumn<float>(
                name: "CostTime",
                table: "Paths",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

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
    }
}

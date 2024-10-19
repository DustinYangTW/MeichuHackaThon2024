using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeichuHackaThon2024Model.Migrations
{
    /// <inheritdoc />
    public partial class Create_FK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EndPointId",
                table: "Paths",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StartPointId",
                table: "Paths",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TransportationId",
                table: "Paths",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PointInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transportations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Paths_EndPointId",
                table: "Paths",
                column: "EndPointId");

            migrationBuilder.CreateIndex(
                name: "IX_Paths_StartPointId",
                table: "Paths",
                column: "StartPointId");

            migrationBuilder.CreateIndex(
                name: "IX_Paths_TransportationId",
                table: "Paths",
                column: "TransportationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Paths_PointInfos_EndPointId",
                table: "Paths",
                column: "EndPointId",
                principalTable: "PointInfos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Paths_PointInfos_StartPointId",
                table: "Paths",
                column: "StartPointId",
                principalTable: "PointInfos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Paths_Transportations_TransportationId",
                table: "Paths",
                column: "TransportationId",
                principalTable: "Transportations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paths_PointInfos_EndPointId",
                table: "Paths");

            migrationBuilder.DropForeignKey(
                name: "FK_Paths_PointInfos_StartPointId",
                table: "Paths");

            migrationBuilder.DropForeignKey(
                name: "FK_Paths_Transportations_TransportationId",
                table: "Paths");

            migrationBuilder.DropTable(
                name: "PointInfos");

            migrationBuilder.DropTable(
                name: "Transportations");

            migrationBuilder.DropIndex(
                name: "IX_Paths_EndPointId",
                table: "Paths");

            migrationBuilder.DropIndex(
                name: "IX_Paths_StartPointId",
                table: "Paths");

            migrationBuilder.DropIndex(
                name: "IX_Paths_TransportationId",
                table: "Paths");

            migrationBuilder.DropColumn(
                name: "EndPointId",
                table: "Paths");

            migrationBuilder.DropColumn(
                name: "StartPointId",
                table: "Paths");

            migrationBuilder.DropColumn(
                name: "TransportationId",
                table: "Paths");
        }
    }
}

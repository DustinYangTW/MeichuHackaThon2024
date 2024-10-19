using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeichuHackaThon2024Model.Migrations
{
    /// <inheritdoc />
    public partial class add_Table_Path : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PathDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PathIds = table.Column<int>(type: "int", nullable: false),
                    PathDetailId = table.Column<int>(type: "int", nullable: false),
                    StartPointId = table.Column<int>(type: "int", nullable: false),
                    EndPointId = table.Column<int>(type: "int", nullable: false),
                    CostTime = table.Column<double>(type: "float", nullable: false),
                    TransportationId = table.Column<int>(type: "int", nullable: false),
                    Crowding = table.Column<int>(type: "int", nullable: false),
                    PathId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PathDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PathDetails_Paths_PathId",
                        column: x => x.PathId,
                        principalTable: "Paths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PathDetails_PointInfos_EndPointId",
                        column: x => x.EndPointId,
                        principalTable: "PointInfos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PathDetails_PointInfos_StartPointId",
                        column: x => x.StartPointId,
                        principalTable: "PointInfos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PathDetails_Transportations_TransportationId",
                        column: x => x.TransportationId,
                        principalTable: "Transportations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PathDetails_EndPointId",
                table: "PathDetails",
                column: "EndPointId");

            migrationBuilder.CreateIndex(
                name: "IX_PathDetails_PathId",
                table: "PathDetails",
                column: "PathId");

            migrationBuilder.CreateIndex(
                name: "IX_PathDetails_StartPointId",
                table: "PathDetails",
                column: "StartPointId");

            migrationBuilder.CreateIndex(
                name: "IX_PathDetails_TransportationId",
                table: "PathDetails",
                column: "TransportationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PathDetails");
        }
    }
}

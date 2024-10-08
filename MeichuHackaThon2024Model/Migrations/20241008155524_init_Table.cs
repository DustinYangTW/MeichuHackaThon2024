using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeichuHackaThon2024Model.Migrations
{
    /// <inheritdoc />
    public partial class init_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crowdings",
                columns: table => new
                {
                    Sysno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrowdingName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crowdings", x => x.Sysno);
                });

            migrationBuilder.CreateTable(
                name: "Filters",
                columns: table => new
                {
                    Sysno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilterName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filters", x => x.Sysno);
                });

            migrationBuilder.CreateTable(
                name: "TransportComps",
                columns: table => new
                {
                    Sysno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransportCompName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportComps", x => x.Sysno);
                });

            migrationBuilder.CreateTable(
                name: "Paths",
                columns: table => new
                {
                    Sysno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CostTime = table.Column<float>(type: "real", nullable: false),
                    Distance = table.Column<float>(type: "real", nullable: false),
                    CrowdingSysno = table.Column<int>(type: "int", nullable: false),
                    FilterSysno = table.Column<int>(type: "int", nullable: false),
                    TransportCompSysno = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paths", x => x.Sysno);
                    table.ForeignKey(
                        name: "FK_Paths_Crowdings_CrowdingSysno",
                        column: x => x.CrowdingSysno,
                        principalTable: "Crowdings",
                        principalColumn: "Sysno",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paths_Filters_FilterSysno",
                        column: x => x.FilterSysno,
                        principalTable: "Filters",
                        principalColumn: "Sysno",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paths_TransportComps_TransportCompSysno",
                        column: x => x.TransportCompSysno,
                        principalTable: "TransportComps",
                        principalColumn: "Sysno",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Paths_CrowdingSysno",
                table: "Paths",
                column: "CrowdingSysno");

            migrationBuilder.CreateIndex(
                name: "IX_Paths_FilterSysno",
                table: "Paths",
                column: "FilterSysno");

            migrationBuilder.CreateIndex(
                name: "IX_Paths_TransportCompSysno",
                table: "Paths",
                column: "TransportCompSysno");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paths");

            migrationBuilder.DropTable(
                name: "Crowdings");

            migrationBuilder.DropTable(
                name: "Filters");

            migrationBuilder.DropTable(
                name: "TransportComps");
        }
    }
}

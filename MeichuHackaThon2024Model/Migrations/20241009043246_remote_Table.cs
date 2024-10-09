using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeichuHackaThon2024Model.Migrations
{
    /// <inheritdoc />
    public partial class remote_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paths_Crowdings_CrowdingSysno",
                table: "Paths");

            migrationBuilder.DropForeignKey(
                name: "FK_Paths_Filters_FilterSysno",
                table: "Paths");

            migrationBuilder.DropForeignKey(
                name: "FK_Paths_TransportComps_TransportCompSysno",
                table: "Paths");

            migrationBuilder.DropTable(
                name: "Crowdings");

            migrationBuilder.DropTable(
                name: "Filters");

            migrationBuilder.DropTable(
                name: "TransportComps");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Paths_CrowdingSysno",
                table: "Paths");

            migrationBuilder.DropIndex(
                name: "IX_Paths_FilterSysno",
                table: "Paths");

            migrationBuilder.DropIndex(
                name: "IX_Paths_TransportCompSysno",
                table: "Paths");

            migrationBuilder.RenameColumn(
                name: "TransportCompSysno",
                table: "Paths",
                newName: "TransportCompEnumType");

            migrationBuilder.RenameColumn(
                name: "FilterSysno",
                table: "Paths",
                newName: "CrowdingEnumType");

            migrationBuilder.RenameColumn(
                name: "CrowdingSysno",
                table: "Paths",
                newName: "AttractionsEnumType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TransportCompEnumType",
                table: "Paths",
                newName: "TransportCompSysno");

            migrationBuilder.RenameColumn(
                name: "CrowdingEnumType",
                table: "Paths",
                newName: "FilterSysno");

            migrationBuilder.RenameColumn(
                name: "AttractionsEnumType",
                table: "Paths",
                newName: "CrowdingSysno");

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
                name: "Users",
                columns: table => new
                {
                    Sysno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ac_Number = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CrTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Pw_Number = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    TxTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Sysno);
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

            migrationBuilder.AddForeignKey(
                name: "FK_Paths_Crowdings_CrowdingSysno",
                table: "Paths",
                column: "CrowdingSysno",
                principalTable: "Crowdings",
                principalColumn: "Sysno",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Paths_Filters_FilterSysno",
                table: "Paths",
                column: "FilterSysno",
                principalTable: "Filters",
                principalColumn: "Sysno",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Paths_TransportComps_TransportCompSysno",
                table: "Paths",
                column: "TransportCompSysno",
                principalTable: "TransportComps",
                principalColumn: "Sysno",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeichuHackaThon2024Model.Migrations
{
    /// <inheritdoc />
    public partial class Create_New_Table_WaterSaterStation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WaterStations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    名稱 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    縣市別 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    地址 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    管理單位聯絡人 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    開放時間 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    水溫 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    位置 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    樓層 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    廠牌機型 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    連絡電話 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    分機號碼 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    飲水台數 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterStations", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WaterStations");
        }
    }
}

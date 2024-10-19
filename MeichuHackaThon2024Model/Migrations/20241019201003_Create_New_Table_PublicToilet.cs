using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeichuHackaThon2024Model.Migrations
{
    /// <inheritdoc />
    public partial class Create_New_Table_PublicToilet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PublicToilets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    編號 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    公廁名稱 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    縣市別代碼 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    行政區代碼 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    郵遞區號 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    男廁小便斗數量 = table.Column<int>(type: "int", nullable: false),
                    男廁馬桶坐式數量 = table.Column<int>(type: "int", nullable: false),
                    男廁馬桶蹲式數量 = table.Column<int>(type: "int", nullable: false),
                    女廁馬桶坐式數量 = table.Column<int>(type: "int", nullable: false),
                    女廁馬桶蹲式數量 = table.Column<int>(type: "int", nullable: false),
                    殘障廁所數量 = table.Column<int>(type: "int", nullable: false),
                    育嬰台數量 = table.Column<int>(type: "int", nullable: false),
                    兒童馬桶數量 = table.Column<int>(type: "int", nullable: false),
                    兒童座椅數量 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicToilets", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PublicToilets");
        }
    }
}

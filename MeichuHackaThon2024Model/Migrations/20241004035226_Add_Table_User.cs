using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeichuHackaThon2024Model.Migrations
{
    /// <inheritdoc />
    public partial class Add_Table_User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Sysno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ac_Number = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Pw_Number = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CrTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TxTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Sysno);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

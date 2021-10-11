using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ActEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Act",
                columns: table => new
                {
                    ActID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Act_Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Act_Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Act_Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Act_userID = table.Column<long>(type: "bigint", nullable: false),
                    Act_userName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Act", x => x.ActID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Act");
        }
    }
}

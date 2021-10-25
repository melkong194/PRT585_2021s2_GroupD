using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class actUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Act_lat",
                table: "Act",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Act_lng",
                table: "Act",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Act_lat",
                table: "Act");

            migrationBuilder.DropColumn(
                name: "Act_lng",
                table: "Act");
        }
    }
}

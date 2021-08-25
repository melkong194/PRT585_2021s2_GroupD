using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieAdmin.Migrations
{
    public partial class one : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Category_CategoryID",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Movie_CategoryID",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Movie");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Movie");

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Movie",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movie_CategoryID",
                table: "Movie",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Category_CategoryID",
                table: "Movie",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskB.Migrations
{
    public partial class three : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Category_CategoryId",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Movie_CategoryId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "test",
                table: "Movie");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Movie",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Movie");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Movie",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "test",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movie_CategoryId",
                table: "Movie",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Category_CategoryId",
                table: "Movie",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

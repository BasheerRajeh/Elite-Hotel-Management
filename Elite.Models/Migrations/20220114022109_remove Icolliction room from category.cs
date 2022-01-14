using Microsoft.EntityFrameworkCore.Migrations;

namespace Elite.AppDbContext.Migrations
{
    public partial class removeIcollictionroomfromcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_Category",
                table: "Room");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Category_CategoryId",
                table: "Room",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_Category_CategoryId",
                table: "Room");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Category",
                table: "Room",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

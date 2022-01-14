using Microsoft.EntityFrameworkCore.Migrations;

namespace Elite.AppDbContext.Migrations
{
    public partial class removeIcollictionservicecatfromcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceCat_Category",
                table: "ServiceCat");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceCat_Category_CategoryId",
                table: "ServiceCat",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceCat_Category_CategoryId",
                table: "ServiceCat");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceCat_Category",
                table: "ServiceCat",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

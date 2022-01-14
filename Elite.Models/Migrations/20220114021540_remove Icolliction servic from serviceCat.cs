using Microsoft.EntityFrameworkCore.Migrations;

namespace Elite.AppDbContext.Migrations
{
    public partial class removeIcollictionservicfromserviceCat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpecialService_ServiceCat",
                table: "SpecialService");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialService_ServiceCat_ServiceCatId",
                table: "SpecialService",
                column: "ServiceCatId",
                principalTable: "ServiceCat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpecialService_ServiceCat_ServiceCatId",
                table: "SpecialService");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialService_ServiceCat",
                table: "SpecialService",
                column: "ServiceCatId",
                principalTable: "ServiceCat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

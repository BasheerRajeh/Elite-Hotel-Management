using Microsoft.EntityFrameworkCore.Migrations;

namespace Elite.AppDbContext.Migrations
{
    public partial class fixingrelationshipbetweenserviceandserviceCat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceCat_Service",
                table: "ServiceCat");

            migrationBuilder.DropIndex(
                name: "IX_ServiceCat_ServiceId",
                table: "ServiceCat");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "ServiceCat");

            migrationBuilder.AddColumn<int>(
                name: "ServiceCatId",
                table: "Service",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Service_ServiceCatId",
                table: "Service",
                column: "ServiceCatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_ServiceCat_ServiceCatId",
                table: "Service",
                column: "ServiceCatId",
                principalTable: "ServiceCat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_ServiceCat_ServiceCatId",
                table: "Service");

            migrationBuilder.DropIndex(
                name: "IX_Service_ServiceCatId",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "ServiceCatId",
                table: "Service");

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "ServiceCat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCat_ServiceId",
                table: "ServiceCat",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceCat_Service",
                table: "ServiceCat",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

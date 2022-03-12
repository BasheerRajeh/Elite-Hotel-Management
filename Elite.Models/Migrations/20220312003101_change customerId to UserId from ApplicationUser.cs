using Microsoft.EntityFrameworkCore.Migrations;

namespace Elite.AppDbContext.Migrations
{
    public partial class changecustomerIdtoUserIdfromApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Reservation");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Reservation",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_UserId",
                table: "Reservation",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_AspNetUsers_UserId",
                table: "Reservation",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_AspNetUsers_UserId",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_UserId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Reservation");

            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "Reservation",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");
        }
    }
}

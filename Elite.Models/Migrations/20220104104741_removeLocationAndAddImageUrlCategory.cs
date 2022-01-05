using Microsoft.EntityFrameworkCore.Migrations;

namespace Elite.AppDbContext.Migrations
{
    public partial class removeLocationAndAddImageUrlCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotel_Location",
                table: "Hotel");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "RoomImage");

            migrationBuilder.DropIndex(
                name: "IX_Hotel_LocationId",
                table: "Hotel");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Hotel");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Service",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Room",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Hotel",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Hotel",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Category",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Hotel");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Category");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Hotel",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Hotel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(12, 9)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(12, 9)", nullable: false),
                    SoftDel = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    SoftDel = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomImage_Room",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_LocationId",
                table: "Hotel",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomImage_RoomId",
                table: "RoomImage",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotel_Location",
                table: "Hotel",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Meeter.Migrations
{
    public partial class Location : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LocationId",
                table: "GroupMembers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Lat = table.Column<float>(nullable: false),
                    Lng = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LocationId",
                table: "AspNetUsers",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Location_LocationId",
                table: "AspNetUsers",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Location_LocationId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_LocationId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "GroupMembers");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "AspNetUsers");
        }
    }
}

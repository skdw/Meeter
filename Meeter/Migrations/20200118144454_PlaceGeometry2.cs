using Microsoft.EntityFrameworkCore.Migrations;

namespace Meeter.Migrations
{
    public partial class PlaceGeometry2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Viewport_Locations_NorthEastId1",
                table: "Viewport");

            migrationBuilder.DropForeignKey(
                name: "FK_Viewport_Locations_SouthWestId1",
                table: "Viewport");

            migrationBuilder.DropIndex(
                name: "IX_Viewport_NorthEastId1",
                table: "Viewport");

            migrationBuilder.DropIndex(
                name: "IX_Viewport_SouthWestId1",
                table: "Viewport");

            migrationBuilder.DropColumn(
                name: "NorthEastId1",
                table: "Viewport");

            migrationBuilder.DropColumn(
                name: "SouthWestId1",
                table: "Viewport");

            migrationBuilder.AlterColumn<string>(
                name: "SouthWestId",
                table: "Viewport",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "NorthEastId",
                table: "Viewport",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Viewport_NorthEastId",
                table: "Viewport",
                column: "NorthEastId");

            migrationBuilder.CreateIndex(
                name: "IX_Viewport_SouthWestId",
                table: "Viewport",
                column: "SouthWestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Viewport_Locations_NorthEastId",
                table: "Viewport",
                column: "NorthEastId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Viewport_Locations_SouthWestId",
                table: "Viewport",
                column: "SouthWestId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Viewport_Locations_NorthEastId",
                table: "Viewport");

            migrationBuilder.DropForeignKey(
                name: "FK_Viewport_Locations_SouthWestId",
                table: "Viewport");

            migrationBuilder.DropIndex(
                name: "IX_Viewport_NorthEastId",
                table: "Viewport");

            migrationBuilder.DropIndex(
                name: "IX_Viewport_SouthWestId",
                table: "Viewport");

            migrationBuilder.AlterColumn<int>(
                name: "SouthWestId",
                table: "Viewport",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NorthEastId",
                table: "Viewport",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NorthEastId1",
                table: "Viewport",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SouthWestId1",
                table: "Viewport",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Viewport_NorthEastId1",
                table: "Viewport",
                column: "NorthEastId1");

            migrationBuilder.CreateIndex(
                name: "IX_Viewport_SouthWestId1",
                table: "Viewport",
                column: "SouthWestId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Viewport_Locations_NorthEastId1",
                table: "Viewport",
                column: "NorthEastId1",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Viewport_Locations_SouthWestId1",
                table: "Viewport",
                column: "SouthWestId1",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

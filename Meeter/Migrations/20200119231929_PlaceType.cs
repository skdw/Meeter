using Microsoft.EntityFrameworkCore.Migrations;

namespace Meeter.Migrations
{
    public partial class PlaceType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPreferences_PlaceTypes_PlaceTypeId",
                table: "UserPreferences");

            migrationBuilder.RenameColumn(
                name: "PlaceTypeId",
                table: "UserPreferences",
                newName: "TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_UserPreferences_PlaceTypeId",
                table: "UserPreferences",
                newName: "IX_UserPreferences_TypeId");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "PlaceTypes",
                newName: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPreferences_PlaceTypes_TypeId",
                table: "UserPreferences",
                column: "TypeId",
                principalTable: "PlaceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPreferences_PlaceTypes_TypeId",
                table: "UserPreferences");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "UserPreferences",
                newName: "PlaceTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_UserPreferences_TypeId",
                table: "UserPreferences",
                newName: "IX_UserPreferences_PlaceTypeId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "PlaceTypes",
                newName: "Type");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPreferences_PlaceTypes_PlaceTypeId",
                table: "UserPreferences",
                column: "PlaceTypeId",
                principalTable: "PlaceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

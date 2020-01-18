using Microsoft.EntityFrameworkCore.Migrations;

namespace Meeter.Migrations
{
    public partial class PlaceTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlaceType_Places_PlaceId",
                table: "PlaceType");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPreferences_PlaceType_PlaceTypeId",
                table: "UserPreferences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlaceType",
                table: "PlaceType");

            migrationBuilder.RenameTable(
                name: "PlaceType",
                newName: "PlaceTypes");

            migrationBuilder.RenameIndex(
                name: "IX_PlaceType_PlaceId",
                table: "PlaceTypes",
                newName: "IX_PlaceTypes_PlaceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlaceTypes",
                table: "PlaceTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlaceTypes_Places_PlaceId",
                table: "PlaceTypes",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPreferences_PlaceTypes_PlaceTypeId",
                table: "UserPreferences",
                column: "PlaceTypeId",
                principalTable: "PlaceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlaceTypes_Places_PlaceId",
                table: "PlaceTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPreferences_PlaceTypes_PlaceTypeId",
                table: "UserPreferences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlaceTypes",
                table: "PlaceTypes");

            migrationBuilder.RenameTable(
                name: "PlaceTypes",
                newName: "PlaceType");

            migrationBuilder.RenameIndex(
                name: "IX_PlaceTypes_PlaceId",
                table: "PlaceType",
                newName: "IX_PlaceType_PlaceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlaceType",
                table: "PlaceType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlaceType_Places_PlaceId",
                table: "PlaceType",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPreferences_PlaceType_PlaceTypeId",
                table: "UserPreferences",
                column: "PlaceTypeId",
                principalTable: "PlaceType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Meeter.Migrations
{
    public partial class PlaceString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlaceTypes_Places_PlaceId1",
                table: "PlaceTypes");

            migrationBuilder.DropIndex(
                name: "IX_PlaceTypes_PlaceId1",
                table: "PlaceTypes");

            migrationBuilder.DropColumn(
                name: "PlaceId1",
                table: "PlaceTypes");

            migrationBuilder.AlterColumn<string>(
                name: "PlaceId",
                table: "PlaceTypes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_PlaceTypes_PlaceId",
                table: "PlaceTypes",
                column: "PlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlaceTypes_Places_PlaceId",
                table: "PlaceTypes",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlaceTypes_Places_PlaceId",
                table: "PlaceTypes");

            migrationBuilder.DropIndex(
                name: "IX_PlaceTypes_PlaceId",
                table: "PlaceTypes");

            migrationBuilder.AlterColumn<int>(
                name: "PlaceId",
                table: "PlaceTypes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlaceId1",
                table: "PlaceTypes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlaceTypes_PlaceId1",
                table: "PlaceTypes",
                column: "PlaceId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PlaceTypes_Places_PlaceId1",
                table: "PlaceTypes",
                column: "PlaceId1",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

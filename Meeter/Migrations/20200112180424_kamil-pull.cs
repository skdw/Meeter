using Microsoft.EntityFrameworkCore.Migrations;

namespace Meeter.Migrations
{
    public partial class kamilpull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_AspNetUsers_Creatorid",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "CreatorName",
                table: "Groups");

            migrationBuilder.RenameColumn(
                name: "Creatorid",
                table: "Groups",
                newName: "CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_Groups_Creatorid",
                table: "Groups",
                newName: "IX_Groups_CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_AspNetUsers_CreatorId",
                table: "Groups",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_AspNetUsers_CreatorId",
                table: "Groups");

            migrationBuilder.RenameColumn(
                name: "CreatorId",
                table: "Groups",
                newName: "Creatorid");

            migrationBuilder.RenameIndex(
                name: "IX_Groups_CreatorId",
                table: "Groups",
                newName: "IX_Groups_Creatorid");

            migrationBuilder.AddColumn<string>(
                name: "CreatorName",
                table: "Groups",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_AspNetUsers_Creatorid",
                table: "Groups",
                column: "Creatorid",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

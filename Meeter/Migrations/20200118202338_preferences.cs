using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Meeter.Migrations
{
    public partial class preferences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Preference",
                table: "UserPreferences");

            migrationBuilder.AddColumn<int>(
                name: "PreferenceID",
                table: "UserPreferences",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Preference",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    preference = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preference", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPreferences_PreferenceID",
                table: "UserPreferences",
                column: "PreferenceID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPreferences_Preference_PreferenceID",
                table: "UserPreferences",
                column: "PreferenceID",
                principalTable: "Preference",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPreferences_Preference_PreferenceID",
                table: "UserPreferences");

            migrationBuilder.DropTable(
                name: "Preference");

            migrationBuilder.DropIndex(
                name: "IX_UserPreferences_PreferenceID",
                table: "UserPreferences");

            migrationBuilder.DropColumn(
                name: "PreferenceID",
                table: "UserPreferences");

            migrationBuilder.AddColumn<string>(
                name: "Preference",
                table: "UserPreferences",
                nullable: true);
        }
    }
}

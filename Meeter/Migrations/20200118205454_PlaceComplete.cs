using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Meeter.Migrations
{
    public partial class PlaceComplete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_PlaceGeometry_GeometryId",
                table: "Places");

            migrationBuilder.DropForeignKey(
                name: "FK_Places_PlaceOpeningHours_OpeningHoursId",
                table: "Places");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPreferences_Preference_PreferenceID",
                table: "UserPreferences");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPreferences_AspNetUsers_Userid",
                table: "UserPreferences");

            migrationBuilder.DropTable(
                name: "PlaceGeometry");

            migrationBuilder.DropTable(
                name: "PlaceOpeningHours");

            migrationBuilder.DropTable(
                name: "Preference");

            migrationBuilder.DropTable(
                name: "Viewport");

            migrationBuilder.DropIndex(
                name: "IX_Places_GeometryId",
                table: "Places");

            migrationBuilder.DropIndex(
                name: "IX_Places_OpeningHoursId",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "GeometryId",
                table: "Places");

            migrationBuilder.RenameColumn(
                name: "Userid",
                table: "UserPreferences",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "PreferenceID",
                table: "UserPreferences",
                newName: "PlaceTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_UserPreferences_Userid",
                table: "UserPreferences",
                newName: "IX_UserPreferences_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserPreferences_PreferenceID",
                table: "UserPreferences",
                newName: "IX_UserPreferences_PlaceTypeId");

            migrationBuilder.RenameColumn(
                name: "OpeningHoursId",
                table: "Places",
                newName: "UserRatingsTotal");

            migrationBuilder.AddColumn<string>(
                name: "LocationId",
                table: "Places",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "OpenNow",
                table: "Places",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "PlaceType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true),
                    PlaceId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaceType_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Places_LocationId",
                table: "Places",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceType_PlaceId",
                table: "PlaceType",
                column: "PlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Locations_LocationId",
                table: "Places",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPreferences_PlaceType_PlaceTypeId",
                table: "UserPreferences",
                column: "PlaceTypeId",
                principalTable: "PlaceType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPreferences_AspNetUsers_UserId",
                table: "UserPreferences",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_Locations_LocationId",
                table: "Places");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPreferences_PlaceType_PlaceTypeId",
                table: "UserPreferences");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPreferences_AspNetUsers_UserId",
                table: "UserPreferences");

            migrationBuilder.DropTable(
                name: "PlaceType");

            migrationBuilder.DropIndex(
                name: "IX_Places_LocationId",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "OpenNow",
                table: "Places");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserPreferences",
                newName: "Userid");

            migrationBuilder.RenameColumn(
                name: "PlaceTypeId",
                table: "UserPreferences",
                newName: "PreferenceID");

            migrationBuilder.RenameIndex(
                name: "IX_UserPreferences_UserId",
                table: "UserPreferences",
                newName: "IX_UserPreferences_Userid");

            migrationBuilder.RenameIndex(
                name: "IX_UserPreferences_PlaceTypeId",
                table: "UserPreferences",
                newName: "IX_UserPreferences_PreferenceID");

            migrationBuilder.RenameColumn(
                name: "UserRatingsTotal",
                table: "Places",
                newName: "OpeningHoursId");

            migrationBuilder.AddColumn<int>(
                name: "GeometryId",
                table: "Places",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PlaceOpeningHours",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OpenNow = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceOpeningHours", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Viewport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NorthEastId = table.Column<string>(nullable: true),
                    SouthWestId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viewport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Viewport_Locations_NorthEastId",
                        column: x => x.NorthEastId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Viewport_Locations_SouthWestId",
                        column: x => x.SouthWestId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlaceGeometry",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LocationId = table.Column<string>(nullable: true),
                    ViewportId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceGeometry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaceGeometry_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlaceGeometry_Viewport_ViewportId",
                        column: x => x.ViewportId,
                        principalTable: "Viewport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Places_GeometryId",
                table: "Places",
                column: "GeometryId");

            migrationBuilder.CreateIndex(
                name: "IX_Places_OpeningHoursId",
                table: "Places",
                column: "OpeningHoursId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceGeometry_LocationId",
                table: "PlaceGeometry",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceGeometry_ViewportId",
                table: "PlaceGeometry",
                column: "ViewportId");

            migrationBuilder.CreateIndex(
                name: "IX_Viewport_NorthEastId",
                table: "Viewport",
                column: "NorthEastId");

            migrationBuilder.CreateIndex(
                name: "IX_Viewport_SouthWestId",
                table: "Viewport",
                column: "SouthWestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_PlaceGeometry_GeometryId",
                table: "Places",
                column: "GeometryId",
                principalTable: "PlaceGeometry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Places_PlaceOpeningHours_OpeningHoursId",
                table: "Places",
                column: "OpeningHoursId",
                principalTable: "PlaceOpeningHours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPreferences_Preference_PreferenceID",
                table: "UserPreferences",
                column: "PreferenceID",
                principalTable: "Preference",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPreferences_AspNetUsers_Userid",
                table: "UserPreferences",
                column: "Userid",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

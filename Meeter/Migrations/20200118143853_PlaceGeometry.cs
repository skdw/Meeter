using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Meeter.Migrations
{
    public partial class PlaceGeometry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupMembers_AspNetUsers_Userid",
                table: "GroupMembers");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "GroupMembers");

            migrationBuilder.RenameColumn(
                name: "Userid",
                table: "GroupMembers",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupMembers_Userid",
                table: "GroupMembers",
                newName: "IX_GroupMembers_UserId");

            migrationBuilder.AddColumn<int>(
                name: "GeometryId",
                table: "Places",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OpeningHoursId",
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
                name: "Viewport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NorthEastId = table.Column<int>(nullable: false),
                    NorthEastId1 = table.Column<string>(nullable: true),
                    SouthWestId = table.Column<int>(nullable: false),
                    SouthWestId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viewport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Viewport_Locations_NorthEastId1",
                        column: x => x.NorthEastId1,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Viewport_Locations_SouthWestId1",
                        column: x => x.SouthWestId1,
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
                name: "IX_Viewport_NorthEastId1",
                table: "Viewport",
                column: "NorthEastId1");

            migrationBuilder.CreateIndex(
                name: "IX_Viewport_SouthWestId1",
                table: "Viewport",
                column: "SouthWestId1");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMembers_AspNetUsers_UserId",
                table: "GroupMembers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupMembers_AspNetUsers_UserId",
                table: "GroupMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_Places_PlaceGeometry_GeometryId",
                table: "Places");

            migrationBuilder.DropForeignKey(
                name: "FK_Places_PlaceOpeningHours_OpeningHoursId",
                table: "Places");

            migrationBuilder.DropTable(
                name: "PlaceGeometry");

            migrationBuilder.DropTable(
                name: "PlaceOpeningHours");

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

            migrationBuilder.DropColumn(
                name: "OpeningHoursId",
                table: "Places");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "GroupMembers",
                newName: "Userid");

            migrationBuilder.RenameIndex(
                name: "IX_GroupMembers_UserId",
                table: "GroupMembers",
                newName: "IX_GroupMembers_Userid");

            migrationBuilder.AddColumn<string>(
                name: "LocationId",
                table: "GroupMembers",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMembers_AspNetUsers_Userid",
                table: "GroupMembers",
                column: "Userid",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

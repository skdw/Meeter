using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Meeter.Migrations
{
    public partial class TypesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlaceTypes_Places_PlaceId",
                table: "PlaceTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPreferences_PlaceTypes_TypeId",
                table: "UserPreferences");

            migrationBuilder.DropIndex(
                name: "IX_PlaceTypes_PlaceId",
                table: "PlaceTypes");

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "PlaceTypes",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "PlaceTypes",
                newName: "PlaceId1");

            migrationBuilder.AlterColumn<int>(
                name: "PlaceId",
                table: "PlaceTypes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PlaceId1",
                table: "PlaceTypes",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "PlaceTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    PlaceId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Types_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "Name", "PlaceId" },
                values: new object[,]
                {
                    { 1, "accounting", null },
                    { 79, "physiotherapist", null },
                    { 78, "pharmacy", null },
                    { 77, "pet_store", null },
                    { 76, "parking", null },
                    { 75, "park", null },
                    { 74, "painter", null },
                    { 73, "night_club", null },
                    { 72, "museum", null },
                    { 71, "moving_company", null },
                    { 80, "plumber", null },
                    { 70, "movie_theater", null },
                    { 59, "mosque", null },
                    { 58, "meal_takeaway", null },
                    { 57, "meal_delivery", null },
                    { 56, "lodging", null },
                    { 55, "locksmith", null },
                    { 54, "local_government_office", null },
                    { 53, "liquor_store", null },
                    { 52, "light_rail_station", null },
                    { 51, "library", null },
                    { 60, "movie_rental", null },
                    { 81, "police", null },
                    { 82, "post_office", null },
                    { 83, "primary_school", null },
                    { 104, "university", null },
                    { 103, "travel_agency", null },
                    { 102, "transit_station", null },
                    { 101, "train_station", null },
                    { 100, "tourist_attraction", null },
                    { 99, "taxi_stand", null },
                    { 98, "synagogue", null },
                    { 97, "supermarket", null },
                    { 96, "subway_station", null },
                    { 95, "store", null },
                    { 94, "storage", null },
                    { 93, "stadium", null },
                    { 92, "spa", null },
                    { 91, "shopping_mall", null },
                    { 90, "shoe_store", null },
                    { 89, "secondary_school", null },
                    { 88, "school", null },
                    { 87, "rv_park", null },
                    { 86, "roofing_contractor", null },
                    { 85, "restaurant", null },
                    { 84, "real_estate_agency", null },
                    { 50, "lawyer", null },
                    { 105, "veterinary_care", null },
                    { 49, "laundry", null },
                    { 47, "insurance_agency", null },
                    { 21, "casino", null },
                    { 20, "car_wash", null },
                    { 19, "car_repair", null },
                    { 18, "car_rental", null },
                    { 17, "car_dealer", null },
                    { 16, "campground", null },
                    { 15, "cafe", null },
                    { 14, "bus_station", null },
                    { 13, "bowling_alley", null },
                    { 22, "cemetery", null },
                    { 12, "book_store", null },
                    { 10, "beauty_salon", null },
                    { 9, "bar", null },
                    { 8, "bank", null },
                    { 7, "bakery", null },
                    { 6, "atm", null },
                    { 5, "art_gallery", null },
                    { 4, "aquarium", null },
                    { 3, "amusement_park", null },
                    { 2, "airport", null },
                    { 11, "bicycle_store", null },
                    { 23, "church", null },
                    { 24, "city_hall", null },
                    { 25, "clothing_store", null },
                    { 46, "hospital", null },
                    { 45, "home_goods_store", null },
                    { 44, "hindu_temple", null },
                    { 43, "hardware_store", null },
                    { 42, "hair_care", null },
                    { 41, "gym", null },
                    { 40, "grocery_or_supermarket", null },
                    { 39, "gas_station", null },
                    { 38, "furniture_store", null },
                    { 37, "funeral_home", null },
                    { 36, "florist", null },
                    { 35, "fire_station", null },
                    { 34, "embassy", null },
                    { 33, "electronics_store", null },
                    { 32, "electrician", null },
                    { 31, "drugstore", null },
                    { 30, "doctor", null },
                    { 29, "department_store", null },
                    { 28, "dentist", null },
                    { 27, "courthouse", null },
                    { 26, "convenience_store", null },
                    { 48, "jewelry_store", null },
                    { 106, "zoo", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlaceTypes_PlaceId1",
                table: "PlaceTypes",
                column: "PlaceId1");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceTypes_TypeId",
                table: "PlaceTypes",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Types_PlaceId",
                table: "Types",
                column: "PlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlaceTypes_Places_PlaceId1",
                table: "PlaceTypes",
                column: "PlaceId1",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaceTypes_Types_TypeId",
                table: "PlaceTypes",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPreferences_Types_TypeId",
                table: "UserPreferences",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlaceTypes_Places_PlaceId1",
                table: "PlaceTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaceTypes_Types_TypeId",
                table: "PlaceTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPreferences_Types_TypeId",
                table: "UserPreferences");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropIndex(
                name: "IX_PlaceTypes_PlaceId1",
                table: "PlaceTypes");

            migrationBuilder.DropIndex(
                name: "IX_PlaceTypes_TypeId",
                table: "PlaceTypes");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "PlaceTypes");

            migrationBuilder.RenameColumn(
                name: "PlaceId1",
                table: "PlaceTypes",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "PlaceId",
                table: "PlaceTypes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PlaceTypes",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "PlaceTypes",
                columns: new[] { "Id", "Name", "PlaceId" },
                values: new object[,]
                {
                    { 1, "accounting", null },
                    { 79, "physiotherapist", null },
                    { 78, "pharmacy", null },
                    { 77, "pet_store", null },
                    { 76, "parking", null },
                    { 75, "park", null },
                    { 74, "painter", null },
                    { 73, "night_club", null },
                    { 72, "museum", null },
                    { 71, "moving_company", null },
                    { 80, "plumber", null },
                    { 70, "movie_theater", null },
                    { 59, "mosque", null },
                    { 58, "meal_takeaway", null },
                    { 57, "meal_delivery", null },
                    { 56, "lodging", null },
                    { 55, "locksmith", null },
                    { 54, "local_government_office", null },
                    { 53, "liquor_store", null },
                    { 52, "light_rail_station", null },
                    { 51, "library", null },
                    { 60, "movie_rental", null },
                    { 81, "police", null },
                    { 82, "post_office", null },
                    { 83, "primary_school", null },
                    { 104, "university", null },
                    { 103, "travel_agency", null },
                    { 102, "transit_station", null },
                    { 101, "train_station", null },
                    { 100, "tourist_attraction", null },
                    { 99, "taxi_stand", null },
                    { 98, "synagogue", null },
                    { 97, "supermarket", null },
                    { 96, "subway_station", null },
                    { 95, "store", null },
                    { 94, "storage", null },
                    { 93, "stadium", null },
                    { 92, "spa", null },
                    { 91, "shopping_mall", null },
                    { 90, "shoe_store", null },
                    { 89, "secondary_school", null },
                    { 88, "school", null },
                    { 87, "rv_park", null },
                    { 86, "roofing_contractor", null },
                    { 85, "restaurant", null },
                    { 84, "real_estate_agency", null },
                    { 50, "lawyer", null },
                    { 105, "veterinary_care", null },
                    { 49, "laundry", null },
                    { 47, "insurance_agency", null },
                    { 21, "casino", null },
                    { 20, "car_wash", null },
                    { 19, "car_repair", null },
                    { 18, "car_rental", null },
                    { 17, "car_dealer", null },
                    { 16, "campground", null },
                    { 15, "cafe", null },
                    { 14, "bus_station", null },
                    { 13, "bowling_alley", null },
                    { 22, "cemetery", null },
                    { 12, "book_store", null },
                    { 10, "beauty_salon", null },
                    { 9, "bar", null },
                    { 8, "bank", null },
                    { 7, "bakery", null },
                    { 6, "atm", null },
                    { 5, "art_gallery", null },
                    { 4, "aquarium", null },
                    { 3, "amusement_park", null },
                    { 2, "airport", null },
                    { 11, "bicycle_store", null },
                    { 23, "church", null },
                    { 24, "city_hall", null },
                    { 25, "clothing_store", null },
                    { 46, "hospital", null },
                    { 45, "home_goods_store", null },
                    { 44, "hindu_temple", null },
                    { 43, "hardware_store", null },
                    { 42, "hair_care", null },
                    { 41, "gym", null },
                    { 40, "grocery_or_supermarket", null },
                    { 39, "gas_station", null },
                    { 38, "furniture_store", null },
                    { 37, "funeral_home", null },
                    { 36, "florist", null },
                    { 35, "fire_station", null },
                    { 34, "embassy", null },
                    { 33, "electronics_store", null },
                    { 32, "electrician", null },
                    { 31, "drugstore", null },
                    { 30, "doctor", null },
                    { 29, "department_store", null },
                    { 28, "dentist", null },
                    { 27, "courthouse", null },
                    { 26, "convenience_store", null },
                    { 48, "jewelry_store", null },
                    { 106, "zoo", null }
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserPreferences_PlaceTypes_TypeId",
                table: "UserPreferences",
                column: "TypeId",
                principalTable: "PlaceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

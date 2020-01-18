using Microsoft.EntityFrameworkCore.Migrations;

namespace Meeter.Migrations
{
    public partial class pref : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PlaceTypes",
                columns: new[] { "Id", "PlaceId", "Type" },
                values: new object[,]
                {
                    { 1, null, "accounting" },
                    { 79, null, "physiotherapist" },
                    { 78, null, "pharmacy" },
                    { 77, null, "pet_store" },
                    { 76, null, "parking" },
                    { 75, null, "park" },
                    { 74, null, "painter" },
                    { 73, null, "night_club" },
                    { 72, null, "museum" },
                    { 71, null, "moving_company" },
                    { 80, null, "plumber" },
                    { 70, null, "movie_theater" },
                    { 59, null, "mosque" },
                    { 58, null, "meal_takeaway" },
                    { 57, null, "meal_delivery" },
                    { 56, null, "lodging" },
                    { 55, null, "locksmith" },
                    { 54, null, "local_government_office" },
                    { 53, null, "liquor_store" },
                    { 52, null, "light_rail_station" },
                    { 51, null, "library" },
                    { 60, null, "movie_rental" },
                    { 81, null, "police" },
                    { 82, null, "post_office" },
                    { 83, null, "primary_school" },
                    { 104, null, "university" },
                    { 103, null, "travel_agency" },
                    { 102, null, "transit_station" },
                    { 101, null, "train_station" },
                    { 100, null, "tourist_attraction" },
                    { 99, null, "taxi_stand" },
                    { 98, null, "synagogue" },
                    { 97, null, "supermarket" },
                    { 96, null, "subway_station" },
                    { 95, null, "store" },
                    { 94, null, "storage" },
                    { 93, null, "stadium" },
                    { 92, null, "spa" },
                    { 91, null, "shopping_mall" },
                    { 90, null, "shoe_store" },
                    { 89, null, "secondary_school" },
                    { 88, null, "school" },
                    { 87, null, "rv_park" },
                    { 86, null, "roofing_contractor" },
                    { 85, null, "restaurant" },
                    { 84, null, "real_estate_agency" },
                    { 50, null, "lawyer" },
                    { 105, null, "veterinary_care" },
                    { 49, null, "laundry" },
                    { 47, null, "insurance_agency" },
                    { 21, null, "casino" },
                    { 20, null, "car_wash" },
                    { 19, null, "car_repair" },
                    { 18, null, "car_rental" },
                    { 17, null, "car_dealer" },
                    { 16, null, "campground" },
                    { 15, null, "cafe" },
                    { 14, null, "bus_station" },
                    { 13, null, "bowling_alley" },
                    { 22, null, "cemetery" },
                    { 12, null, "book_store" },
                    { 10, null, "beauty_salon" },
                    { 9, null, "bar" },
                    { 8, null, "bank" },
                    { 7, null, "bakery" },
                    { 6, null, "atm" },
                    { 5, null, "art_gallery" },
                    { 4, null, "aquarium" },
                    { 3, null, "amusement_park" },
                    { 2, null, "airport" },
                    { 11, null, "bicycle_store" },
                    { 23, null, "church" },
                    { 24, null, "city_hall" },
                    { 25, null, "clothing_store" },
                    { 46, null, "hospital" },
                    { 45, null, "home_goods_store" },
                    { 44, null, "hindu_temple" },
                    { 43, null, "hardware_store" },
                    { 42, null, "hair_care" },
                    { 41, null, "gym" },
                    { 40, null, "grocery_or_supermarket" },
                    { 39, null, "gas_station" },
                    { 38, null, "furniture_store" },
                    { 37, null, "funeral_home" },
                    { 36, null, "florist" },
                    { 35, null, "fire_station" },
                    { 34, null, "embassy" },
                    { 33, null, "electronics_store" },
                    { 32, null, "electrician" },
                    { 31, null, "drugstore" },
                    { 30, null, "doctor" },
                    { 29, null, "department_store" },
                    { 28, null, "dentist" },
                    { 27, null, "courthouse" },
                    { 26, null, "convenience_store" },
                    { 48, null, "jewelry_store" },
                    { 106, null, "zoo" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}

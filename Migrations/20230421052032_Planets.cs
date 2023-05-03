using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace planetnineserver.Migrations
{
    /// <inheritdoc />
    public partial class Planets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Planet_User_UserId",
                table: "Planet");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Planet",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.InsertData(
                table: "Planet",
                columns: new[] { "PlanetId", "Aphelion", "Gravity", "ImageLink", "Perihelion", "PlanetMass", "PlanetName", "Temperature", "Type", "UserId" },
                values: new object[,]
                {
                    { 2, "69816900", "3.7", "https://solarsystem.nasa.gov/rails/active_storage/blobs/eyJfcmFpbHMiOnsibWVzc2FnZSI6IkJBaHBBc0VRIiwiZXhwIjpudWxsLCJwdXIiOiJibG9iX2lkIn19--b43e79a5b43d2063c4866ccff66bede5faff17b8/mercury_th.jpg", "46001200", "3.30114", "Mercury", "5.4291", "planet", 1 },
                    { 3, "108939000", "8.87", "https://solarsystem.nasa.gov/rails/active_storage/blobs/eyJfcmFpbHMiOnsibWVzc2FnZSI6IkJBaHBBajl5IiwiZXhwIjpudWxsLCJwdXIiOiJibG9iX2lkIn19--1771be6bd46710c30aa93cd6c3ababe23ad52681/480x320_venus.png?disposition=inline", "107477000", "4.86747", "Venus", "5.243", "planet", 1 },
                    { 4, "152100000", "9.8", "https://upload.wikimedia.org/wikipedia/commons/thumb/6/60/Earth_from_Space.jpg/2048px-Earth_from_Space.jpg", "147095000", "5.97237", "Earth", "5.5136", "planet", 1 },
                    { 5, "249200000", "3.7", "https://solarsystem.nasa.gov/system/stellar_items/image_files/6_mars.jpg", "206700000", "3.71", "Mars", "3.9341", "planet", 1 },
                    { 6, "816620000", "24.79", "https://solarsystem.nasa.gov/rails/active_storage/blobs/eyJfcmFpbHMiOnsibWVzc2FnZSI6IkJBaHBBdGxyIiwiZXhwIjpudWxsLCJwdXIiOiJibG9iX2lkIn19--229ba26c079b7122001319d5dcffec49c8d4e0cb/STSCI-H-p1936a-f-640.jpg?disposition=attachment", "740379835", "1.89819", "Jupiter", "1.3262", "planet", 1 },
                    { 7, "1503509229", "10.44", "https://solarsystem.nasa.gov/system/stellar_items/image_files/38_saturn_1600x900.jpg", "1349823615", "5.68336", "Saturn", "0.6871", "planet", 1 },
                    { 8, "3006318143", "8.87", "https://images.english.elpais.com/resizer/BH_KvY_lAzwSrpp8v7D55nGax8A=/1960x1470/filters:focal(2464x2210:2474x2220)/cloudfront-eu-central-1.images.arcpublishing.com/prisa/WQ773ELGFRDOHJ46MOLRXKJ7AY.jpg", "2734998229", "8.68127", "Uranus", "1.27", "planet", 1 },
                    { 9, "4537039826", "11.15", "https://solarsystem.nasa.gov/rails/active_storage/blobs/eyJfcmFpbHMiOnsibWVzc2FnZSI6IkJBaHBBbkp5IiwiZXhwIjpudWxsLCJwdXIiOiJibG9iX2lkIn19--cb7cb2868fd8b4892788893961c20975baffeb52/neptune_480x320.jpg?disposition=inline", "4459753056", "1.02413", "Neptune", "1.638", "planet", 1 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Planet_User_UserId",
                table: "Planet",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Planet_User_UserId",
                table: "Planet");

            migrationBuilder.DeleteData(
                table: "Planet",
                keyColumn: "PlanetId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Planet",
                keyColumn: "PlanetId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Planet",
                keyColumn: "PlanetId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Planet",
                keyColumn: "PlanetId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Planet",
                keyColumn: "PlanetId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Planet",
                keyColumn: "PlanetId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Planet",
                keyColumn: "PlanetId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Planet",
                keyColumn: "PlanetId",
                keyValue: 9);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Planet",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Planet_User_UserId",
                table: "Planet",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

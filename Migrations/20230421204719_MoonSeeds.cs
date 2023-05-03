using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace planetnineserver.Migrations
{
    /// <inheritdoc />
    public partial class MoonSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Moon",
                columns: new[] { "MoonId", "Aphelion", "Gravity", "ImageLink", "MoonMass", "MoonName", "Perihelion", "PlanetId", "Temperature", "Type", "UserId" },
                values: new object[,]
                {
                    { 1, "405500", "1.62", "", "7.346", "Moon", "363300", 4, "3.344", "moon", 1 },
                    { 2, "9518", "0.0057", "", "1.06", "Phobos", "9234", 5, "1.9", "moon", 1 },
                    { 3, "23471", "0.003", "", "1.4762", "Deimos", "23456", 5, "1.75", "moon", 1 },
                    { 4, "423529", "1.79", "", "8.932", "Io", "420071", 6, "3.53", "moon", 1 },
                    { 5, "0", "1.31", "", "4.8", "Europa", "0", 6, "3.01", "moon", 1 },
                    { 6, "0", "1.428", "", "1.4819", "Ganymede", "0", 6, "1.94", "moon", 1 },
                    { 7, "0", "1.235", "", "1.0759", "Callisto", "0", 6, "1.83", "moon", 1 },
                    { 8, "182840", "0.02", "", "7.5", "Amalthea", "181150", 6, "3.1", "moon", 1 },
                    { 9, "13082000", "0.062", "", "9.5", "Himalia", "9782900", 6, "1", "moon", 1 },
                    { 10, "0", "0.031", "", "8", "Elara", "0", 6, "1", "moon", 1 },
                    { 11, "0", "0.022", "", "3", "Pasiphae", "0", 6, "1", "moon", 1 },
                    { 12, "0", "0.014", "", "8", "Sinope", "0", 6, "1", "moon", 1 },
                    { 13, "0", "0.013", "", "8", "Lysithea", "0", 6, "1", "moon", 1 },
                    { 14, "0", "0.017", "", "1", "Carme", "0", 6, "1", "moon", 1 },
                    { 15, "0", "0.01", "", "4", "Ananke", "0", 6, "1", "moon", 1 },
                    { 16, "0", "0.0073", "", "6", "Leda", "0", 6, "1", "moon", 1 },
                    { 17, "226000", "0.02", "", "8", "Thebe", "218000", 6, "1", "moon", 1 },
                    { 18, "0", "0.002", "", "2", "Adrastea", "0", 6, "1", "moon", 1 },
                    { 19, "128026", "0.005", "", "1", "Metis", "127974", 6, "1", "moon", 1 },
                    { 20, "0", "0.0031", "", "8.7", "Callirrhoe", "0", 6, "1", "moon", 1 },
                    { 21, "8874300", "0.0029", "", "6.9", "Themisto", "5909000", 6, "1", "moon", 1 },
                    { 22, "0", "0", "", "2.1", "Megaclite", "0", 6, "1", "moon", 1 },
                    { 23, "0", "0", "", "1.6", "Taygete", "0", 6, "1", "moon", 1 },
                    { 24, "0", "0", "", "7.5", "Chaldene", "0", 6, "1", "moon", 1 },
                    { 25, "0", "0", "", "1.2", "Harpalyke", "0", 6, "1", "moon", 1 },
                    { 26, "0", "0", "", "1.9", "Kalyke", "0", 6, "1", "moon", 1 },
                    { 27, "0", "0", "", "1.9", "Iocaste", "0", 6, "1", "moon", 1 },
                    { 28, "0", "0", "", "4.5", "Erinome", "0", 6, "1", "moon", 1 },
                    { 29, "0", "0", "", "7.5", "Isonoe", "0", 6, "1", "moon", 1 },
                    { 30, "0", "0", "", "4.3", "Praxidike", "0", 6, "1", "moon", 1 },
                    { 31, "0", "0.0015", "", "9", "Autonoe", "0", 6, "1", "moon", 1 },
                    { 32, "0", "0.0015", "", "9", "Thyone", "0", 6, "1", "moon", 1 },
                    { 33, "0", "0.0015", "", "9", "Hermippe", "0", 6, "1", "moon", 1 },
                    { 34, "0", "0.0012", "", "4.5", "Aitne", "0", 6, "1", "moon", 1 },
                    { 35, "0", "0.0012", "", "4.5", "Eurydome", "0", 6, "1", "moon", 1 },
                    { 36, "0", "0.0012", "", "4.5", "Euanthe", "0", 6, "1", "moon", 1 },
                    { 37, "0", "0", "", "1.5", "Euporie", "0", 6, "1", "moon", 1 },
                    { 38, "0", "0.00081", "", "1.5", "Orthosie", "0", 6, "1", "moon", 1 },
                    { 39, "0", "0.00081", "", "1.5", "Sponde", "0", 6, "1", "moon", 1 },
                    { 40, "0", "0.00081", "", "1.5", "Kale", "0", 6, "1", "moon", 1 },
                    { 41, "0", "0.00081", "", "1.5", "Pasithee", "0", 6, "1", "moon", 1 },
                    { 42, "0", "0", "", "4.5", "Hegemone", "0", 6, "1", "moon", 1 },
                    { 43, "0", "0", "", "1.5", "Mneme", "0", 6, "1", "moon", 1 },
                    { 44, "0", "0", "", "9", "Aoede", "0", 6, "1", "moon", 1 },
                    { 45, "0", "0", "", "1.5", "Thelxinoe", "0", 6, "1", "moon", 1 },
                    { 46, "0", "0.0012", "", "4.15", "Arche", "0", 6, "1", "moon", 1 },
                    { 47, "0", "0", "", "1.5", "Kallichore", "0", 6, "1", "moon", 1 },
                    { 48, "0", "0", "", "9", "Helike", "0", 6, "1", "moon", 1 },
                    { 49, "0", "0", "", "4.5", "Carpo", "0", 6, "1", "moon", 1 },
                    { 50, "0", "0", "", "9", "Eukelade", "0", 6, "1", "moon", 1 },
                    { 51, "0", "0", "", "1.5", "Cyllene", "0", 6, "1", "moon", 1 },
                    { 52, "0", "0", "", "1.5", "Kore", "0", 6, "1", "moon", 1 },
                    { 53, "0", "0", "", "1.5", "Herse", "0", 6, "1", "moon", 1 },
                    { 54, "0", "0", "", "1.5", "S/2003 J 2", "0", 6, "1", "moon", 1 },
                    { 55, "0", "0", "", "1.5", "Eupheme", "0", 6, "1", "moon", 1 },
                    { 56, "0", "0", "", "1.5", "S/2003 J 4", "0", 6, "1", "moon", 1 },
                    { 57, "0", "0", "", "9", "Eirene", "0", 6, "1", "moon", 1 },
                    { 58, "0", "0", "", "1.5", "S/2003 J 9", "0", 6, "1", "moon", 1 },
                    { 59, "0", "0", "", "1.5", "S/2003 J 10", "0", 6, "1", "moon", 1 },
                    { 60, "0", "0", "", "1", "S/2003 J 12", "0", 6, "1", "moon", 1 },
                    { 61, "0", "0", "", "1.5", "Philophrosyne", "0", 6, "1", "moon", 1 },
                    { 62, "0", "0", "", "1.5", "S/2003 J 16", "0", 6, "1", "moon", 1 },
                    { 63, "0", "0", "", "1.5", "S/2003 J 18", "0", 6, "1", "moon", 1 },
                    { 64, "0", "0", "", "1.5", "S/2003 J 19", "0", 6, "1", "moon", 1 },
                    { 65, "0", "0.00081", "", "1.5", "S/2003 J 23", "0", 6, "1", "moon", 1 },
                    { 66, "189270", "0", "", "3.79", "Mimas", "181770", 7, "1.15", "moon", 1 },
                    { 67, "239066", "0", "", "1.08", "Enceladus", "236830", 7, "1.61", "moon", 1 },
                    { 68, "294648", "0", "", "6.18", "Tethys", "294589", 7, "0.985", "moon", 1 },
                    { 69, "378260", "0", "", "1.095", "Dione", "376580", 7, "1.48", "moon", 1 },
                    { 70, "527597", "0", "", "2.3", "Rhea", "526543", 7, "1.24", "moon", 1 },
                    { 71, "1257060", "0", "", "1.3452", "Titan", "1186680", 7, "1.88", "moon", 1 },
                    { 72, "1535756", "0", "", "5.6", "Hyperion", "1466112", 7, "0.55", "moon", 1 },
                    { 73, "3661612", "0", "", "1.805", "Iapetus", "3460068", 7, "1.09", "moon", 1 },
                    { 74, "0", "0", "", "8.292", "Phoebe", "0", 7, "1.64", "moon", 1 },
                    { 75, "0", "0", "", "1.9", "Janus", "0", 7, "0.63", "moon", 1 },
                    { 76, "0", "0", "", "5.3", "Epimetheus", "0", 7, "0.64", "moon", 1 },
                    { 77, "0", "0", "", "null", "Helene", "0", 7, "1.3", "moon", 1 },
                    { 78, "0", "0", "", "1", "Telesto", "0", 7, "1", "moon", 1 },
                    { 79, "0", "0", "", "6.5", "Calypso", "0", 7, "1", "moon", 1 },
                    { 80, "0", "0", "", "7", "Atlas", "0", 7, "0.5", "moon", 1 },
                    { 81, "0", "0", "", "1.6", "Prometheus", "0", 7, "0.48", "moon", 1 },
                    { 82, "0", "0", "", "1.4", "Pandora", "0", 7, "0.49", "moon", 1 },
                    { 83, "0", "0", "", "4.95", "Pan", "0", 7, "0.42", "moon", 1 },
                    { 84, "0", "0", "", "3.97", "Ymir", "0", 7, "1", "moon", 1 },
                    { 85, "23139965", "0", "", "7.25", "Paaliaq", "6908035", 7, "1", "moon", 1 },
                    { 86, "0", "0", "", "2.3", "Tarvos", "0", 7, "1", "moon", 1 },
                    { 87, "0", "0", "", "1.18", "Ijiraq", "0", 7, "1", "moon", 1 },
                    { 88, "0", "0", "", "2.3", "Suttungr", "0", 7, "1", "moon", 1 },
                    { 89, "0", "0", "", "2.79", "Kiviuq", "0", 7, "1", "moon", 1 },
                    { 90, "0", "0", "", "2.3", "Mundilfari", "0", 7, "1", "moon", 1 },
                    { 91, "0", "0", "", "2.23", "Albiorix", "0", 7, "1", "moon", 1 },
                    { 92, "0", "0", "", "3.5", "Skathi", "0", 7, "1", "moon", 1 },
                    { 93, "0", "0", "", "6.8", "Erriapus", "0", 7, "1", "moon", 1 },
                    { 94, "0", "0", "", "4.35", "Siarnaq", "0", 7, "1", "moon", 1 },
                    { 95, "0", "0", "", "2.3", "Thrymr", "0", 7, "1", "moon", 1 },
                    { 96, "0", "0", "", "2.3", "Narvi", "0", 7, "1", "moon", 1 },
                    { 97, "194459", "0", "", "2", "Methone", "194421", 7, "1", "moon", 1 },
                    { 98, "0", "0", "", "6", "Pallene", "0", 7, "1", "moon", 1 },
                    { 99, "0", "0", "", "1", "Polydeuces", "0", 7, "1", "moon", 1 },
                    { 100, "0", "0", "", "1", "Daphnis", "0", 7, "0.34", "moon", 1 },
                    { 101, "0", "0", "", "1.5", "Aegir", "0", 7, "1", "moon", 1 },
                    { 102, "0", "0", "", "1.5", "Bebhionn", "0", 7, "1", "moon", 1 },
                    { 103, "0", "0", "", "1.5", "Bergelmir", "0", 7, "1", "moon", 1 },
                    { 104, "0", "0", "", "2.3", "Bestla", "0", 7, "1", "moon", 1 },
                    { 105, "0", "0", "", "9", "Farbauti", "0", 7, "1", "moon", 1 },
                    { 106, "0", "0", "", "5", "Fenrir", "0", 7, "1", "moon", 1 },
                    { 107, "0", "0", "", "1.5", "Fornjot", "0", 7, "1", "moon", 1 },
                    { 108, "0", "0", "", "1.5", "Hati", "0", 7, "1", "moon", 1 },
                    { 109, "0", "0", "", "3.5", "Hyrrokkin", "0", 7, "1", "moon", 1 },
                    { 110, "0", "0", "", "2.3", "Kari", "0", 7, "1", "moon", 1 },
                    { 111, "0", "0", "", "1.5", "Loge", "0", 7, "1", "moon", 1 },
                    { 112, "0", "0", "", "1.5", "Skoll", "0", 7, "1", "moon", 1 },
                    { 113, "0", "0", "", "1.5", "Surtur", "0", 7, "1", "moon", 1 },
                    { 114, "0", "0", "", "5", "Anthe", "0", 7, "1", "moon", 1 },
                    { 115, "0", "0", "", "1", "Jarnsaxa", "0", 7, "1", "moon", 1 },
                    { 116, "0", "0", "", "1.5", "Greip", "0", 7, "1", "moon", 1 },
                    { 117, "0", "0", "", "2.3", "Tarqeq", "0", 7, "1", "moon", 1 },
                    { 118, "0", "0", "", "1", "Aegaeon", "0", 7, "1", "moon", 1 },
                    { 119, "0", "0", "", "1.5", "S/2004 S 7", "0", 7, "1", "moon", 1 },
                    { 120, "0", "0", "", "9", "S/2004 S 12", "0", 7, "1", "moon", 1 },
                    { 121, "0", "0", "", "1.5", "S/2004 S 13", "0", 7, "1", "moon", 1 },
                    { 122, "0", "0", "", "5", "S/2004 S 17", "0", 7, "1", "moon", 1 },
                    { 123, "0", "0", "", "1", "S/2006 S 1", "0", 7, "1", "moon", 1 },
                    { 124, "0", "0", "", "1.5", "S/2006 S 3", "0", 7, "1", "moon", 1 },
                    { 125, "0", "0", "", "1.5", "S/2007 S 2", "0", 7, "1", "moon", 1 },
                    { 126, "0", "0", "", "1.5", "S/2007 S 3", "0", 7, "1", "moon", 1 },
                    { 127, "0", "0", "", "1", "S/2009 S 1", "0", 7, "1", "moon", 1 },
                    { 128, "191130", "0", "", "12.9", "Ariel", "190670", 8, "1.59", "moon", 1 },
                    { 129, "267500", "0", "", "12.2", "Umbriel", "265100", 8, "1.46", "moon", 1 },
                    { 130, "436800", "0", "", "34.2", "Titania", "435800", 8, "1.66", "moon", 1 },
                    { 131, "584336", "0", "", "28.8", "Oberon", "582702", 8, "1.56", "moon", 1 },
                    { 132, "130041", "0", "", "6.6", "Miranda", "129703", 8, "1.2", "moon", 1 },
                    { 133, "0", "0", "", "4.5", "Cordelia", "0", 8, "1", "moon", 1 },
                    { 134, "0", "0", "", "5.4", "Ophelia", "0", 8, "1", "moon", 1 },
                    { 135, "0", "0", "", "9.2", "Bianca", "0", 8, "1", "moon", 1 },
                    { 136, "0", "0", "", "3.4", "Cressida", "0", 8, "1", "moon", 1 },
                    { 137, "0", "0", "", "1.8", "Desdemona", "0", 8, "1", "moon", 1 },
                    { 138, "0", "0", "", "5.6", "Juliet", "0", 8, "1", "moon", 1 },
                    { 139, "0", "0", "", "1.7", "Portia", "0", 8, "1", "moon", 1 },
                    { 140, "0", "0", "", "0.25", "Rosalind", "0", 8, "1", "moon", 1 },
                    { 141, "0", "0", "", "4.9", "Belinda", "0", 8, "1", "moon", 1 },
                    { 142, "0", "0", "", "2.9", "Puck", "0", 8, "1", "moon", 1 },
                    { 143, "0", "0", "", "2.5", "Caliban", "0", 8, "1", "moon", 1 },
                    { 144, "0", "0", "", "2.3", "Sycorax", "0", 8, "1", "moon", 1 },
                    { 145, "0", "0", "", "8.5", "Prospero", "0", 8, "1", "moon", 1 },
                    { 146, "0", "0", "", "7.5", "Setebos", "0", 8, "1", "moon", 1 },
                    { 147, "0", "0", "", "2.2", "Stephano", "0", 8, "1", "moon", 1 },
                    { 148, "0", "0", "", "3.9", "Trinculo", "0", 8, "1", "moon", 1 },
                    { 149, "0", "0", "", "7.2", "Francisco", "0", 8, "1", "moon", 1 },
                    { 150, "0", "0", "", "5.4", "Margaret", "0", 8, "1", "moon", 1 },
                    { 151, "0", "0", "", "5.4", "Ferdinand", "0", 8, "1", "moon", 1 },
                    { 152, "0", "0", "", "1.8", "Perdita", "0", 8, "1", "moon", 1 },
                    { 153, "0", "0", "", "1", "Mab", "0", 8, "1", "moon", 1 },
                    { 154, "0", "0", "", "3.8", "Cupid", "0", 8, "1", "moon", 1 },
                    { 155, "354765", "0.78", "", "2.14", "Triton", "354753", 9, "2.05", "moon", 1 },
                    { 156, "9655000", "0.071", "", "3", "Nereid", "1372000", 9, "1", "moon", 1 },
                    { 157, "0", "0.01", "", "2", "Naiad", "0", 9, "1", "moon", 1 },
                    { 158, "0", "0.013", "", "4", "Thalassa", "0", 9, "1", "moon", 1 },
                    { 159, "0", "0.023", "", "2", "Despina", "0", 9, "1", "moon", 1 },
                    { 160, "0", "0.03", "", "2", "Galatea", "0", 9, "1", "moon", 1 },
                    { 161, "0", "0.034", "", "5", "Larissa", "0", 9, "1", "moon", 1 },
                    { 162, "0", "0.075", "", "5", "Proteus", "0", 9, "1", "moon", 1 },
                    { 163, "0", "0.01", "", "2", "Halimede", "0", 9, "1", "moon", 1 },
                    { 164, "0", "0", "", "2", "Psamathe", "0", 9, "1", "moon", 1 },
                    { 165, "0", "0.01", "", "1", "Sao", "0", 9, "1", "moon", 1 },
                    { 166, "0", "0.01", "", "1", "Laomedeia", "0", 9, "1", "moon", 1 },
                    { 167, "0", "0", "", "1", "Neso", "0", 9, "1", "moon", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "Moon",
                keyColumn: "MoonId",
                keyValue: 167);
        }
    }
}

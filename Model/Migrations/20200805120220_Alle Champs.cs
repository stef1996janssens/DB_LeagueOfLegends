using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class AlleChamps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Champions",
                columns: new[] { "ChampionId", "BlueEssencePrice", "ChampionNaam", "RiotPointPrice" },
                values: new object[,]
                {
                    { 11, 0, "Azir", 0 },
                    { 113, 0, "Sylas", 0 },
                    { 112, 0, "Swain", 0 },
                    { 111, 0, "Soraka", 0 },
                    { 110, 0, "Sona", 0 },
                    { 109, 0, "Skarner", 0 },
                    { 108, 0, "Sivir", 0 },
                    { 107, 0, "Sion", 0 },
                    { 106, 0, "Singed", 0 },
                    { 105, 0, "Shyvana", 0 },
                    { 104, 0, "Shen", 0 },
                    { 103, 0, "Shaco", 0 },
                    { 102, 0, "Sett", 0 },
                    { 101, 0, "Senna", 0 },
                    { 100, 0, "Sejuani", 0 },
                    { 99, 0, "Ryze", 0 },
                    { 98, 0, "Rumble", 0 },
                    { 97, 0, "Riven", 0 },
                    { 83, 0, "Nunu & Willump", 0 },
                    { 84, 0, "Olaf", 0 },
                    { 85, 0, "Orianna", 0 },
                    { 86, 0, "Ornn", 0 },
                    { 87, 0, "Pantheon", 0 },
                    { 88, 0, "Poppy", 0 },
                    { 114, 0, "Syndra", 0 },
                    { 89, 0, "Pyke", 0 },
                    { 91, 0, "Quinn", 0 },
                    { 92, 0, "Rakan", 0 },
                    { 93, 0, "Rammus", 0 },
                    { 94, 0, "Rek'Sai", 0 },
                    { 95, 0, "Renekton", 0 },
                    { 96, 0, "Rengar", 0 },
                    { 90, 0, "Qiyana", 0 },
                    { 82, 0, "Nocturne", 0 },
                    { 115, 0, "Tahm Kench", 0 },
                    { 117, 0, "Talon", 0 },
                    { 148, 0, "Zilean", 0 },
                    { 147, 0, "Ziggs", 0 },
                    { 146, 0, "Zed", 0 },
                    { 145, 0, "Zac", 0 },
                    { 144, 0, "Yuumi", 0 },
                    { 143, 0, "Yorick", 0 },
                    { 142, 0, "Yone", 0 },
                    { 141, 0, "Yasuo", 0 },
                    { 140, 0, "Xin Zhao", 0 },
                    { 139, 0, "Xerath", 0 },
                    { 138, 0, "Xayah", 0 },
                    { 137, 0, "Wukong", 0 },
                    { 136, 0, "Warwick", 0 },
                    { 135, 0, "Volibear", 0 },
                    { 134, 0, "Vladimir", 0 },
                    { 133, 0, "Viktor", 0 },
                    { 132, 0, "Vi", 0 },
                    { 118, 0, "Taric", 0 },
                    { 119, 0, "Teemo", 0 },
                    { 120, 0, "Thresh", 0 },
                    { 121, 0, "Tristana", 0 },
                    { 122, 0, "Trundle", 0 },
                    { 123, 0, "Tryndamere", 0 },
                    { 116, 0, "Taliyah", 0 },
                    { 124, 0, "Twisted Fate", 0 },
                    { 126, 0, "Udyr", 0 },
                    { 127, 0, "Urgot", 0 },
                    { 128, 0, "Varus", 0 },
                    { 129, 0, "Vayne", 0 },
                    { 130, 0, "Veigar", 0 },
                    { 131, 0, "Vel'Koz", 0 },
                    { 125, 0, "Twitch", 0 },
                    { 81, 0, "Nidalee", 0 },
                    { 80, 0, "Neeko", 0 },
                    { 79, 0, "Nautilus", 0 },
                    { 42, 0, "Ivern", 0 },
                    { 41, 0, "Irelia", 0 },
                    { 40, 0, "Illaoi", 0 },
                    { 39, 0, "Heimerdinger", 0 },
                    { 38, 0, "Hecarim", 0 },
                    { 37, 0, "Graves", 0 },
                    { 36, 0, "Gragas", 0 },
                    { 35, 0, "Gnar", 0 },
                    { 34, 0, "Garen", 0 },
                    { 33, 0, "Gangplank", 0 },
                    { 32, 0, "Galio", 0 },
                    { 31, 0, "Fizz", 0 },
                    { 30, 0, "Fiora", 0 },
                    { 29, 0, "Fiddlesticks", 0 },
                    { 28, 0, "Ezreal", 0 },
                    { 27, 0, "Evelynn", 0 },
                    { 26, 0, "Elise", 0 },
                    { 12, 0, "Bard", 0 },
                    { 13, 0, "Blitzcrank", 0 },
                    { 14, 0, "Brand", 0 },
                    { 15, 0, "Braum", 0 },
                    { 16, 0, "Caitlyn", 0 },
                    { 17, 0, "Camille", 0 },
                    { 43, 0, "Janna", 0 },
                    { 18, 0, "Cassiopeia", 0 },
                    { 20, 0, "Corki", 0 },
                    { 21, 0, "Darius", 0 },
                    { 22, 0, "Diana", 0 },
                    { 23, 0, "Draven", 0 },
                    { 24, 0, "Dr. Mundo", 0 },
                    { 25, 0, "Ekko", 0 },
                    { 19, 0, "Cho'Gath", 0 },
                    { 44, 0, "Jarvan IV", 0 },
                    { 45, 0, "Jax", 0 },
                    { 46, 0, "Jayce", 0 },
                    { 65, 0, "Lillia", 0 },
                    { 66, 0, "Lissandra", 0 },
                    { 67, 0, "Lucian", 0 },
                    { 68, 0, "Lulu", 0 },
                    { 69, 0, "Lux", 0 },
                    { 70, 0, "Malphite", 0 },
                    { 64, 0, "Leona", 0 },
                    { 71, 0, "Malzahar", 0 },
                    { 73, 0, "Master Yi", 0 },
                    { 74, 0, "Miss Fortune", 0 },
                    { 75, 0, "Mordekaiser", 0 },
                    { 76, 0, "Morgana", 0 },
                    { 77, 0, "Nami", 0 },
                    { 78, 0, "Nasus", 0 },
                    { 72, 0, "Maokai", 0 },
                    { 149, 0, "Zoe", 0 },
                    { 63, 0, "Lee Sin", 0 },
                    { 61, 0, "Kog'Maw", 0 },
                    { 47, 0, "Jhin", 0 },
                    { 48, 0, "Jinx", 0 },
                    { 49, 0, "Kai'Sa", 0 },
                    { 50, 0, "Kalista", 0 },
                    { 51, 0, "Karma", 0 },
                    { 52, 0, "Karthus", 0 },
                    { 62, 0, "LeBlanc", 0 },
                    { 53, 0, "Kassadin", 0 },
                    { 55, 0, "Kayle", 0 },
                    { 56, 0, "Kayn", 0 },
                    { 57, 0, "Kennen", 0 },
                    { 58, 0, "Kha'Zix", 0 },
                    { 59, 0, "Kindred", 0 },
                    { 60, 0, "Kled", 0 },
                    { 54, 0, "Katarina", 0 },
                    { 150, 0, "Zyra", 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Champions",
                keyColumn: "ChampionId",
                keyValue: 150);
        }
    }
}

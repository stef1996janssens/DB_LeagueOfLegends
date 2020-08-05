using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Champions",
                columns: table => new
                {
                    ChampionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChampionNaam = table.Column<string>(maxLength: 50, nullable: false),
                    BlueEssencePrice = table.Column<int>(nullable: false),
                    RiotPointPrice = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Champions", x => x.ChampionId);
                });

            migrationBuilder.CreateTable(
                name: "Skins",
                columns: table => new
                {
                    SkinId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkinNaam = table.Column<string>(maxLength: 50, nullable: false),
                    RiotPointPrice = table.Column<int>(nullable: false),
                    ChampionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skins", x => x.SkinId);
                    table.ForeignKey(
                        name: "FK_Skin_Champion",
                        column: x => x.ChampionId,
                        principalTable: "Champions",
                        principalColumn: "ChampionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Champions",
                columns: new[] { "ChampionId", "BlueEssencePrice", "ChampionNaam", "RiotPointPrice" },
                values: new object[,]
                {
                    { 1, 0, "Aatrox", 0 },
                    { 2, 0, "Ahri", 0 },
                    { 3, 0, "Akali", 0 },
                    { 4, 0, "Alistar", 0 },
                    { 5, 0, "Amumu", 0 },
                    { 6, 0, "Anivia", 0 },
                    { 7, 0, "Annie", 0 },
                    { 8, 0, "Aphelios", 0 },
                    { 9, 0, "Ashe", 0 },
                    { 10, 0, "Aurelion Sol", 0 }
                });

            migrationBuilder.InsertData(
                table: "Skins",
                columns: new[] { "SkinId", "ChampionId", "RiotPointPrice", "SkinNaam" },
                values: new object[,]
                {
                    { 1, 1, 975, "Justicar Aatrox" },
                    { 15, 2, 1350, "K/DA Ahri" },
                    { 14, 2, 1820, "Star Guardian Ahri" },
                    { 13, 2, 1350, "Arcade Ahri" },
                    { 12, 2, 750, "Academy Ahri" },
                    { 11, 2, 0, "Challenger Ahri" },
                    { 10, 2, 975, "Popstar Ahri " },
                    { 16, 2, 0, "K/DA Ahri Prestige Edition" },
                    { 9, 2, 975, "Foxfire Ahri" },
                    { 7, 2, 975, "Dynasty Ahri" },
                    { 6, 1, 0, "Victorious Aatrox" },
                    { 5, 1, 0, "Blood Moon Aatrox Prestige Edition" },
                    { 4, 1, 1350, "Blood Moon Aatrox" },
                    { 3, 1, 750, "Sea Hunter Aatrox" },
                    { 2, 1, 1350, "Mecha Aatrox" },
                    { 8, 2, 750, "Midnight Ahri" },
                    { 17, 2, 1350, "Elderwood Ahri" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skins_ChampionId",
                table: "Skins",
                column: "ChampionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Skins");

            migrationBuilder.DropTable(
                name: "Champions");
        }
    }
}

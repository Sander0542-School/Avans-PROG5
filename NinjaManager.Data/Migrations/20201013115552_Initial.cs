using Microsoft.EntityFrameworkCore.Migrations;

namespace NinjaManager.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gears",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Gold = table.Column<int>(nullable: false),
                    Strength = table.Column<int>(nullable: false),
                    Intelligence = table.Column<int>(nullable: false),
                    Agility = table.Column<int>(nullable: false),
                    Category = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gears", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ninjas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Gold = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ninjas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NinjaGear",
                columns: table => new
                {
                    NinjaId = table.Column<int>(nullable: false),
                    GearId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NinjaGear", x => new { x.NinjaId, x.GearId });
                    table.ForeignKey(
                        name: "FK_NinjaGear_Gears_GearId",
                        column: x => x.GearId,
                        principalTable: "Gears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NinjaGear_Ninjas_NinjaId",
                        column: x => x.NinjaId,
                        principalTable: "Ninjas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Gears",
                columns: new[] { "Id", "Agility", "Category", "Gold", "Intelligence", "Name", "Strength" },
                values: new object[,]
                {
                    { 1, 100, 0, 50, 10, "Iron Helmet", 10 },
                    { 18, 10, 3, 100, 100, "Diamond Boots", 100 },
                    { 17, 50, 3, 75, 50, "Gold Boots", 50 },
                    { 16, 100, 3, 50, 10, "Iron Boots", 10 },
                    { 15, 10, 4, 100, 100, "Diamond Ring", 100 },
                    { 14, 50, 4, 75, 50, "Gold Ring", 50 },
                    { 13, 100, 4, 50, 10, "Iron Ring", 10 },
                    { 12, 10, 2, 100, 100, "Diamond Gloves", 100 },
                    { 11, 50, 2, 75, 50, "Gold Gloves", 50 },
                    { 10, 100, 2, 50, 10, "Iron Gloves", 10 },
                    { 9, 10, 1, 100, 100, "Diamond Chest", 100 },
                    { 8, 50, 1, 75, 50, "Gold Chest", 50 },
                    { 7, 100, 1, 50, 10, "Iron Chest", 10 },
                    { 6, 10, 5, 100, 100, "Diamond Necklace", 100 },
                    { 5, 50, 5, 75, 50, "Gold Necklace", 50 },
                    { 4, 100, 5, 50, 10, "Iron Necklace", 10 },
                    { 3, 10, 0, 100, 100, "Diamond Helmet", 100 },
                    { 2, 50, 0, 75, 50, "Gold Helmet", 50 }
                });

            migrationBuilder.InsertData(
                table: "Ninjas",
                columns: new[] { "Id", "Gold", "Name" },
                values: new object[,]
                {
                    { 1, 600, "John Doe" },
                    { 2, 275, "Jane Doe" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gears_Name_Category",
                table: "Gears",
                columns: new[] { "Name", "Category" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NinjaGear_GearId",
                table: "NinjaGear",
                column: "GearId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NinjaGear");

            migrationBuilder.DropTable(
                name: "Gears");

            migrationBuilder.DropTable(
                name: "Ninjas");
        }
    }
}

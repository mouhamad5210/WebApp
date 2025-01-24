using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Core_Project.Migrations
{
    /// <inheritdoc />
    public partial class initDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "COMPANY",
                columns: table => new
                {
                    ID_COMPANY = table.Column<int>(type: "INTEGER", nullable: false),
                    LABEL = table.Column<string>(type: "TEXT", unicode: false, maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPANY", x => x.ID_COMPANY);
                });

            migrationBuilder.CreateTable(
                name: "FOOD_GROUP",
                columns: table => new
                {
                    ID_FOOD_GROUP = table.Column<int>(type: "INTEGER", nullable: false),
                    LABEL = table.Column<string>(type: "TEXT", unicode: false, maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FOOD_GROUP", x => x.ID_FOOD_GROUP);
                });

            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    ID_USER = table.Column<int>(type: "INTEGER", nullable: false),
                    USERNAME = table.Column<string>(type: "TEXT", unicode: false, maxLength: 50, nullable: false),
                    PASSWORD = table.Column<string>(type: "TEXT", unicode: false, maxLength: 50, nullable: false),
                    IS_ADMIN = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.ID_USER);
                });

            migrationBuilder.CreateTable(
                name: "FOOD_ITEM",
                columns: table => new
                {
                    ID_FOOD_ITEM = table.Column<int>(type: "INTEGER", nullable: false),
                    ID_FOOD_GROUP = table.Column<int>(type: "INTEGER", nullable: false),
                    LABEL = table.Column<string>(type: "TEXT", unicode: false, maxLength: 150, nullable: false),
                    ENERGY_KCAL = table.Column<string>(type: "TEXT", unicode: false, maxLength: 150, nullable: true),
                    FAT_G = table.Column<string>(type: "TEXT", unicode: false, maxLength: 150, nullable: true),
                    CARBOHYDRAT_G = table.Column<string>(type: "TEXT", unicode: false, maxLength: 150, nullable: true),
                    PROTEIN_G = table.Column<string>(type: "TEXT", unicode: false, maxLength: 150, nullable: true),
                    SODIUM_MG = table.Column<string>(type: "TEXT", unicode: false, maxLength: 150, nullable: true),
                    SUGAR_G = table.Column<string>(type: "TEXT", unicode: false, maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FOOD_ITEM", x => x.ID_FOOD_ITEM);
                    table.ForeignKey(
                        name: "FK_FOOD_ITE_HAS_FOOD__FOOD_GRO",
                        column: x => x.ID_FOOD_GROUP,
                        principalTable: "FOOD_GROUP",
                        principalColumn: "ID_FOOD_GROUP");
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT",
                columns: table => new
                {
                    ID_PRODUCT = table.Column<int>(type: "INTEGER", nullable: false),
                    ID_COMPANY = table.Column<int>(type: "INTEGER", nullable: false),
                    ID_FOOD_ITEM = table.Column<int>(type: "INTEGER", nullable: false),
                    LABEL = table.Column<string>(type: "TEXT", unicode: false, maxLength: 150, nullable: false),
                    PRIX = table.Column<decimal>(type: "decimal(10, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT", x => x.ID_PRODUCT);
                    table.ForeignKey(
                        name: "FK_PRODUCT_BELONG_TO_COMPANY",
                        column: x => x.ID_COMPANY,
                        principalTable: "COMPANY",
                        principalColumn: "ID_COMPANY");
                    table.ForeignKey(
                        name: "FK_PRODUCT_RELATED_T_FOOD_ITE",
                        column: x => x.ID_FOOD_ITEM,
                        principalTable: "FOOD_ITEM",
                        principalColumn: "ID_FOOD_ITEM");
                });

            migrationBuilder.InsertData(
                table: "USER",
                columns: new[] { "ID_USER", "IS_ADMIN", "PASSWORD", "USERNAME" },
                values: new object[,]
                {
                    { 1, true, "admin", "admin" },
                    { 2, false, "2846", "testUser" }
                });

            migrationBuilder.CreateIndex(
                name: "HAS_FOOD_GROUP_FK",
                table: "FOOD_ITEM",
                column: "ID_FOOD_GROUP");

            migrationBuilder.CreateIndex(
                name: "BELONG_TO_COMPANY_FK",
                table: "PRODUCT",
                column: "ID_COMPANY");

            migrationBuilder.CreateIndex(
                name: "RELATED_TO_FOOD_ITEM_FK",
                table: "PRODUCT",
                column: "ID_FOOD_ITEM");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRODUCT");

            migrationBuilder.DropTable(
                name: "USER");

            migrationBuilder.DropTable(
                name: "COMPANY");

            migrationBuilder.DropTable(
                name: "FOOD_ITEM");

            migrationBuilder.DropTable(
                name: "FOOD_GROUP");
        }
    }
}

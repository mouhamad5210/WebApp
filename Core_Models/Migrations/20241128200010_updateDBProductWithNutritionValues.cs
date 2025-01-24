using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core_Project.Migrations
{
    /// <inheritdoc />
    public partial class updateDBProductWithNutritionValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CARBOHYDRAT_G",
                table: "FOOD_ITEM");

            migrationBuilder.DropColumn(
                name: "ENERGY_KCAL",
                table: "FOOD_ITEM");

            migrationBuilder.DropColumn(
                name: "FAT_G",
                table: "FOOD_ITEM");

            migrationBuilder.DropColumn(
                name: "PROTEIN_G",
                table: "FOOD_ITEM");

            migrationBuilder.DropColumn(
                name: "SODIUM_MG",
                table: "FOOD_ITEM");

            migrationBuilder.DropColumn(
                name: "SUGAR_G",
                table: "FOOD_ITEM");

            migrationBuilder.AddColumn<int>(
                name: "CARBOHYDRAT_G",
                table: "PRODUCT",
                type: "INTEGER",
                unicode: false,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ENERGY_KCAL",
                table: "PRODUCT",
                type: "INTEGER",
                unicode: false,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FAT_G",
                table: "PRODUCT",
                type: "INTEGER",
                unicode: false,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PROTEIN_G",
                table: "PRODUCT",
                type: "INTEGER",
                unicode: false,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SODIUM_MG",
                table: "PRODUCT",
                type: "INTEGER",
                unicode: false,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SUGAR_G",
                table: "PRODUCT",
                type: "INTEGER",
                unicode: false,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CARBOHYDRAT_G",
                table: "PRODUCT");

            migrationBuilder.DropColumn(
                name: "ENERGY_KCAL",
                table: "PRODUCT");

            migrationBuilder.DropColumn(
                name: "FAT_G",
                table: "PRODUCT");

            migrationBuilder.DropColumn(
                name: "PROTEIN_G",
                table: "PRODUCT");

            migrationBuilder.DropColumn(
                name: "SODIUM_MG",
                table: "PRODUCT");

            migrationBuilder.DropColumn(
                name: "SUGAR_G",
                table: "PRODUCT");

            migrationBuilder.AddColumn<int>(
                name: "CARBOHYDRAT_G",
                table: "FOOD_ITEM",
                type: "INTEGER",
                unicode: false,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ENERGY_KCAL",
                table: "FOOD_ITEM",
                type: "INTEGER",
                unicode: false,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FAT_G",
                table: "FOOD_ITEM",
                type: "INTEGER",
                unicode: false,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PROTEIN_G",
                table: "FOOD_ITEM",
                type: "INTEGER",
                unicode: false,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SODIUM_MG",
                table: "FOOD_ITEM",
                type: "INTEGER",
                unicode: false,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SUGAR_G",
                table: "FOOD_ITEM",
                type: "INTEGER",
                unicode: false,
                nullable: true);
        }
    }
}

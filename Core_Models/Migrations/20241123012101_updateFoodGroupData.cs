using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Core_Project.Migrations
{
    /// <inheritdoc />
    public partial class updateFoodGroupData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FOOD_GROUP",
                columns: new[] { "ID_FOOD_GROUP", "LABEL" },
                values: new object[,]
                {
                    { 1, "Vegetables" },
                    { 2, "Fruit" },
                    { 3, "Meat" },
                    { 4, "Chicken" },
                    { 5, "Fish" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FOOD_GROUP",
                keyColumn: "ID_FOOD_GROUP",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FOOD_GROUP",
                keyColumn: "ID_FOOD_GROUP",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FOOD_GROUP",
                keyColumn: "ID_FOOD_GROUP",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FOOD_GROUP",
                keyColumn: "ID_FOOD_GROUP",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FOOD_GROUP",
                keyColumn: "ID_FOOD_GROUP",
                keyValue: 5);
        }
    }
}

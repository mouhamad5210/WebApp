using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core_Project.Migrations
{
    /// <inheritdoc />
    public partial class updateFoodAndProductImageUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "PRODUCT",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "FOOD_ITEM",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "PRODUCT");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "FOOD_ITEM");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Core_Project.Migrations
{
    /// <inheritdoc />
    public partial class initCompaniesData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "COMPANY",
                columns: new[] { "ID_COMPANY", "LABEL" },
                values: new object[,]
                {
                    { 1, "Fresh Farm Produce" },
                    { 2, "Healthy Snacks Inc." },
                    { 3, "Meat Lovers Co." },
                    { 4, "Poultry Delight" },
                    { 5, "Ocean's Finest Seafood" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "COMPANY",
                keyColumn: "ID_COMPANY",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "COMPANY",
                keyColumn: "ID_COMPANY",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "COMPANY",
                keyColumn: "ID_COMPANY",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "COMPANY",
                keyColumn: "ID_COMPANY",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "COMPANY",
                keyColumn: "ID_COMPANY",
                keyValue: 5);
        }
    }
}

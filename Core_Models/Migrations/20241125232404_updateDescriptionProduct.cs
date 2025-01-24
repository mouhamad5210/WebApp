using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core_Project.Migrations
{
    /// <inheritdoc />
    public partial class updateDescriptionProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PRODUCT",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "PRODUCT");
        }
    }
}

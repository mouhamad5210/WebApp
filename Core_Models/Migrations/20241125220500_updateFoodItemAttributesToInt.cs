using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core_Project.Migrations
{
    /// <inheritdoc />
    public partial class updateFoodItemAttributesToInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SUGAR_G",
                table: "FOOD_ITEM",
                type: "INTEGER",
                unicode: false,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldUnicode: false,
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SODIUM_MG",
                table: "FOOD_ITEM",
                type: "INTEGER",
                unicode: false,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldUnicode: false,
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PROTEIN_G",
                table: "FOOD_ITEM",
                type: "INTEGER",
                unicode: false,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldUnicode: false,
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FAT_G",
                table: "FOOD_ITEM",
                type: "INTEGER",
                unicode: false,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldUnicode: false,
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ENERGY_KCAL",
                table: "FOOD_ITEM",
                type: "INTEGER",
                unicode: false,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldUnicode: false,
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CARBOHYDRAT_G",
                table: "FOOD_ITEM",
                type: "INTEGER",
                unicode: false,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldUnicode: false,
                oldMaxLength: 150,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SUGAR_G",
                table: "FOOD_ITEM",
                type: "TEXT",
                unicode: false,
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldUnicode: false,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SODIUM_MG",
                table: "FOOD_ITEM",
                type: "TEXT",
                unicode: false,
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldUnicode: false,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PROTEIN_G",
                table: "FOOD_ITEM",
                type: "TEXT",
                unicode: false,
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldUnicode: false,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FAT_G",
                table: "FOOD_ITEM",
                type: "TEXT",
                unicode: false,
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldUnicode: false,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ENERGY_KCAL",
                table: "FOOD_ITEM",
                type: "TEXT",
                unicode: false,
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldUnicode: false,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CARBOHYDRAT_G",
                table: "FOOD_ITEM",
                type: "TEXT",
                unicode: false,
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldUnicode: false,
                oldNullable: true);
        }
    }
}

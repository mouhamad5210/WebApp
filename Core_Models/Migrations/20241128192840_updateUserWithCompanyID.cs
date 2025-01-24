using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core_Project.Migrations
{
    /// <inheritdoc />
    public partial class updateUserWithCompanyID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ID_COMPANY",
                table: "USER",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "COMPANY",
                keyColumn: "ID_COMPANY",
                keyValue: 1,
                column: "LABEL",
                value: "RAYAN");

            migrationBuilder.InsertData(
                table: "COMPANY",
                columns: new[] { "ID_COMPANY", "LABEL" },
                values: new object[] { 6, "Fresh Farm Produce" });

            migrationBuilder.UpdateData(
                table: "USER",
                keyColumn: "ID_USER",
                keyValue: 1,
                column: "ID_COMPANY",
                value: 1);

            migrationBuilder.UpdateData(
                table: "USER",
                keyColumn: "ID_USER",
                keyValue: 2,
                column: "ID_COMPANY",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_USER_ID_COMPANY",
                table: "USER",
                column: "ID_COMPANY");

            migrationBuilder.AddForeignKey(
                name: "FK_USER_COMPANY",
                table: "USER",
                column: "ID_COMPANY",
                principalTable: "COMPANY",
                principalColumn: "ID_COMPANY");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_USER_COMPANY",
                table: "USER");

            migrationBuilder.DropIndex(
                name: "IX_USER_ID_COMPANY",
                table: "USER");

            migrationBuilder.DeleteData(
                table: "COMPANY",
                keyColumn: "ID_COMPANY",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "ID_COMPANY",
                table: "USER");

            migrationBuilder.UpdateData(
                table: "COMPANY",
                keyColumn: "ID_COMPANY",
                keyValue: 1,
                column: "LABEL",
                value: "Fresh Farm Produce");
        }
    }
}

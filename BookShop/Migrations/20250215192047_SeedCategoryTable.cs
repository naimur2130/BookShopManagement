using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookShop.Migrations
{
    /// <inheritdoc />
    public partial class SeedCategoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName", "DisplayOrder" },
                values: new object[,]
                {
                    { 1, "Thriller", 1 },
                    { 2, "Sci-Fi", 2 },
                    { 3, "History", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3);
        }
    }
}

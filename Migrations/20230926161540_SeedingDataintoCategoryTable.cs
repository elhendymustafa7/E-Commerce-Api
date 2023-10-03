using E_Commerce_Api.Enums;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce_Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataintoCategoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var categories = CategoryType.CategoryTypeList();
            foreach (var category in categories)
            {
                migrationBuilder.InsertData(
                    table: "Categories",
                    columns: new[] { "Name", "Description" },
                    values: new object[] { category.Name, category.Description });
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}

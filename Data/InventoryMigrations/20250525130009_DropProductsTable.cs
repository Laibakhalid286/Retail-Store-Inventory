using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace retail_store_inventory_2.Data.InventoryMigrations
{
    /// <inheritdoc />
    public partial class DropProductsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

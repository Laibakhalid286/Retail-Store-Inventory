using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace retail_store_inventory_2.Data.InventoryMigrations
{
    /// <inheritdoc />
    public partial class CreateProductsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
        name: "Products",
        columns: table => new
        {
            Id = table.Column<int>(nullable: false)
                .Annotation("SqlServer:Identity", "1, 1"),
            // Include ALL your current columns here:
            Name = table.Column<string>(nullable: false),
            Quantity = table.Column<int>(nullable: false),
            Price = table.Column<int>(nullable: false),
            Category = table.Column<string>(nullable: false),
            ProductCreationDate = table.Column<DateTime>(nullable: false),
            // Add any NEW columns here
            NewColumn = table.Column<string>(nullable: true)
        },
        constraints: table =>
        {
            table.PrimaryKey("PK_Products", x => x.Id);
        });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

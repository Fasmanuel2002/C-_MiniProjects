using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductRestApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPrice = table.Column<float>(type: "real", nullable: false),
                    ProductDiscount = table.Column<float>(type: "real", nullable: false),
                    proType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ProductDescription", "ProductDiscount", "ProductName", "ProductPrice", "proType" },
                values: new object[,]
                {
                    { 1, "Are shoes Mate", 0.2f, "Shoes", 43f, 0 },
                    { 2, "Is massage Mate", 0f, "Massages", 20f, 1 },
                    { 3, "Fuchiball Fuchiball ronaldhino", 0.15f, "football", 15f, 0 },
                    { 4, "Bruh", 0f, "Dont know", 10f, 2 },
                    { 5, "Unix system", 0.3f, "Computer", 250f, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}

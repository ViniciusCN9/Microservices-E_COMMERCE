using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalog.infra.Migrations
{
    public partial class SeedSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Price", "Category" },
                values: new object[] { "1", "ACER I5", 3259m, 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Price", "Category" },
                values: new object[] { "2", "PCGAMER I7", 3649m, 2 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Price", "Category" },
                values: new object[] { "3", "GALAXY S21", 2699m, 3 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Price", "Category" },
                values: new object[] { "4", "VOSTRO 3515", 3648m, 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Price", "Category" },
                values: new object[] { "5", "DELL OPTIPLEX", 1865m, 2 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Price", "Category" },
                values: new object[] { "6", "IPHONE 13", 5486m, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

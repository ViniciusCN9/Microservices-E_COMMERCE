using Microsoft.EntityFrameworkCore.Migrations;

namespace Access.infra.Migrations
{
    public partial class SeedSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Username", "Password", "Email", "Role" },
                values: new object[] { "61c1d6b6-7f93-43fe-b0d5-f2903673b5fb", "admin", "admin", "admin@admin.com", 0 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Username", "Password", "Email", "Role" },
                values: new object[] { "a6dd2dd9-08b3-4d15-a40d-c32bd7031d5e", "user", "user", "user@user.com", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

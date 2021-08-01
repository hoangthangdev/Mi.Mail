using Microsoft.EntityFrameworkCore.Migrations;

namespace MiMailIdentity.Migrations
{
    public partial class updateCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CMT",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sex",
                table: "Customers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CMT",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "Customers");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace MiMailIdentity.Migrations
{
    public partial class UpdateDb7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ListCustomerCategory",
                table: "Campaigns",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sender",
                table: "Campaigns",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderDomain",
                table: "Campaigns",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Campaigns",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ListCustomerCategory",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "Sender",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "SenderDomain",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Campaigns");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace MiMailIdentity.Migrations
{
    public partial class Updatedb972020947 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxMail",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxMail",
                table: "AspNetUsers");
        }
    }
}

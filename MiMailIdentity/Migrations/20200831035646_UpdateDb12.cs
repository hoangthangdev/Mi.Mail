using Microsoft.EntityFrameworkCore.Migrations;

namespace MiMailIdentity.Migrations
{
    public partial class UpdateDb12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "CampaignCategories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "CampaignCategories");
        }
    }
}

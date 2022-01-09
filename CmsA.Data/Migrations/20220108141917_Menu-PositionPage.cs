using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CmsA.Data.Migrations
{
    public partial class MenuPositionPage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Pages",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "Pages");
        }
    }
}

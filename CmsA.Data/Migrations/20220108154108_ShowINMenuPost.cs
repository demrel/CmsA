using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CmsA.Data.Migrations
{
    public partial class ShowINMenuPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ShowInMenu",
                table: "Posts",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShowInMenu",
                table: "Posts");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CmsA.Data.Migrations
{
    public partial class RemoveImageFromPage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Images_AppImageId",
                table: "Pages");

            migrationBuilder.DropIndex(
                name: "IX_Pages_AppImageId",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "AppImageId",
                table: "Pages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppImageId",
                table: "Pages",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pages_AppImageId",
                table: "Pages",
                column: "AppImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Images_AppImageId",
                table: "Pages",
                column: "AppImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

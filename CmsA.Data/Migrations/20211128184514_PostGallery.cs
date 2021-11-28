using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CmsA.Data.Migrations
{
    public partial class PostGallery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partners_LocalizationSets_TitleId",
                table: "Partners");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Images_AppImageId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_AppImageId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Partners_TitleId",
                table: "Partners");

            migrationBuilder.DropColumn(
                name: "AppImageId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "TitleId",
                table: "Partners");

            migrationBuilder.DropColumn(
                name: "ShowInMain",
                table: "Pages");

            migrationBuilder.AddColumn<bool>(
                name: "IsMain",
                table: "Images",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMain",
                table: "Images");

            migrationBuilder.AddColumn<int>(
                name: "AppImageId",
                table: "Posts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TitleId",
                table: "Partners",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "ShowInMain",
                table: "Pages",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AppImageId",
                table: "Posts",
                column: "AppImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Partners_TitleId",
                table: "Partners",
                column: "TitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Partners_LocalizationSets_TitleId",
                table: "Partners",
                column: "TitleId",
                principalTable: "LocalizationSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Images_AppImageId",
                table: "Posts",
                column: "AppImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

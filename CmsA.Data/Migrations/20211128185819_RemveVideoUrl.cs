using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CmsA.Data.Migrations
{
    public partial class RemveVideoUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pages_LocalizationSets_VideoUrlId",
                table: "Pages");

            migrationBuilder.DropIndex(
                name: "IX_Pages_VideoUrlId",
                table: "Pages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Pages_VideoUrlId",
                table: "Pages",
                column: "VideoUrlId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_LocalizationSets_VideoUrlId",
                table: "Pages",
                column: "VideoUrlId",
                principalTable: "LocalizationSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

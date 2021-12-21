using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CmsA.Data.Migrations
{
    public partial class Post : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ParentID",
                table: "Posts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PdfId",
                table: "Posts",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ParentID",
                table: "Posts",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PdfId",
                table: "Posts",
                column: "PdfId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_LocalizationSets_PdfId",
                table: "Posts",
                column: "PdfId",
                principalTable: "LocalizationSets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Posts_ParentID",
                table: "Posts",
                column: "ParentID",
                principalTable: "Posts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_LocalizationSets_PdfId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Posts_ParentID",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_ParentID",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_PdfId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ParentID",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PdfId",
                table: "Posts");
        }
    }
}

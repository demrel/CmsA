using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CmsA.Data.Migrations
{
    public partial class MenuPostPos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_LocalizationSets_PdfId",
                table: "Posts");

            migrationBuilder.AlterColumn<int>(
                name: "PdfId",
                table: "Posts",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuPosition",
                table: "Posts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_LocalizationSets_PdfId",
                table: "Posts",
                column: "PdfId",
                principalTable: "LocalizationSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_LocalizationSets_PdfId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "MenuPosition",
                table: "Posts");

            migrationBuilder.AlterColumn<int>(
                name: "PdfId",
                table: "Posts",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_LocalizationSets_PdfId",
                table: "Posts",
                column: "PdfId",
                principalTable: "LocalizationSets",
                principalColumn: "Id");
        }
    }
}

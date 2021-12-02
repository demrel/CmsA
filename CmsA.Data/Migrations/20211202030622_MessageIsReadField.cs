using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CmsA.Data.Migrations
{
    public partial class MessageIsReadField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MissionVissions_LocalizationSets_MissionId",
                table: "MissionVissions");

            migrationBuilder.DropForeignKey(
                name: "FK_MissionVissions_LocalizationSets_MissionTitleId",
                table: "MissionVissions");

            migrationBuilder.DropForeignKey(
                name: "FK_MissionVissions_LocalizationSets_VissionId",
                table: "MissionVissions");

            migrationBuilder.DropForeignKey(
                name: "FK_MissionVissions_LocalizationSets_VissionTitleId",
                table: "MissionVissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Images_VideoImageId",
                table: "Videos");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_LocalizationSets_DescriptionId",
                table: "Videos");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_LocalizationSets_TitleId",
                table: "Videos");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_LocalizationSets_URlId",
                table: "Videos");

            migrationBuilder.AlterColumn<int>(
                name: "VideoImageId",
                table: "Videos",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "URlId",
                table: "Videos",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TitleId",
                table: "Videos",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DescriptionId",
                table: "Videos",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VissionTitleId",
                table: "MissionVissions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VissionId",
                table: "MissionVissions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MissionTitleId",
                table: "MissionVissions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MissionId",
                table: "MissionVissions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "Messages",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_MissionVissions_LocalizationSets_MissionId",
                table: "MissionVissions",
                column: "MissionId",
                principalTable: "LocalizationSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MissionVissions_LocalizationSets_MissionTitleId",
                table: "MissionVissions",
                column: "MissionTitleId",
                principalTable: "LocalizationSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MissionVissions_LocalizationSets_VissionId",
                table: "MissionVissions",
                column: "VissionId",
                principalTable: "LocalizationSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MissionVissions_LocalizationSets_VissionTitleId",
                table: "MissionVissions",
                column: "VissionTitleId",
                principalTable: "LocalizationSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Images_VideoImageId",
                table: "Videos",
                column: "VideoImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_LocalizationSets_DescriptionId",
                table: "Videos",
                column: "DescriptionId",
                principalTable: "LocalizationSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_LocalizationSets_TitleId",
                table: "Videos",
                column: "TitleId",
                principalTable: "LocalizationSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_LocalizationSets_URlId",
                table: "Videos",
                column: "URlId",
                principalTable: "LocalizationSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MissionVissions_LocalizationSets_MissionId",
                table: "MissionVissions");

            migrationBuilder.DropForeignKey(
                name: "FK_MissionVissions_LocalizationSets_MissionTitleId",
                table: "MissionVissions");

            migrationBuilder.DropForeignKey(
                name: "FK_MissionVissions_LocalizationSets_VissionId",
                table: "MissionVissions");

            migrationBuilder.DropForeignKey(
                name: "FK_MissionVissions_LocalizationSets_VissionTitleId",
                table: "MissionVissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Images_VideoImageId",
                table: "Videos");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_LocalizationSets_DescriptionId",
                table: "Videos");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_LocalizationSets_TitleId",
                table: "Videos");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_LocalizationSets_URlId",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "Messages");

            migrationBuilder.AlterColumn<int>(
                name: "VideoImageId",
                table: "Videos",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "URlId",
                table: "Videos",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "TitleId",
                table: "Videos",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "DescriptionId",
                table: "Videos",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "VissionTitleId",
                table: "MissionVissions",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "VissionId",
                table: "MissionVissions",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "MissionTitleId",
                table: "MissionVissions",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "MissionId",
                table: "MissionVissions",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_MissionVissions_LocalizationSets_MissionId",
                table: "MissionVissions",
                column: "MissionId",
                principalTable: "LocalizationSets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MissionVissions_LocalizationSets_MissionTitleId",
                table: "MissionVissions",
                column: "MissionTitleId",
                principalTable: "LocalizationSets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MissionVissions_LocalizationSets_VissionId",
                table: "MissionVissions",
                column: "VissionId",
                principalTable: "LocalizationSets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MissionVissions_LocalizationSets_VissionTitleId",
                table: "MissionVissions",
                column: "VissionTitleId",
                principalTable: "LocalizationSets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Images_VideoImageId",
                table: "Videos",
                column: "VideoImageId",
                principalTable: "Images",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_LocalizationSets_DescriptionId",
                table: "Videos",
                column: "DescriptionId",
                principalTable: "LocalizationSets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_LocalizationSets_TitleId",
                table: "Videos",
                column: "TitleId",
                principalTable: "LocalizationSets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_LocalizationSets_URlId",
                table: "Videos",
                column: "URlId",
                principalTable: "LocalizationSets",
                principalColumn: "Id");
        }
    }
}

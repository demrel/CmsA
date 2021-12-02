using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CmsA.Data.Migrations
{
    public partial class SitePrefSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MissionVissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MissionTitleId = table.Column<int>(type: "integer", nullable: true),
                    MissionId = table.Column<int>(type: "integer", nullable: true),
                    VissionTitleId = table.Column<int>(type: "integer", nullable: true),
                    VissionId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissionVissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MissionVissions_LocalizationSets_MissionId",
                        column: x => x.MissionId,
                        principalTable: "LocalizationSets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MissionVissions_LocalizationSets_MissionTitleId",
                        column: x => x.MissionTitleId,
                        principalTable: "LocalizationSets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MissionVissions_LocalizationSets_VissionId",
                        column: x => x.VissionId,
                        principalTable: "LocalizationSets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MissionVissions_LocalizationSets_VissionTitleId",
                        column: x => x.VissionTitleId,
                        principalTable: "LocalizationSets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VideoImageId = table.Column<int>(type: "integer", nullable: true),
                    URlId = table.Column<int>(type: "integer", nullable: true),
                    TitleId = table.Column<int>(type: "integer", nullable: true),
                    DescriptionId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Videos_Images_VideoImageId",
                        column: x => x.VideoImageId,
                        principalTable: "Images",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Videos_LocalizationSets_DescriptionId",
                        column: x => x.DescriptionId,
                        principalTable: "LocalizationSets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Videos_LocalizationSets_TitleId",
                        column: x => x.TitleId,
                        principalTable: "LocalizationSets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Videos_LocalizationSets_URlId",
                        column: x => x.URlId,
                        principalTable: "LocalizationSets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MissionVissions_MissionId",
                table: "MissionVissions",
                column: "MissionId");

            migrationBuilder.CreateIndex(
                name: "IX_MissionVissions_MissionTitleId",
                table: "MissionVissions",
                column: "MissionTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_MissionVissions_VissionId",
                table: "MissionVissions",
                column: "VissionId");

            migrationBuilder.CreateIndex(
                name: "IX_MissionVissions_VissionTitleId",
                table: "MissionVissions",
                column: "VissionTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_DescriptionId",
                table: "Videos",
                column: "DescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_TitleId",
                table: "Videos",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_URlId",
                table: "Videos",
                column: "URlId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_VideoImageId",
                table: "Videos",
                column: "VideoImageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MissionVissions");

            migrationBuilder.DropTable(
                name: "Videos");
        }
    }
}

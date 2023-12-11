using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tda_proj.Migrations
{
    /// <inheritdoc />
    public partial class TitlesAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "titleAfter",
                table: "Lectors");

            migrationBuilder.DropColumn(
                name: "titleBefore",
                table: "Lectors");

            migrationBuilder.CreateTable(
                name: "TitlesAfter",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LectorUUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TitlesAfter", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TitlesAfter_Lectors_LectorUUID",
                        column: x => x.LectorUUID,
                        principalTable: "Lectors",
                        principalColumn: "UUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TitlesBefore",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LectorUUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TitlesBefore", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TitlesBefore_Lectors_LectorUUID",
                        column: x => x.LectorUUID,
                        principalTable: "Lectors",
                        principalColumn: "UUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TitlesAfter_LectorUUID",
                table: "TitlesAfter",
                column: "LectorUUID");

            migrationBuilder.CreateIndex(
                name: "IX_TitlesBefore_LectorUUID",
                table: "TitlesBefore",
                column: "LectorUUID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TitlesAfter");

            migrationBuilder.DropTable(
                name: "TitlesBefore");

            migrationBuilder.AddColumn<string>(
                name: "titleAfter",
                table: "Lectors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "titleBefore",
                table: "Lectors",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

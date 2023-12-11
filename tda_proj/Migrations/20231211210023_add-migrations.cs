using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tda_proj.Migrations
{
    /// <inheritdoc />
    public partial class addmigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lectors",
                columns: table => new
                {
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    middleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pricePerHour = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectors", x => x.UUID);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagUUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagUUID);
                });

            migrationBuilder.CreateTable(
                name: "Claims",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LectorUUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Claims_Lectors_LectorUUID",
                        column: x => x.LectorUUID,
                        principalTable: "Lectors",
                        principalColumn: "UUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LectorUUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Contacts_Lectors_LectorUUID",
                        column: x => x.LectorUUID,
                        principalTable: "Lectors",
                        principalColumn: "UUID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "LectorTags",
                columns: table => new
                {
                    LectorUUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LectorTagUUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LectorTags", x => new { x.LectorTagUUID, x.LectorUUID });
                    table.ForeignKey(
                        name: "FK_LectorTags_Lectors_LectorUUID",
                        column: x => x.LectorUUID,
                        principalTable: "Lectors",
                        principalColumn: "UUID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LectorTags_Tags_TagUUID",
                        column: x => x.LectorTagUUID,
                        principalTable: "Tags",
                        principalColumn: "TagUUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Emails_Contacts_ContactID",
                        column: x => x.ContactID,
                        principalTable: "Contacts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TelNumbers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TelNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelNumbers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TelNumbers_Contacts_ContactID",
                        column: x => x.ContactID,
                        principalTable: "Contacts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Claims_LectorUUID",
                table: "Claims",
                column: "LectorUUID");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_LectorUUID",
                table: "Contacts",
                column: "LectorUUID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Emails_ContactID",
                table: "Emails",
                column: "ContactID");

            migrationBuilder.CreateIndex(
                name: "IX_LectorTags_LectorUUID",
                table: "LectorTags",
                column: "LectorUUID");

            migrationBuilder.CreateIndex(
                name: "IX_TelNumbers_ContactID",
                table: "TelNumbers",
                column: "ContactID");

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
                name: "Claims");

            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "LectorTags");

            migrationBuilder.DropTable(
                name: "TelNumbers");

            migrationBuilder.DropTable(
                name: "TitlesAfter");

            migrationBuilder.DropTable(
                name: "TitlesBefore");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Lectors");
        }
    }
}

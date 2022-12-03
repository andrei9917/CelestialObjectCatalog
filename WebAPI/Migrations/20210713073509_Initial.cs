using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiscoverySourceType",
                columns: table => new
                {
                    DiscoverySourceTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscoverySourceType", x => x.DiscoverySourceTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ObjectType",
                columns: table => new
                {
                    ObjectTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectType", x => x.ObjectTypeId);
                });

            migrationBuilder.CreateTable(
                name: "DiscoverySource",
                columns: table => new
                {
                    DiscoverySourceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstablishmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StateOwner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscoverySourceTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscoverySource", x => x.DiscoverySourceId);
                    table.ForeignKey(
                        name: "FK_DiscoverySource_DiscoverySourceType_DiscoverySourceTypeId",
                        column: x => x.DiscoverySourceTypeId,
                        principalTable: "DiscoverySourceType",
                        principalColumn: "DiscoverySourceTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CelestialObject",
                columns: table => new
                {
                    CelestialObjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mass = table.Column<double>(type: "float", nullable: false),
                    EquatorialDiameter = table.Column<double>(type: "float", nullable: false),
                    SurfaceTemperature = table.Column<int>(type: "int", nullable: false),
                    DiscoveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiscoverySourceId = table.Column<int>(type: "int", nullable: false),
                    ObjectTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CelestialObject", x => x.CelestialObjectId);
                    table.ForeignKey(
                        name: "FK_CelestialObject_DiscoverySource_DiscoverySourceId",
                        column: x => x.DiscoverySourceId,
                        principalTable: "DiscoverySource",
                        principalColumn: "DiscoverySourceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CelestialObject_ObjectType_ObjectTypeId",
                        column: x => x.ObjectTypeId,
                        principalTable: "ObjectType",
                        principalColumn: "ObjectTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DiscoverySourceType",
                columns: new[] { "DiscoverySourceTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "Space telescope" },
                    { 2, "Ground telescope" },
                    { 3, "Other" }
                });

            migrationBuilder.InsertData(
                table: "ObjectType",
                columns: new[] { "ObjectTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "Planet" },
                    { 2, "Star" },
                    { 3, "Black Hole" },
                    { 4, "Unknown" }
                });

            migrationBuilder.InsertData(
                table: "DiscoverySource",
                columns: new[] { "DiscoverySourceId", "DiscoverySourceTypeId", "EstablishmentDate", "Name", "StateOwner" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1994, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hubble Space Telescope", "USA" },
                    { 4, 1, new DateTime(2013, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "NEOSSat", "Canada" },
                    { 5, 1, new DateTime(2015, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Astrosat", "India" },
                    { 6, 1, new DateTime(2011, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spektr-R", "Russia" },
                    { 2, 2, new DateTime(1960, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arecibo Observatory", "Puerto Rico" },
                    { 3, 2, new DateTime(1839, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pulkovo Observatory", "Russia" },
                    { 7, 2, new DateTime(2011, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Subaru Telescope", "Japan" },
                    { 8, 2, new DateTime(2011, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ALMA", "Chile" },
                    { 9, 2, new DateTime(1993, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Keck", "USA" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CelestialObject_DiscoverySourceId",
                table: "CelestialObject",
                column: "DiscoverySourceId");

            migrationBuilder.CreateIndex(
                name: "IX_CelestialObject_ObjectTypeId",
                table: "CelestialObject",
                column: "ObjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscoverySource_DiscoverySourceTypeId",
                table: "DiscoverySource",
                column: "DiscoverySourceTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CelestialObject");

            migrationBuilder.DropTable(
                name: "DiscoverySource");

            migrationBuilder.DropTable(
                name: "ObjectType");

            migrationBuilder.DropTable(
                name: "DiscoverySourceType");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zaitseva_Backend.Migrations
{
    /// <inheritdoc />
    public partial class Manytomany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agency",
                columns: table => new
                {
                    AgencyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgencyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelephoneNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agency", x => x.AgencyId);
                });

            migrationBuilder.CreateTable(
                name: "Tour",
                columns: table => new
                {
                    TourId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TourName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TourDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TourType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TourCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TourDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TourPriсe = table.Column<double>(type: "float", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tour", x => x.TourId);
                });

            migrationBuilder.CreateTable(
                name: "AgencyTour",
                columns: table => new
                {
                    AgencyTourAgencyId = table.Column<int>(type: "int", nullable: false),
                    ToursTourId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgencyTour", x => new { x.AgencyTourAgencyId, x.ToursTourId });
                    table.ForeignKey(
                        name: "FK_AgencyTour_Agency_AgencyTourAgencyId",
                        column: x => x.AgencyTourAgencyId,
                        principalTable: "Agency",
                        principalColumn: "AgencyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgencyTour_Tour_ToursTourId",
                        column: x => x.ToursTourId,
                        principalTable: "Tour",
                        principalColumn: "TourId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgencyTour_ToursTourId",
                table: "AgencyTour",
                column: "ToursTourId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgencyTour");

            migrationBuilder.DropTable(
                name: "Agency");

            migrationBuilder.DropTable(
                name: "Tour");
        }
    }
}

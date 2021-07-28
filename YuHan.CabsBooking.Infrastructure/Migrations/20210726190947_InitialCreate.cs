using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YuHan.CabsBooking.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CabTypes",
                columns: table => new
                {
                    CabTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CabTypeName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabTypes", x => x.CabTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    PlaceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaceName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.PlaceId);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BookingDate = table.Column<DateTime>(type: "date", nullable: true),
                    BookingTime = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    FromPlaceId = table.Column<int>(type: "int", nullable: true),
                    ToPlaceId = table.Column<int>(type: "int", nullable: true),
                    PickUpAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Landmark = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PickupDate = table.Column<DateTime>(type: "date", nullable: true),
                    PickupTime = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    CabTypeId = table.Column<int>(type: "int", nullable: true),
                    ContactNo = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_CabTypes_CabTypeId",
                        column: x => x.CabTypeId,
                        principalTable: "CabTypes",
                        principalColumn: "CabTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_Places_FromPlaceId",
                        column: x => x.FromPlaceId,
                        principalTable: "Places",
                        principalColumn: "PlaceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_Places_ToPlaceId",
                        column: x => x.ToPlaceId,
                        principalTable: "Places",
                        principalColumn: "PlaceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bookingw history",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BookingDate = table.Column<DateTime>(type: "date", nullable: true),
                    BookingTime = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    FromPlaceId = table.Column<int>(type: "int", nullable: true),
                    ToPlaceId = table.Column<int>(type: "int", nullable: true),
                    PickUpAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Landmark = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PickupDate = table.Column<DateTime>(type: "date", nullable: true),
                    PickupTime = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    CabTypeId = table.Column<int>(type: "int", nullable: true),
                    ContactNo = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CompTime = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Charge = table.Column<decimal>(type: "money", nullable: true),
                    Feedback = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookingw history", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookingw history_CabTypes_CabTypeId",
                        column: x => x.CabTypeId,
                        principalTable: "CabTypes",
                        principalColumn: "CabTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookingw history_Places_FromPlaceId",
                        column: x => x.FromPlaceId,
                        principalTable: "Places",
                        principalColumn: "PlaceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookingw history_Places_ToPlaceId",
                        column: x => x.ToPlaceId,
                        principalTable: "Places",
                        principalColumn: "PlaceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CabTypeId",
                table: "Bookings",
                column: "CabTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_FromPlaceId",
                table: "Bookings",
                column: "FromPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ToPlaceId",
                table: "Bookings",
                column: "ToPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookingw history_CabTypeId",
                table: "Bookingw history",
                column: "CabTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookingw history_FromPlaceId",
                table: "Bookingw history",
                column: "FromPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookingw history_ToPlaceId",
                table: "Bookingw history",
                column: "ToPlaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Bookingw history");

            migrationBuilder.DropTable(
                name: "CabTypes");

            migrationBuilder.DropTable(
                name: "Places");
        }
    }
}

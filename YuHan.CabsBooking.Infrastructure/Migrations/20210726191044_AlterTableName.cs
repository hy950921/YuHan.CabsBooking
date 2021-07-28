using Microsoft.EntityFrameworkCore.Migrations;

namespace YuHan.CabsBooking.Infrastructure.Migrations
{
    public partial class AlterTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookingw history_CabTypes_CabTypeId",
                table: "Bookingw history");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookingw history_Places_FromPlaceId",
                table: "Bookingw history");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookingw history_Places_ToPlaceId",
                table: "Bookingw history");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookingw history",
                table: "Bookingw history");

            migrationBuilder.RenameTable(
                name: "Bookingw history",
                newName: "Bookings history");

            migrationBuilder.RenameIndex(
                name: "IX_Bookingw history_ToPlaceId",
                table: "Bookings history",
                newName: "IX_Bookings history_ToPlaceId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookingw history_FromPlaceId",
                table: "Bookings history",
                newName: "IX_Bookings history_FromPlaceId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookingw history_CabTypeId",
                table: "Bookings history",
                newName: "IX_Bookings history_CabTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookings history",
                table: "Bookings history",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings history_CabTypes_CabTypeId",
                table: "Bookings history",
                column: "CabTypeId",
                principalTable: "CabTypes",
                principalColumn: "CabTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings history_Places_FromPlaceId",
                table: "Bookings history",
                column: "FromPlaceId",
                principalTable: "Places",
                principalColumn: "PlaceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings history_Places_ToPlaceId",
                table: "Bookings history",
                column: "ToPlaceId",
                principalTable: "Places",
                principalColumn: "PlaceId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings history_CabTypes_CabTypeId",
                table: "Bookings history");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings history_Places_FromPlaceId",
                table: "Bookings history");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings history_Places_ToPlaceId",
                table: "Bookings history");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookings history",
                table: "Bookings history");

            migrationBuilder.RenameTable(
                name: "Bookings history",
                newName: "Bookingw history");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings history_ToPlaceId",
                table: "Bookingw history",
                newName: "IX_Bookingw history_ToPlaceId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings history_FromPlaceId",
                table: "Bookingw history",
                newName: "IX_Bookingw history_FromPlaceId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings history_CabTypeId",
                table: "Bookingw history",
                newName: "IX_Bookingw history_CabTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookingw history",
                table: "Bookingw history",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookingw history_CabTypes_CabTypeId",
                table: "Bookingw history",
                column: "CabTypeId",
                principalTable: "CabTypes",
                principalColumn: "CabTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookingw history_Places_FromPlaceId",
                table: "Bookingw history",
                column: "FromPlaceId",
                principalTable: "Places",
                principalColumn: "PlaceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookingw history_Places_ToPlaceId",
                table: "Bookingw history",
                column: "ToPlaceId",
                principalTable: "Places",
                principalColumn: "PlaceId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

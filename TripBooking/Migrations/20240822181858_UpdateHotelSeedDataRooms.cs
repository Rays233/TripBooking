using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TripBooking.Migrations
{
    /// <inheritdoc />
    public partial class UpdateHotelSeedDataRooms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "Description", "HotelId", "Name", "Price" },
                values: new object[,]
                {
                    { 5, "Room with a stunning ocean view.", 3, "Beachfront Room", 200m },
                    { 6, "Modern room with panoramic city views.", 4, "City View Room", 180m },
                    { 7, "Luxurious suite with sea views.", 5, "Mediterranean Suite", 250m },
                    { 8, "Comfortable room with mountain vistas.", 6, "Mountain View Room", 220m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 8);
        }
    }
}

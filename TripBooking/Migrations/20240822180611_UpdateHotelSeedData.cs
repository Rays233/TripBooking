using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TripBooking.Migrations
{
    /// <inheritdoc />
    public partial class UpdateHotelSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Antique beachside hotel", "Hotel Valencia" });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Modern oasis with vibrant city life nearby", "Hotel Malageuta" });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "City", "Country", "Description", "Name" },
                values: new object[,]
                {
                    { 3, "Barcelona", "Spain", "Luxury beachside hotel.", "Hotel Playa Barcelona" },
                    { 4, "Barcelona", "Spain", "Modern hotel with city views.", "Hotel Sol Barcelona" },
                    { 5, "Marbella", "Spain", "Charming hotel near the Mediterranean.", "Hotel Costa del Sol" },
                    { 6, "Granada", "Spain", "Cozy mountain retreat with stunning views.", "Hotel Sierra Nevada" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Description for Hotel One", "Hotel One" });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "HotelId",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Description for Hotel Two", "Hotel Two" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TripBooking.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCustomerRelationshipFromBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Customers_CustomerId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_CustomerId",
                table: "Bookings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CustomerId",
                table: "Bookings",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Customers_CustomerId",
                table: "Bookings",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId");
        }
    }
}

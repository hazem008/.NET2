using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastrecture.Migrations
{
    /// <inheritdoc />
    public partial class porteuse2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_MyFlight_FlightId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Passangers_passengerPassportNumber",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_FlightId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_passengerPassportNumber",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "FlightId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "passengerPassportNumber",
                table: "Ticket");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_FlightFK",
                table: "Ticket",
                column: "FlightFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_MyFlight_FlightFK",
                table: "Ticket",
                column: "FlightFK",
                principalTable: "MyFlight",
                principalColumn: "FlightId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Passangers_PassangerFK",
                table: "Ticket",
                column: "PassangerFK",
                principalTable: "Passangers",
                principalColumn: "PassportNumber",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_MyFlight_FlightFK",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Passangers_PassangerFK",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_FlightFK",
                table: "Ticket");

            migrationBuilder.AddColumn<int>(
                name: "FlightId",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "passengerPassportNumber",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_FlightId",
                table: "Ticket",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_passengerPassportNumber",
                table: "Ticket",
                column: "passengerPassportNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_MyFlight_FlightId",
                table: "Ticket",
                column: "FlightId",
                principalTable: "MyFlight",
                principalColumn: "FlightId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Passangers_passengerPassportNumber",
                table: "Ticket",
                column: "passengerPassportNumber",
                principalTable: "Passangers",
                principalColumn: "PassportNumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

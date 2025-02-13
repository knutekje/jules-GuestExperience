using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuestExperience.Migrations
{
    /// <inheritdoc />
    public partial class intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "guest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    first_name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    last_name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    phone_number = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    address = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    city = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    nationality = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "room",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    room_number = table.Column<int>(type: "INTEGER", nullable: false),
                    room_type = table.Column<int>(type: "INTEGER", nullable: false),
                    capacity = table.Column<int>(type: "INTEGER", nullable: false),
                    status = table.Column<int>(type: "INTEGER", nullable: false),
                    price_id = table.Column<int>(type: "INTEGER", nullable: false),
                    floor = table.Column<int>(type: "INTEGER", nullable: false),
                    extra_bed = table.Column<bool>(type: "INTEGER", nullable: false),
                    last_maintained = table.Column<DateTime>(type: "TEXT", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_room", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "reservation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GuestId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reservation_guest_GuestId",
                        column: x => x.GuestId,
                        principalTable: "guest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "booking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    check_in = table.Column<DateTime>(type: "datetime", nullable: false),
                    check_out = table.Column<DateTime>(type: "datetime", nullable: false),
                    ReservationId = table.Column<int>(type: "INTEGER", nullable: false),
                    RoomId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_booking_reservation_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "reservation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_booking_room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_booking_ReservationId",
                table: "booking",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_booking_RoomId",
                table: "booking",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_reservation_GuestId",
                table: "reservation",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_room_room_number",
                table: "room",
                column: "room_number",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "booking");

            migrationBuilder.DropTable(
                name: "reservation");

            migrationBuilder.DropTable(
                name: "room");

            migrationBuilder.DropTable(
                name: "guest");
        }
    }
}

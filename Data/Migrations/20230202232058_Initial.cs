using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinRent = table.Column<int>(type: "int", nullable: false),
                    MaxRent = table.Column<int>(type: "int", nullable: false),
                    Apartment = table.Column<bool>(type: "bit", nullable: false),
                    Corridor = table.Column<bool>(type: "bit", nullable: false),
                    MaxRooms = table.Column<int>(type: "int", nullable: false),
                    MinRooms = table.Column<int>(type: "int", nullable: false),
                    MinFloor = table.Column<int>(type: "int", nullable: false),
                    MaxRentalPeriods = table.Column<int>(type: "int", nullable: false),
                    NovischPriority = table.Column<bool>(type: "bit", nullable: false),
                    FurnitureIncluded = table.Column<bool>(type: "bit", nullable: false),
                    MinSize = table.Column<double>(type: "float", nullable: false),
                    MaxSize = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UnitType = table.Column<int>(type: "int", nullable: false),
                    Rooms = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<int>(type: "int", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<double>(type: "float", nullable: false),
                    RentalPeriods = table.Column<int>(type: "int", nullable: false),
                    ReservationDeadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NovishPriority = table.Column<bool>(type: "bit", nullable: false),
                    Rent = table.Column<int>(type: "int", nullable: false),
                    FurnitureIncluded = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AreaNotification",
                columns: table => new
                {
                    AreasId = table.Column<int>(type: "int", nullable: false),
                    NotificationsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaNotification", x => new { x.AreasId, x.NotificationsId });
                    table.ForeignKey(
                        name: "FK_AreaNotification_Areas_AreasId",
                        column: x => x.AreasId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AreaNotification_Notifications_NotificationsId",
                        column: x => x.NotificationsId,
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AreaNotification_NotificationsId",
                table: "AreaNotification",
                column: "NotificationsId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_Name",
                table: "Areas",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Units_ProductId",
                table: "Units",
                column: "ProductId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AreaNotification");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Notifications");
        }
    }
}

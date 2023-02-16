using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Addeddistancefromcentrum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "DistanceFromCentrum",
                table: "Notifications",
                type: "float",
                nullable: false,
                defaultValue: 100.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DistanceFromCentrum",
                table: "Notifications");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace projectccbs.Migrations
{
    public partial class appointmentupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "VolledigeNaam",
                table: "Appointments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdminId",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VolledigeNaam",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

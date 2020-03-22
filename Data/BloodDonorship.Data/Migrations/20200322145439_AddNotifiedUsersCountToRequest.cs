using Microsoft.EntityFrameworkCore.Migrations;

namespace BloodDonorship.Data.Migrations
{
    public partial class AddNotifiedUsersCountToRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NotifiedUsersCount",
                table: "Requests",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotifiedUsersCount",
                table: "Requests");
        }
    }
}

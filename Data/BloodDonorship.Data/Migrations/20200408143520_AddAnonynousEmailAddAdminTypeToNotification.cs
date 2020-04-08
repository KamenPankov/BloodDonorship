using Microsoft.EntityFrameworkCore.Migrations;

namespace BloodDonorship.Data.Migrations
{
    public partial class AddAnonynousEmailAddAdminTypeToNotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AnonymousEmail",
                table: "Notifications",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnonymousEmail",
                table: "Notifications");
        }
    }
}

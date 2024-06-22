using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Karma.Data.Migrations
{
    public partial class Subscribe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsApproved",
                table: "Subscribers",
                newName: "Approved");

            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "Subscribers",
                newName: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Approved",
                table: "Subscribers",
                newName: "IsApproved");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Subscribers",
                newName: "EmailAddress");
        }
    }
}

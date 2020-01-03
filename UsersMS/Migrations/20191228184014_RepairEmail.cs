using Microsoft.EntityFrameworkCore.Migrations;

namespace UsersMS.Migrations
{
    public partial class RepairEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "email");
        }
    }
}

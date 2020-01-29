using Microsoft.EntityFrameworkCore.Migrations;

namespace UsersMS.Migrations
{
    public partial class DeleteUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersDb",
                table: "UsersDb");

            migrationBuilder.RenameTable(
                name: "UsersDb",
                newName: "User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "UsersDb");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersDb",
                table: "UsersDb",
                column: "Id");
        }
    }
}

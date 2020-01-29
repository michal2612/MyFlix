using Microsoft.EntityFrameworkCore.Migrations;

namespace UsersMS.Migrations
{
    public partial class GoogleCloudDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "UsersDb");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersDb",
                table: "UsersDb",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersDb",
                table: "UsersDb");

            migrationBuilder.RenameTable(
                name: "UsersDb",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");
        }
    }
}

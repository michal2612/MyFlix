using Microsoft.EntityFrameworkCore.Migrations;

namespace BillingMS.Migrations
{
    public partial class GoogleCloudInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CreditCards",
                table: "CreditCards");

            migrationBuilder.RenameTable(
                name: "CreditCards",
                newName: "CreditCard");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CreditCard",
                table: "CreditCard",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CreditCard",
                table: "CreditCard");

            migrationBuilder.RenameTable(
                name: "CreditCard",
                newName: "CreditCards");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CreditCards",
                table: "CreditCards",
                column: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesSearchingMicroservice.Migrations
{
    public partial class GoogleInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SearchMovies",
                table: "SearchMovies");

            migrationBuilder.RenameTable(
                name: "SearchMovies",
                newName: "SearchMovie");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SearchMovie",
                table: "SearchMovie",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SearchMovie",
                table: "SearchMovie");

            migrationBuilder.RenameTable(
                name: "SearchMovie",
                newName: "SearchMovies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SearchMovies",
                table: "SearchMovies",
                column: "Id");
        }
    }
}

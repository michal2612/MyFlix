using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesVotingMicroservice.Migrations
{
    public partial class VotingDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieOpinions",
                table: "MovieOpinions");

            migrationBuilder.RenameTable(
                name: "MovieOpinions",
                newName: "MovieOpinion");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieOpinion",
                table: "MovieOpinion",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieOpinion",
                table: "MovieOpinion");

            migrationBuilder.RenameTable(
                name: "MovieOpinion",
                newName: "MovieOpinions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieOpinions",
                table: "MovieOpinions",
                column: "Id");
        }
    }
}

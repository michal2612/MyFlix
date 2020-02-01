using Microsoft.EntityFrameworkCore.Migrations;

namespace PlaylistsMicroservice.Migrations
{
    public partial class GoogleCloudInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Playlists",
                table: "Playlists");

            migrationBuilder.DropColumn(
                name: "MoviesIds",
                table: "Playlists");

            migrationBuilder.RenameTable(
                name: "Playlists",
                newName: "Playlist");

            migrationBuilder.RenameColumn(
                name: "PlaylistName",
                table: "Playlist",
                newName: "MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Playlist",
                table: "Playlist",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Playlist",
                table: "Playlist");

            migrationBuilder.RenameTable(
                name: "Playlist",
                newName: "Playlists");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "Playlists",
                newName: "PlaylistName");

            migrationBuilder.AddColumn<string>(
                name: "MoviesIds",
                table: "Playlists",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Playlists",
                table: "Playlists",
                column: "Id");
        }
    }
}

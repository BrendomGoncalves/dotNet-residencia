using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcMovie.Migrations
{
    /// <inheritdoc />
    public partial class ConfigRelational : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtistMovie_Artist_ArtistsArtistId",
                table: "ArtistMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistMovie_Movie_MoviesMovieId",
                table: "ArtistMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArtistMovie",
                table: "ArtistMovie");

            migrationBuilder.RenameTable(
                name: "ArtistMovie",
                newName: "MovieArtists");

            migrationBuilder.RenameIndex(
                name: "IX_ArtistMovie_MoviesMovieId",
                table: "MovieArtists",
                newName: "IX_MovieArtists_MoviesMovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieArtists",
                table: "MovieArtists",
                columns: new[] { "ArtistsArtistId", "MoviesMovieId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MovieArtists_Artist_ArtistsArtistId",
                table: "MovieArtists",
                column: "ArtistsArtistId",
                principalTable: "Artist",
                principalColumn: "ArtistId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieArtists_Movie_MoviesMovieId",
                table: "MovieArtists",
                column: "MoviesMovieId",
                principalTable: "Movie",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieArtists_Artist_ArtistsArtistId",
                table: "MovieArtists");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieArtists_Movie_MoviesMovieId",
                table: "MovieArtists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieArtists",
                table: "MovieArtists");

            migrationBuilder.RenameTable(
                name: "MovieArtists",
                newName: "ArtistMovie");

            migrationBuilder.RenameIndex(
                name: "IX_MovieArtists_MoviesMovieId",
                table: "ArtistMovie",
                newName: "IX_ArtistMovie_MoviesMovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArtistMovie",
                table: "ArtistMovie",
                columns: new[] { "ArtistsArtistId", "MoviesMovieId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistMovie_Artist_ArtistsArtistId",
                table: "ArtistMovie",
                column: "ArtistsArtistId",
                principalTable: "Artist",
                principalColumn: "ArtistId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistMovie_Movie_MoviesMovieId",
                table: "ArtistMovie",
                column: "MoviesMovieId",
                principalTable: "Movie",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

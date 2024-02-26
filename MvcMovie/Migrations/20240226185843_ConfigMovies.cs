using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcMovie.Migrations
{
    /// <inheritdoc />
    public partial class ConfigMovies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Artist_ArtistId",
                table: "Movie");

            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Studio_StudioId",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Movie_ArtistId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "Movie");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Movie",
                newName: "MovieId");

            migrationBuilder.AlterColumn<int>(
                name: "StudioId",
                table: "Movie",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ArtistMovie",
                columns: table => new
                {
                    ArtistsArtistId = table.Column<int>(type: "int", nullable: false),
                    MoviesMovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistMovie", x => new { x.ArtistsArtistId, x.MoviesMovieId });
                    table.ForeignKey(
                        name: "FK_ArtistMovie_Artist_ArtistsArtistId",
                        column: x => x.ArtistsArtistId,
                        principalTable: "Artist",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistMovie_Movie_MoviesMovieId",
                        column: x => x.MoviesMovieId,
                        principalTable: "Movie",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistMovie_MoviesMovieId",
                table: "ArtistMovie",
                column: "MoviesMovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Studio_StudioId",
                table: "Movie",
                column: "StudioId",
                principalTable: "Studio",
                principalColumn: "StudioId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Studio_StudioId",
                table: "Movie");

            migrationBuilder.DropTable(
                name: "ArtistMovie");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "Movie",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "StudioId",
                table: "Movie",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "Movie",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movie_ArtistId",
                table: "Movie",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Artist_ArtistId",
                table: "Movie",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Studio_StudioId",
                table: "Movie",
                column: "StudioId",
                principalTable: "Studio",
                principalColumn: "StudioId");
        }
    }
}

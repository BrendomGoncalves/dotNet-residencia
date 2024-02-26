using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcMovie.Migrations
{
    /// <inheritdoc />
    public partial class CreateStudioAndArtist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "Movie",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudioId",
                table: "Movie",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Bio = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Site = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.ArtistId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Studio",
                columns: table => new
                {
                    StudioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Country = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Site = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studio", x => x.StudioId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_ArtistId",
                table: "Movie",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_StudioId",
                table: "Movie",
                column: "StudioId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Artist_ArtistId",
                table: "Movie");

            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Studio_StudioId",
                table: "Movie");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropTable(
                name: "Studio");

            migrationBuilder.DropIndex(
                name: "IX_Movie_ArtistId",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Movie_StudioId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "StudioId",
                table: "Movie");
        }
    }
}

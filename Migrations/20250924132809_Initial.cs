using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlbumListUnitProject.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    ArtistID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.ArtistID);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreID);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    AlbumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlbumName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlbumDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlbumRating = table.Column<int>(type: "int", nullable: false),
                    ArtistID = table.Column<int>(type: "int", nullable: false),
                    GenreID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.AlbumId);
                    table.ForeignKey(
                        name: "FK_Albums_Artists_ArtistID",
                        column: x => x.ArtistID,
                        principalTable: "Artists",
                        principalColumn: "ArtistID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Albums_Genres_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genres",
                        principalColumn: "GenreID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "ArtistID", "ArtistName" },
                values: new object[,]
                {
                    { 1, "Mac Miller" },
                    { 2, "SZA" },
                    { 3, "Arctic Monkeys" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreID", "GenreName" },
                values: new object[,]
                {
                    { 1, "Rap" },
                    { 2, "RnB" },
                    { 3, "Rock" },
                    { 4, "EDM" },
                    { 5, "Pop" },
                    { 6, "Country" }
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "AlbumId", "AlbumDescription", "AlbumName", "AlbumRating", "ArtistID", "GenreID" },
                values: new object[,]
                {
                    { 1, "The last album made before his untimley death. It talked about his mental health from when his career started to now", "Swimming", 9, 1, 1 },
                    { 2, "I havn't listened to the whole album, but I love alot of the tracks on this album", "SOS", 8, 2, 2 },
                    { 3, "I love all the tracks in this one, but do I wanna know takes the cake.", "AM", 10, 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_ArtistID",
                table: "Albums",
                column: "ArtistID");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_GenreID",
                table: "Albums",
                column: "GenreID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}

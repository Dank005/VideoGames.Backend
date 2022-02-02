using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoGames.Persistence.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameGenres",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameGenres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VideoGames",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeveloperStudio = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoGames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VideoGame_Genre",
                columns: table => new
                {
                    VideoGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameGenreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoGame_Genre", x => new { x.VideoGameId, x.GameGenreId });
                    table.ForeignKey(
                        name: "FK_VideoGame_Genre_GameGenres_GameGenreId",
                        column: x => x.GameGenreId,
                        principalTable: "GameGenres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoGame_Genre_VideoGames_VideoGameId",
                        column: x => x.VideoGameId,
                        principalTable: "VideoGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VideoGame_Genre_GameGenreId",
                table: "VideoGame_Genre",
                column: "GameGenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VideoGame_Genre");

            migrationBuilder.DropTable(
                name: "GameGenres");

            migrationBuilder.DropTable(
                name: "VideoGames");
        }
    }
}

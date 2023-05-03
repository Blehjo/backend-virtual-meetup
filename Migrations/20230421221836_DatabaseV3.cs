using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace planetnineserver.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MoonCommentId",
                table: "Favorite",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlanetCommentId",
                table: "Favorite",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MoonComment",
                columns: table => new
                {
                    MoonCommentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CommentValue = table.Column<string>(type: "TEXT", nullable: false),
                    MediaLink = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    MoonId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoonComment", x => x.MoonCommentId);
                    table.ForeignKey(
                        name: "FK_MoonComment_Moon_MoonId",
                        column: x => x.MoonId,
                        principalTable: "Moon",
                        principalColumn: "MoonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoonComment_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanetComment",
                columns: table => new
                {
                    PlanetCommentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CommentValue = table.Column<string>(type: "TEXT", nullable: false),
                    MediaLink = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    PlanetId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanetComment", x => x.PlanetCommentId);
                    table.ForeignKey(
                        name: "FK_PlanetComment_Planet_PlanetId",
                        column: x => x.PlanetId,
                        principalTable: "Planet",
                        principalColumn: "PlanetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanetComment_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favorite_MoonCommentId",
                table: "Favorite",
                column: "MoonCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorite_PlanetCommentId",
                table: "Favorite",
                column: "PlanetCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_MoonComment_MoonId",
                table: "MoonComment",
                column: "MoonId");

            migrationBuilder.CreateIndex(
                name: "IX_MoonComment_UserId",
                table: "MoonComment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanetComment_PlanetId",
                table: "PlanetComment",
                column: "PlanetId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanetComment_UserId",
                table: "PlanetComment",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorite_MoonComment_MoonCommentId",
                table: "Favorite",
                column: "MoonCommentId",
                principalTable: "MoonComment",
                principalColumn: "MoonCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorite_PlanetComment_PlanetCommentId",
                table: "Favorite",
                column: "PlanetCommentId",
                principalTable: "PlanetComment",
                principalColumn: "PlanetCommentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorite_MoonComment_MoonCommentId",
                table: "Favorite");

            migrationBuilder.DropForeignKey(
                name: "FK_Favorite_PlanetComment_PlanetCommentId",
                table: "Favorite");

            migrationBuilder.DropTable(
                name: "MoonComment");

            migrationBuilder.DropTable(
                name: "PlanetComment");

            migrationBuilder.DropIndex(
                name: "IX_Favorite_MoonCommentId",
                table: "Favorite");

            migrationBuilder.DropIndex(
                name: "IX_Favorite_PlanetCommentId",
                table: "Favorite");

            migrationBuilder.DropColumn(
                name: "MoonCommentId",
                table: "Favorite");

            migrationBuilder.DropColumn(
                name: "PlanetCommentId",
                table: "Favorite");
        }
    }
}

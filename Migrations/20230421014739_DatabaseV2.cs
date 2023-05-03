using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace planetnineserver.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChatCommentId",
                table: "Favorite",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Favorite_ChatCommentId",
                table: "Favorite",
                column: "ChatCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorite_ChatComments_ChatCommentId",
                table: "Favorite",
                column: "ChatCommentId",
                principalTable: "ChatComments",
                principalColumn: "ChatCommentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorite_ChatComments_ChatCommentId",
                table: "Favorite");

            migrationBuilder.DropIndex(
                name: "IX_Favorite_ChatCommentId",
                table: "Favorite");

            migrationBuilder.DropColumn(
                name: "ChatCommentId",
                table: "Favorite");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BabbySitterAnytime.Migrations
{
    /// <inheritdoc />
    public partial class addRarrings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Babysitters_BabysitterId",
                table: "Rating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rating",
                table: "Rating");

            migrationBuilder.RenameTable(
                name: "Rating",
                newName: "Ratings");

            migrationBuilder.RenameIndex(
                name: "IX_Rating_BabysitterId",
                table: "Ratings",
                newName: "IX_Ratings_BabysitterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Babysitters_BabysitterId",
                table: "Ratings",
                column: "BabysitterId",
                principalTable: "Babysitters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Babysitters_BabysitterId",
                table: "Ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings");

            migrationBuilder.RenameTable(
                name: "Ratings",
                newName: "Rating");

            migrationBuilder.RenameIndex(
                name: "IX_Ratings_BabysitterId",
                table: "Rating",
                newName: "IX_Rating_BabysitterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rating",
                table: "Rating",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Babysitters_BabysitterId",
                table: "Rating",
                column: "BabysitterId",
                principalTable: "Babysitters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

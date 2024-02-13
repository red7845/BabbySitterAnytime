using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BabbySitterAnytime.Migrations
{
    /// <inheritdoc />
    public partial class addAddressToBabyssiter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Babysitters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Babysitters");
        }
    }
}

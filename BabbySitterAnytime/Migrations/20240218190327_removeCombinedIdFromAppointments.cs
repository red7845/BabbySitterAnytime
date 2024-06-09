using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BabbySitterAnytime.Migrations
{
    /// <inheritdoc />
    public partial class removeCombinedIdFromAppointments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Appointments",
                type: "uniqueidentifier",
                nullable: false);

            migrationBuilder.Sql("UPDATE Appointments SET Id = NEWID()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_BabySitterId",
                table: "Appointments",
                column: "BabySitterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_BabySitterId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Appointments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments",
                columns: new[] { "BabySitterId", "ClientId" });
        }
    }
}

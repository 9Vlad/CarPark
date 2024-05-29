using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarPark.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BTimeRoute",
                table: "t_Flights");

            migrationBuilder.DropColumn(
                name: "ETimeRoute",
                table: "t_Flights");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "BTimeRoute",
                table: "t_Flights",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "ETimeRoute",
                table: "t_Flights",
                type: "time",
                nullable: true);
        }
    }
}

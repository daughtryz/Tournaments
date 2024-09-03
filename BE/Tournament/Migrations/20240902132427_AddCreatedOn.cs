using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tournament.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatedOn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Tournaments",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Tournaments");
        }
    }
}

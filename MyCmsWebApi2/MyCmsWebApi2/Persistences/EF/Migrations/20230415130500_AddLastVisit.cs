using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCmsWebApi2.Persistences.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddLastVisit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastVisit",
                table: "News",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastVisit",
                table: "News");
        }
    }
}

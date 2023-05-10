using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCmsWebApi2.Migrations
{
    /// <inheritdoc />
    public partial class lllll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "JwtId",
                table: "RefreshTokens",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "JwtId",
                table: "RefreshTokens",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}

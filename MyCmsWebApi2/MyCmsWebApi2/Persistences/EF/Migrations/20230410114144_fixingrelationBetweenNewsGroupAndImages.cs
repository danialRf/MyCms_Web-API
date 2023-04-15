using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCmsWebApi2.Persistences.EF.Migrations
{
    /// <inheritdoc />
    public partial class fixingrelationBetweenNewsGroupAndImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Images_NewsGroupId",
                table: "Images");

            migrationBuilder.CreateIndex(
                name: "IX_Images_NewsGroupId",
                table: "Images",
                column: "NewsGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Images_NewsGroupId",
                table: "Images");

            migrationBuilder.CreateIndex(
                name: "IX_Images_NewsGroupId",
                table: "Images",
                column: "NewsGroupId",
                unique: true);
        }
    }
}

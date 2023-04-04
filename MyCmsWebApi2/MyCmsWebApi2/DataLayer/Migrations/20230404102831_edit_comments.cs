using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCmsWebApi2.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class edit_comments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Page_PageId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Comments_PageId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "PageId",
                table: "Images",
                newName: "imageId");

            migrationBuilder.RenameIndex(
                name: "IX_Images_PageId",
                table: "Images",
                newName: "IX_Images_imageId");

            migrationBuilder.RenameColumn(
                name: "کلمه عبور",
                table: "Admin Login",
                newName: "Passwords");

            migrationBuilder.RenameColumn(
                name: "نام کاربری",
                table: "Admin Login",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "ایمیل",
                table: "Admin Login",
                newName: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PageId",
                table: "Comments",
                column: "PageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Page_imageId",
                table: "Images",
                column: "imageId",
                principalTable: "Page",
                principalColumn: "PageId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Page_imageId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Comments_PageId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "imageId",
                table: "Images",
                newName: "PageId");

            migrationBuilder.RenameIndex(
                name: "IX_Images_imageId",
                table: "Images",
                newName: "IX_Images_PageId");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Admin Login",
                newName: "نام کاربری");

            migrationBuilder.RenameColumn(
                name: "Passwords",
                table: "Admin Login",
                newName: "کلمه عبور");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Admin Login",
                newName: "ایمیل");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PageId",
                table: "Comments",
                column: "PageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Page_PageId",
                table: "Images",
                column: "PageId",
                principalTable: "Page",
                principalColumn: "PageId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

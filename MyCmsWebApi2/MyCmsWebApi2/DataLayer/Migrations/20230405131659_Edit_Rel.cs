using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCmsWebApi2.Migrations
{
    /// <inheritdoc />
    public partial class Edit_Rel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_News_Id",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_NewsGroup_Id",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_News_Id",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_News_NewsGroup_Id",
                table: "News");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "Images",
                newName: "NewsId");

            migrationBuilder.RenameColumn(
                name: "PageId",
                table: "Comments",
                newName: "NewsId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "News",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Images",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Comments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_News_NewsGroupId",
                table: "News",
                column: "NewsGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_NewsGroupId",
                table: "Images",
                column: "NewsGroupId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_NewsId",
                table: "Images",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_NewsId",
                table: "Comments",
                column: "NewsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_News_NewsId",
                table: "Comments",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_NewsGroup_NewsGroupId",
                table: "Images",
                column: "NewsGroupId",
                principalTable: "NewsGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_News_NewsId",
                table: "Images",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_News_NewsGroup_NewsGroupId",
                table: "News",
                column: "NewsGroupId",
                principalTable: "NewsGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_News_NewsId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_NewsGroup_NewsGroupId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_News_NewsId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_News_NewsGroup_NewsGroupId",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_News_NewsGroupId",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_Images_NewsGroupId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_NewsId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Comments_NewsId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "NewsId",
                table: "Images",
                newName: "ImageId");

            migrationBuilder.RenameColumn(
                name: "NewsId",
                table: "Comments",
                newName: "PageId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "News",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Images",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Comments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_News_Id",
                table: "Comments",
                column: "Id",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_NewsGroup_Id",
                table: "Images",
                column: "Id",
                principalTable: "NewsGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_News_Id",
                table: "Images",
                column: "Id",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_News_NewsGroup_Id",
                table: "News",
                column: "Id",
                principalTable: "NewsGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

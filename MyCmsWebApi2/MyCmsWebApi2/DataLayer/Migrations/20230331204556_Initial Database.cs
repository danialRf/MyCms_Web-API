using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCmsWebApi2.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin Login",
                columns: table => new
                {
                    LoginId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    نامکاربری = table.Column<string>(name: "نام کاربری", type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ایمیل = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    کلمهعبور = table.Column<string>(name: "کلمه عبور", type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin Login", x => x.LoginId);
                });

            migrationBuilder.CreateTable(
                name: "Page Groups",
                columns: table => new
                {
                    PageGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupTitle = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Page Groups", x => x.PageGroupId);
                });

            migrationBuilder.CreateTable(
                name: "Page",
                columns: table => new
                {
                    PageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pageGroupId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false),
                    Visit = table.Column<int>(type: "int", nullable: false),
                    ShowInSlider = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Page", x => x.PageId);
                    table.ForeignKey(
                        name: "FK_Page_Page Groups_pageGroupId",
                        column: x => x.pageGroupId,
                        principalTable: "Page Groups",
                        principalColumn: "PageGroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageId = table.Column<int>(type: "int", nullable: false),
                    CommentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CommentEmail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CommentSubject = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CommentText = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Page_PageId",
                        column: x => x.PageId,
                        principalTable: "Page",
                        principalColumn: "PageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImagesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PageId = table.Column<int>(type: "int", nullable: false),
                    PageGrupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImagesId);
                    table.ForeignKey(
                        name: "FK_Images_Page Groups_PageGrupId",
                        column: x => x.PageGrupId,
                        principalTable: "Page Groups",
                        principalColumn: "PageGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Images_Page_PageId",
                        column: x => x.PageId,
                        principalTable: "Page",
                        principalColumn: "PageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PageId",
                table: "Comments",
                column: "PageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_PageGrupId",
                table: "Images",
                column: "PageGrupId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_PageId",
                table: "Images",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_Page_pageGroupId",
                table: "Page",
                column: "pageGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin Login");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Page");

            migrationBuilder.DropTable(
                name: "Page Groups");
        }
    }
}

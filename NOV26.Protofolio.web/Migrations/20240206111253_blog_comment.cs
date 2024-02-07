using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOV26.Protofolio.web.Migrations
{
    public partial class blog_comment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogCommentModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfComment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BlogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogCommentModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogCommentModel_BlogModel_BlogId",
                        column: x => x.BlogId,
                        principalTable: "BlogModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogCommentModel_BlogId",
                table: "BlogCommentModel",
                column: "BlogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogCommentModel");
        }
    }
}

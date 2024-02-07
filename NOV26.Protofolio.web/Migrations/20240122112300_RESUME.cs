using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NOV26.Protofolio.web.Migrations
{
    public partial class RESUME : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResumeModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    START_YEAR = table.Column<int>(type: "int", nullable: false),
                    END_YEAR = table.Column<int>(type: "int", nullable: false),
                    TITLE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    INSTITUTION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESC = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResumeModel");
        }
    }
}

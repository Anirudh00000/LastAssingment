using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassLibraryForunversity.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Universitys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniversityName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AffiliatedUnder = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstablishedYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universitys", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Universitys_UniversityName",
                table: "Universitys",
                column: "UniversityName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Universitys");
        }
    }
}

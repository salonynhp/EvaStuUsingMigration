using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvaStudents.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentMArksheetTableToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentMarkSheet",
                columns: table => new
                {
                    MarkSheetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentRefId = table.Column<int>(type: "int", nullable: false),
                    SubjectTotalMark = table.Column<int>(type: "int", nullable: false),
                    MarksObtained = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentMarkSheet", x => x.MarkSheetId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentMarkSheet");
        }
    }
}

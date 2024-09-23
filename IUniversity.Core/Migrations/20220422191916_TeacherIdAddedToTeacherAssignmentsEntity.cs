using Microsoft.EntityFrameworkCore.Migrations;

namespace IUniversity.Core.Migrations
{
    public partial class TeacherIdAddedToTeacherAssignmentsEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "TeacherAssignments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "TeacherAssignments");
        }
    }
}

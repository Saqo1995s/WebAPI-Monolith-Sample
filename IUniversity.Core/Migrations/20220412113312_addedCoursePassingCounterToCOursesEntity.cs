using Microsoft.EntityFrameworkCore.Migrations;

namespace IUniversity.Core.Migrations
{
    public partial class addedCoursePassingCounterToCOursesEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CoursePasses",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoursePasses",
                table: "Courses");
        }
    }
}

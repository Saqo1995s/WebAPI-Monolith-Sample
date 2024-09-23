using Microsoft.EntityFrameworkCore.Migrations;

namespace IUniversity.Core.Migrations
{
    public partial class removedGroupsProipertyFromCourseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Groups",
                table: "Courses");

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "Courses");

            migrationBuilder.AddColumn<string>(
                name: "Groups",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

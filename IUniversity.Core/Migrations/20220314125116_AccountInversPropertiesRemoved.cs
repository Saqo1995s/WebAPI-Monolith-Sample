using Microsoft.EntityFrameworkCore.Migrations;

namespace IUniversity.Core.Migrations
{
    public partial class AccountInversPropertiesRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Teachers_TeacherAccountId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Students_StudentAccountId",
                table: "Students");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_TeacherAccountId",
                table: "Teachers",
                column: "TeacherAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentAccountId",
                table: "Students",
                column: "StudentAccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Teachers_TeacherAccountId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Students_StudentAccountId",
                table: "Students");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_TeacherAccountId",
                table: "Teachers",
                column: "TeacherAccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentAccountId",
                table: "Students",
                column: "StudentAccountId",
                unique: true);
        }
    }
}

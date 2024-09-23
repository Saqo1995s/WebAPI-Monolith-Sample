using Microsoft.EntityFrameworkCore.Migrations;

namespace IUniversity.Core.Migrations
{
    public partial class StudentAndTeacherEntitiesFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Accounts_UserAccountId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Accounts_UserAccountId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_UserAccountId",
                table: "Teachers");

            migrationBuilder.RenameColumn(
                name: "UserAccountId",
                table: "Teachers",
                newName: "TeacherAccountId");

            migrationBuilder.RenameColumn(
                name: "UserAccountId",
                table: "Students",
                newName: "StudentAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_UserAccountId",
                table: "Students",
                newName: "IX_Students_StudentAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_TeacherAccountId",
                table: "Teachers",
                column: "TeacherAccountId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Accounts_StudentAccountId",
                table: "Students",
                column: "StudentAccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Accounts_TeacherAccountId",
                table: "Teachers",
                column: "TeacherAccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Accounts_StudentAccountId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Accounts_TeacherAccountId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_TeacherAccountId",
                table: "Teachers");

            migrationBuilder.RenameColumn(
                name: "TeacherAccountId",
                table: "Teachers",
                newName: "UserAccountId");

            migrationBuilder.RenameColumn(
                name: "StudentAccountId",
                table: "Students",
                newName: "UserAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_StudentAccountId",
                table: "Students",
                newName: "IX_Students_UserAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_UserAccountId",
                table: "Teachers",
                column: "UserAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Accounts_UserAccountId",
                table: "Students",
                column: "UserAccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Accounts_UserAccountId",
                table: "Teachers",
                column: "UserAccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

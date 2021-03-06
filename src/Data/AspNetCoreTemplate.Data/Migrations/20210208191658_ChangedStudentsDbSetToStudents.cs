using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreTemplate.Data.Migrations
{
    public partial class ChangedStudentsDbSetToStudents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Sudents_StudentId",
                table: "Enrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sudents",
                table: "Sudents");

            migrationBuilder.RenameTable(
                name: "Sudents",
                newName: "Students");

            migrationBuilder.RenameIndex(
                name: "IX_Sudents_IsDeleted",
                table: "Students",
                newName: "IX_Students_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Students_StudentId",
                table: "Enrollments",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Students_StudentId",
                table: "Enrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Sudents");

            migrationBuilder.RenameIndex(
                name: "IX_Students_IsDeleted",
                table: "Sudents",
                newName: "IX_Sudents_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sudents",
                table: "Sudents",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Sudents_StudentId",
                table: "Enrollments",
                column: "StudentId",
                principalTable: "Sudents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

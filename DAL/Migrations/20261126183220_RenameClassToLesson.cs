using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class RenameClassToLesson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSubjects_Classes_ClassID",
                table: "TeacherSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Classes_ClassID",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.RenameColumn(
                name: "ClassID",
                table: "Users",
                newName: "LessonID");

            migrationBuilder.RenameIndex(
                name: "IX_Users_ClassID",
                table: "Users",
                newName: "IX_Users_LessonID");

            migrationBuilder.RenameColumn(
                name: "ClassID",
                table: "TeacherSubjects",
                newName: "LessonID");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherSubjects_ClassID",
                table: "TeacherSubjects",
                newName: "IX_TeacherSubjects_LessonID");

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    LessonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.LessonId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSubjects_Lessons_LessonID",
                table: "TeacherSubjects",
                column: "LessonID",
                principalTable: "Lessons",
                principalColumn: "LessonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Lessons_LessonID",
                table: "Users",
                column: "LessonID",
                principalTable: "Lessons",
                principalColumn: "LessonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSubjects_Lessons_LessonID",
                table: "TeacherSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Lessons_LessonID",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.RenameColumn(
                name: "LessonID",
                table: "Users",
                newName: "ClassID");

            migrationBuilder.RenameIndex(
                name: "IX_Users_LessonID",
                table: "Users",
                newName: "IX_Users_ClassID");

            migrationBuilder.RenameColumn(
                name: "LessonID",
                table: "TeacherSubjects",
                newName: "ClassID");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherSubjects_LessonID",
                table: "TeacherSubjects",
                newName: "IX_TeacherSubjects_ClassID");

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSubjects_Classes_ClassID",
                table: "TeacherSubjects",
                column: "ClassID",
                principalTable: "Classes",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Classes_ClassID",
                table: "Users",
                column: "ClassID",
                principalTable: "Classes",
                principalColumn: "ClassId");
        }
    }
}

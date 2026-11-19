using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class MatchTablesToDesign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Subjects_SubjectID",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Users_TeacherID",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_SubjectID",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "SubjectID",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "VotesCount",
                table: "Questions",
                newName: "UnitID");

            migrationBuilder.RenameColumn(
                name: "TeacherID",
                table: "Questions",
                newName: "TeacherSubjectID");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Questions",
                newName: "AnswerText");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Questions",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_TeacherID",
                table: "Questions",
                newName: "IX_Questions_TeacherSubjectID");

            migrationBuilder.AddColumn<int>(
                name: "ClassID",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassID",
                table: "TeacherSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "AnsweredAt",
                table: "Questions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssignmentID",
                table: "Questions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Body",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    AssignmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherSubjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.AssignmentId);
                    table.ForeignKey(
                        name: "FK_Assignments_TeacherSubjects_TeacherSubjectID",
                        column: x => x.TeacherSubjectID,
                        principalTable: "TeacherSubjects",
                        principalColumn: "TeacherSubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "StudyUnits",
                columns: table => new
                {
                    UnitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderIndex = table.Column<int>(type: "int", nullable: false),
                    SubjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyUnits", x => x.UnitId);
                    table.ForeignKey(
                        name: "FK_StudyUnits_Subjects_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssignmentUnits",
                columns: table => new
                {
                    AssignmentID = table.Column<int>(type: "int", nullable: false),
                    UnitID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignmentUnits", x => new { x.AssignmentID, x.UnitID });
                    table.ForeignKey(
                        name: "FK_AssignmentUnits_Assignments_AssignmentID",
                        column: x => x.AssignmentID,
                        principalTable: "Assignments",
                        principalColumn: "AssignmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignmentUnits_StudyUnits_UnitID",
                        column: x => x.UnitID,
                        principalTable: "StudyUnits",
                        principalColumn: "UnitId");
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    MaterialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UploadedByID = table.Column<int>(type: "int", nullable: false),
                    UnitID = table.Column<int>(type: "int", nullable: false),
                    AssignmentID = table.Column<int>(type: "int", nullable: true),
                    QuestionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.MaterialId);
                    table.ForeignKey(
                        name: "FK_Materials_Assignments_AssignmentID",
                        column: x => x.AssignmentID,
                        principalTable: "Assignments",
                        principalColumn: "AssignmentId");
                    table.ForeignKey(
                        name: "FK_Materials_Questions_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "Questions",
                        principalColumn: "QuestionId");
                    table.ForeignKey(
                        name: "FK_Materials_StudyUnits_UnitID",
                        column: x => x.UnitID,
                        principalTable: "StudyUnits",
                        principalColumn: "UnitId");
                    table.ForeignKey(
                        name: "FK_Materials_Users_UploadedByID",
                        column: x => x.UploadedByID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_ClassID",
                table: "Users",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSubjects_ClassID",
                table: "TeacherSubjects",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_AssignmentID",
                table: "Questions",
                column: "AssignmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_UnitID",
                table: "Questions",
                column: "UnitID");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_TeacherSubjectID",
                table: "Assignments",
                column: "TeacherSubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentUnits_UnitID",
                table: "AssignmentUnits",
                column: "UnitID");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_AssignmentID",
                table: "Materials",
                column: "AssignmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_QuestionID",
                table: "Materials",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_UnitID",
                table: "Materials",
                column: "UnitID");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_UploadedByID",
                table: "Materials",
                column: "UploadedByID");

            migrationBuilder.CreateIndex(
                name: "IX_StudyUnits_SubjectID",
                table: "StudyUnits",
                column: "SubjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Assignments_AssignmentID",
                table: "Questions",
                column: "AssignmentID",
                principalTable: "Assignments",
                principalColumn: "AssignmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_StudyUnits_UnitID",
                table: "Questions",
                column: "UnitID",
                principalTable: "StudyUnits",
                principalColumn: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_TeacherSubjects_TeacherSubjectID",
                table: "Questions",
                column: "TeacherSubjectID",
                principalTable: "TeacherSubjects",
                principalColumn: "TeacherSubjectId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Assignments_AssignmentID",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_StudyUnits_UnitID",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_TeacherSubjects_TeacherSubjectID",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSubjects_Classes_ClassID",
                table: "TeacherSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Classes_ClassID",
                table: "Users");

            migrationBuilder.DropTable(
                name: "AssignmentUnits");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "StudyUnits");

            migrationBuilder.DropIndex(
                name: "IX_Users_ClassID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_TeacherSubjects_ClassID",
                table: "TeacherSubjects");

            migrationBuilder.DropIndex(
                name: "IX_Questions_AssignmentID",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_UnitID",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "ClassID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ClassID",
                table: "TeacherSubjects");

            migrationBuilder.DropColumn(
                name: "AnsweredAt",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "AssignmentID",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Body",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "UnitID",
                table: "Questions",
                newName: "VotesCount");

            migrationBuilder.RenameColumn(
                name: "TeacherSubjectID",
                table: "Questions",
                newName: "TeacherID");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Questions",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "AnswerText",
                table: "Questions",
                newName: "Description");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_TeacherSubjectID",
                table: "Questions",
                newName: "IX_Questions_TeacherID");

            migrationBuilder.AddColumn<int>(
                name: "SubjectID",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_SubjectID",
                table: "Questions",
                column: "SubjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Subjects_SubjectID",
                table: "Questions",
                column: "SubjectID",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Users_TeacherID",
                table: "Questions",
                column: "TeacherID",
                principalTable: "Users",
                principalColumn: "UserID");
        }
    }
}

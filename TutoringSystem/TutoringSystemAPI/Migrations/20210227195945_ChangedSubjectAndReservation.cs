using Microsoft.EntityFrameworkCore.Migrations;

namespace TutoringSystemAPI.Migrations
{
    public partial class ChangedSubjectAndReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Lessons_LessonId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_LessonId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "HourlRate",
                table: "Subjects");

            migrationBuilder.RenameColumn(
                name: "LessonId",
                table: "Subjects",
                newName: "TutorId");

            migrationBuilder.AddColumn<double>(
                name: "HourlRate",
                table: "Students",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_TutorId",
                table: "Subjects",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_SubjectId",
                table: "Reservations",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Subjects_SubjectId",
                table: "Reservations",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Tutors_TutorId",
                table: "Subjects",
                column: "TutorId",
                principalTable: "Tutors",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Subjects_SubjectId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Tutors_TutorId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_TutorId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_SubjectId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "HourlRate",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "TutorId",
                table: "Subjects",
                newName: "LessonId");

            migrationBuilder.AddColumn<double>(
                name: "HourlRate",
                table: "Subjects",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_LessonId",
                table: "Subjects",
                column: "LessonId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Lessons_LessonId",
                table: "Subjects",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

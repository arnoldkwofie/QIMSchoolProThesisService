using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QIMSchoolPro.Thesis.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EditSubmission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ThesisAssignment_SubmissionId",
                table: "ThesisAssignment",
                column: "SubmissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ThesisAssignment_Submission_SubmissionId",
                table: "ThesisAssignment",
                column: "SubmissionId",
                principalTable: "Submission",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThesisAssignment_Submission_SubmissionId",
                table: "ThesisAssignment");

            migrationBuilder.DropIndex(
                name: "IX_ThesisAssignment_SubmissionId",
                table: "ThesisAssignment");
        }
    }
}

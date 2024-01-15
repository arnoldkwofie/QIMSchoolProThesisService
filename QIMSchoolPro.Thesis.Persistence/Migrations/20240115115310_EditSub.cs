using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QIMSchoolPro.Thesis.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EditSub : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ThesisAssignment_StaffId",
                table: "ThesisAssignment",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_ThesisAssignment_Staff_StaffId",
                table: "ThesisAssignment",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThesisAssignment_Staff_StaffId",
                table: "ThesisAssignment");

            migrationBuilder.DropIndex(
                name: "IX_ThesisAssignment_StaffId",
                table: "ThesisAssignment");
        }
    }
}

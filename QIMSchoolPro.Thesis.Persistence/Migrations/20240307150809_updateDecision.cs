using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QIMSchoolPro.Thesis.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateDecision : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accepted",
                table: "ThesisAssignment");

            migrationBuilder.AddColumn<int>(
                name: "Decision",
                table: "ThesisAssignment",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Decision",
                table: "ThesisAssignment");

            migrationBuilder.AddColumn<bool>(
                name: "Accepted",
                table: "ThesisAssignment",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}

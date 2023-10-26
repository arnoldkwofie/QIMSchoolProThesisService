using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QIMSchoolPro.Thesis.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Abstract : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Abstract",
                table: "Submission",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Submission",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Abstract",
                table: "Submission");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Submission");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QIMSchoolPro.Thesis.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PathToVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Version",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DocumentType",
                table: "Document",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Path",
                table: "Version");

            migrationBuilder.DropColumn(
                name: "DocumentType",
                table: "Document");
        }
    }
}

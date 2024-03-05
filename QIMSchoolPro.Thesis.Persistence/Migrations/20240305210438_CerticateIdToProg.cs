using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QIMSchoolPro.Thesis.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CerticateIdToProg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CertificateId",
                table: "Programme",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Programme_CertificateId",
                table: "Programme",
                column: "CertificateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Programme_Certificate_CertificateId",
                table: "Programme",
                column: "CertificateId",
                principalTable: "Certificate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Programme_Certificate_CertificateId",
                table: "Programme");

            migrationBuilder.DropIndex(
                name: "IX_Programme_CertificateId",
                table: "Programme");

            migrationBuilder.DropColumn(
                name: "CertificateId",
                table: "Programme");
        }
    }
}

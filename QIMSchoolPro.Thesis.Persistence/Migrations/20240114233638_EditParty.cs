using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QIMSchoolPro.Thesis.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EditParty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Student_PartyId",
                table: "Student",
                column: "PartyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Party_PartyId",
                table: "Student",
                column: "PartyId",
                principalTable: "Party",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Party_PartyId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_PartyId",
                table: "Student");
        }
    }
}

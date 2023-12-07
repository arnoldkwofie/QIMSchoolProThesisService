using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace QIMSchoolPro.Thesis.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ThesisAssignment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ThesisAssignment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SubmissionId = table.Column<int>(type: "integer", nullable: false),
                    StaffId = table.Column<int>(type: "integer", nullable: false),
                    Accepted = table.Column<bool>(type: "boolean", nullable: false),
                    Audit_CreatedBy = table.Column<string>(type: "text", nullable: false),
                    Audit_Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Audit_LastModifiedBy = table.Column<string>(type: "text", nullable: false),
                    Audit_LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Audit_EntityStatus = table.Column<string>(type: "text", nullable: true),
                    Audit_EntityStatusCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Audit_EntityStatusCreateBy = table.Column<string>(type: "text", nullable: false),
                    Audit_EntityStatusLastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Audit_EntityStatusLastModifiedBy = table.Column<string>(type: "text", nullable: false),
                    OtherProperty = table.Column<string>(type: "text", nullable: false),
                    OtherProperty1 = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThesisAssignment", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubmissionHistory_SubmissionId",
                table: "SubmissionHistory",
                column: "SubmissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubmissionHistory_Submission_SubmissionId",
                table: "SubmissionHistory",
                column: "SubmissionId",
                principalTable: "Submission",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubmissionHistory_Submission_SubmissionId",
                table: "SubmissionHistory");

            migrationBuilder.DropTable(
                name: "ThesisAssignment");

            migrationBuilder.DropIndex(
                name: "IX_SubmissionHistory_SubmissionId",
                table: "SubmissionHistory");
        }
    }
}

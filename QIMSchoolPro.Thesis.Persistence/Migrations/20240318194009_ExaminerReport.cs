using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace QIMSchoolPro.Thesis.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ExaminerReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<int>(
            //    name: "DecisionState",
            //    table: "Submission",
            //    type: "integer",
            //    nullable: false,
            //    defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ExaminerReport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ThesisAssignmentId = table.Column<int>(type: "integer", nullable: false),
                    Path = table.Column<string>(type: "text", nullable: false),
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
                    table.PrimaryKey("PK_ExaminerReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExaminerReport_ThesisAssignment_ThesisAssignmentId",
                        column: x => x.ThesisAssignmentId,
                        principalTable: "ThesisAssignment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExaminerReport_ThesisAssignmentId",
                table: "ExaminerReport",
                column: "ThesisAssignmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExaminerReport");

            //migrationBuilder.DropColumn(
            //    name: "DecisionState",
            //    table: "Submission");
        }
    }
}

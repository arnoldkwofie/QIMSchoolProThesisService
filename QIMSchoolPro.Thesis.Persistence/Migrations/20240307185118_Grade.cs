using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace QIMSchoolPro.Thesis.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Grade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GradeParam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    Section = table.Column<string>(type: "text", nullable: false),
                    MaxMarks = table.Column<decimal>(type: "numeric", nullable: false),
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
                    table.PrimaryKey("PK_GradeParam", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ThesisAssignmentId = table.Column<int>(type: "integer", nullable: false),
                    GradeParamId = table.Column<int>(type: "integer", nullable: false),
                    Marks = table.Column<decimal>(type: "numeric", nullable: false),
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
                    table.PrimaryKey("PK_Grade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grade_GradeParam_GradeParamId",
                        column: x => x.GradeParamId,
                        principalTable: "GradeParam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Grade_ThesisAssignment_ThesisAssignmentId",
                        column: x => x.ThesisAssignmentId,
                        principalTable: "ThesisAssignment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grade_GradeParamId",
                table: "Grade",
                column: "GradeParamId");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_ThesisAssignmentId",
                table: "Grade",
                column: "ThesisAssignmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropTable(
                name: "GradeParam");
        }
    }
}

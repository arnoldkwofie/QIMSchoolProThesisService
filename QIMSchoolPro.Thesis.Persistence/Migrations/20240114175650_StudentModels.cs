using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace QIMSchoolPro.Thesis.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class StudentModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
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
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Programme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DepartmentId = table.Column<int>(type: "integer", nullable: false),
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
                    table.PrimaryKey("PK_Programme", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Programme_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StudentNumber = table.Column<string>(type: "text", nullable: false),
                    IndexNumber = table.Column<string>(type: "text", nullable: false),
                    YearGroup_AdmittedYear = table.Column<int>(type: "integer", nullable: false),
                    YearGroup_ClassYear = table.Column<int>(type: "integer", nullable: false),
                    StudentStatus = table.Column<int>(type: "integer", nullable: true),
                    StudentType = table.Column<string>(type: "text", nullable: false),
                    StudentSection = table.Column<int>(type: "integer", nullable: false),
                    ProgrammeId = table.Column<int>(type: "integer", nullable: false),
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
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Programme_ProgrammeId",
                        column: x => x.ProgrammeId,
                        principalTable: "Programme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Programme_DepartmentId",
                table: "Programme",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_ProgrammeId",
                table: "Student",
                column: "ProgrammeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Programme");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}

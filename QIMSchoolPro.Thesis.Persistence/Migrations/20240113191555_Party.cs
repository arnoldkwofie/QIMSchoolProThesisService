using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace QIMSchoolPro.Thesis.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Party : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Party",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsDisability = table.Column<bool>(type: "boolean", nullable: true),
                    DisabilityReason = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MaritalStatus = table.Column<string>(type: "text", nullable: true),
                    PlaceOfBirth = table.Column<string>(type: "text", nullable: false),
                    PartyType = table.Column<int>(type: "integer", nullable: false),
                    Name_FirstName = table.Column<string>(type: "text", nullable: false),
                    Name_LastName = table.Column<string>(type: "text", nullable: false),
                    Name_OtherName = table.Column<string>(type: "text", nullable: false),
                    PrimaryEmailAddress_Email_EmailType = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    FaxNumber = table.Column<string>(type: "text", nullable: false),
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
                    table.PrimaryKey("PK_Party", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StaffNumber = table.Column<string>(type: "text", nullable: false),
                    DepartmentId = table.Column<int>(type: "integer", nullable: true),
                    PartyId = table.Column<int>(type: "integer", nullable: false),
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
                    table.PrimaryKey("PK_Staff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staff_Party_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Party",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Staff_PartyId",
                table: "Staff",
                column: "PartyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Party");
        }
    }
}

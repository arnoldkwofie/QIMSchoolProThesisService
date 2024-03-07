﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QIMSchoolPro.Thesis.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EditStudent4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Submission",
                newName: "StudentNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentNumber",
                table: "Submission",
                newName: "StudentId");
        }
    }
}
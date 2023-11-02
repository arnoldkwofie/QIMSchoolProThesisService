using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QIMSchoolProThesisService.Identity.Migrations
{
    /// <inheritdoc />
    public partial class IdentityData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "5f359cae-82e0-4d84-8d71-f3f4053f8c89");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1add431ffbbf",
                column: "ConcurrencyStamp",
                value: "f4036901-8ac6-441f-9517-bd79efb5bd92");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "226b9a95-fc59-4754-8908-c3ae18b181bd", "AQAAAAEAACcQAAAAEAed505NlPOitntguZW5M9iqvOvfsSAr6vdeudoV58kvyXvSjqawu9I7AjALTD/twg==", "047398e1-b31d-46a8-b98f-b19e83c0878f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a6ef57df-3324-49f0-a766-b8f40db1b573", "AQAAAAEAACcQAAAAEGOd7hWB9bFX/+8GmVDRDTPPw3syqLy9II7RJ9iJWuQIHUMrqKLQ5Rbtmr00+gDFOA==", "0f488109-8d70-4ee5-8a1d-c2eb76d42b74" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                column: "ConcurrencyStamp",
                value: "082be74f-2e89-4d7c-80ef-cdd5274185a5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbc43a8e-f7bb-4445-baaf-1add431ffbbf",
                column: "ConcurrencyStamp",
                value: "5a23a299-22fd-4f69-9d7f-aae8dfeb1819");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "13ebd28f-a00a-41ad-90f7-196618b9ef61", "AQAAAAEAACcQAAAAEJYnaQ67sW+Cuq3qZDF7TCVrMJT4PBjr4BqTQBDeXlV3aJtEeo4i+9vqKsf+L8xWkA==", "c7c608d7-8478-4117-b4e8-1f5ca4d55295" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a2afc24e-6152-4b1e-ac92-1bb2907e6c68", "AQAAAAEAACcQAAAAEF02aXxTS5pYQl4JM7kGdj3JTw/uccgeumVoiy1sVGZeHNpQ2kpntTMCKoCav5bldQ==", "ad8e0944-dcd7-4ddf-84c8-431450e9ad62" });
        }
    }
}

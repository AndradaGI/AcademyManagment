using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcademyManagment.Migrations
{
    /// <inheritdoc />
    public partial class FixedSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "100",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f450945f-f5c6-46be-901c-bdd992eeb0e0", "AQAAAAIAAYagAAAAEMXu6spNvbEp4q3/WilcKSCFXsf+zAXMTuY+Co9bRIoOw4ptPYw/O0PKAaKPhpPHzA==", "19156d3f-976d-46e2-b558-3f7ac8ef055c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "100",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "613fd2c6-bb5b-404a-9d74-21b698be9c10", "AQAAAAIAAYagAAAAEA3fu//VCu3zVgr00Gat8yHC0BCrX25AHVdmWrgWKAEbxau6RRfQ7ms7cS4ZjjdV0A==", "cf0c2a81-2a4e-426b-af56-d50368155d4b" });
        }
    }
}

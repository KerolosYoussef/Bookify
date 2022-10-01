using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookify.Data.Migrations
{
    public partial class SeedIdentityRoleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7a49b6cf-3745-4306-b325-1453072b1d8f", "421025c4-8c35-4ddd-b1ab-f3ee9c6fbd88", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9745fb31-b345-4bd2-bc4f-6218a8e53a9d", "a74708b3-72b6-447c-9de9-757df057475a", "Customer", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a49b6cf-3745-4306-b325-1453072b1d8f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9745fb31-b345-4bd2-bc4f-6218a8e53a9d");
        }
    }
}

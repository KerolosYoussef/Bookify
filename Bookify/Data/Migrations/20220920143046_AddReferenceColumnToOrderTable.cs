using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookify.Data.Migrations
{
    public partial class AddReferenceColumnToOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "129a3236-e958-4c91-9e14-bc837129dbd3");

            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "a10effd5-89e8-4c2c-8cdc-8157d4cc5629");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6edbfb85-b8d6-4107-8c23-070fd52c8fcd", "998c32f0-35c7-4810-a5ef-f61fa4d23920", "Customer", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f86c3d7d-1aaa-4471-b426-87846b1f4639", "AQAAAAEAACcQAAAAEFEhrG0HezE76Dl80VhHxXyP8MDGpkVSqrAVeYMfoqvE/oHS0aMO+HOQGqjDY6r8Jw==", "1356f665-a04b-4b24-8815-7131a907c238" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6edbfb85-b8d6-4107-8c23-070fd52c8fcd");

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "db1b513a-55dc-4afb-8816-73a84f45ce67");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "129a3236-e958-4c91-9e14-bc837129dbd3", "6499db7d-7a74-4d95-9b73-0a7d6ffa6ec7", "Customer", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c6bb4124-a8b9-480a-8a45-b774e89609bd", "AQAAAAEAACcQAAAAEKM9drVaIRDS8yBqvmmwP6lV8ZYEgYp9vceTac3Z/hFdi6X/efQsx7dyh2h0zQYD0A==", "abb30b2b-d071-4e33-8618-b0fb00b985e7" });
        }
    }
}

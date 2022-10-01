using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookify.Data.Migrations
{
    public partial class AddQuantityToBookOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookOrder",
                table: "BookOrder");
            
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BookOrder",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "BookOrder",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookOrder",
                table: "BookOrder",
                column: "Id");
            
            migrationBuilder.CreateIndex(
                name: "IX_BookOrder_BooksId",
                table: "BookOrder",
                column: "BooksId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookOrder",
                table: "BookOrder");

            migrationBuilder.DropIndex(
                name: "IX_BookOrder_BooksId",
                table: "BookOrder");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "425ba24c-6347-48a6-a49f-0bbda476eb3a");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BookOrder");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "BookOrder");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookOrder",
                table: "BookOrder",
                columns: new[] { "BooksId", "OrderId" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "e8660b00-a8b1-4ccf-88b5-1c3fff8c8c04");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f711cb82-d96a-45f2-9ea2-5b67a87e1962", "882f470c-ec16-42f4-8dd2-4a1c19955794", "Customer", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cb508f97-a438-4a10-a1cd-ea1072abc534", "AQAAAAEAACcQAAAAEDGXzLYt0ZljlbXRQvGfd4d1AmT62f2epzEEYiDyBXka6ht77SbRArrX8xOvySVWxg==", "435314b4-415f-46e0-b481-39ee34a512c1" });
        }
    }
}

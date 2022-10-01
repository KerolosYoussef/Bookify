using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookify.Data.Migrations
{
    public partial class TestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BasketId",
                table: "BasketItem",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItem_Baskets_BasketId",
                table: "BasketItem");

            migrationBuilder.DropIndex(
                name: "IX_BasketItem_BasketId",
                table: "BasketItem");

            migrationBuilder.AlterColumn<int>(
                name: "BasketId",
                table: "BasketItem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BasketId1",
                table: "BasketItem",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BasketItem_BasketId1",
                table: "BasketItem",
                column: "BasketId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItem_Baskets_BasketId1",
                table: "BasketItem",
                column: "BasketId1",
                principalTable: "Baskets",
                principalColumn: "Id");
        }
    }
}

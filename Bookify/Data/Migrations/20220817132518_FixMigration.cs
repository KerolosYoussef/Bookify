using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookify.Data.Migrations
{
    public partial class FixMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BookSoldCopies_BookId",
                table: "BookSoldCopies");

            migrationBuilder.CreateIndex(
                name: "IX_BookSoldCopies_BookId",
                table: "BookSoldCopies",
                column: "BookId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BookSoldCopies_BookId",
                table: "BookSoldCopies");

            migrationBuilder.CreateIndex(
                name: "IX_BookSoldCopies_BookId",
                table: "BookSoldCopies",
                column: "BookId");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookify.Data.Migrations
{
    public partial class SeedBooksData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "ImagePath", "NumberOfCopies", "Price", "PublicationDate", "Title" },
                values: new object[] { 3, 3, "When literature student Anastasia Steele goes to interview young entrepreneur Christian Grey, she encounters a man who is beautiful, brilliant, and intimidating. The unworldly, innocent Ana is startled to realize she wants this man and, despite his enigmatic reserve, finds she is desperate to get close to him.", "fifty_shades_of_grey.jpg", 10, 175.0, new DateTime(2012, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fifty Shades of Grey" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "ImagePath", "NumberOfCopies", "Price", "PublicationDate", "Title" },
                values: new object[] { 4, 1, "When world-renowned Harvard symbologist Robert Langdon is summoned to a Swiss research facility to analyze a mysterious symbol — seared into the chest of a murdered physicist — he discovers evidence of the unimaginable: the resurgence of an ancient secret brotherhood known as the Illuminati… the most powerful underground organization ever to walk the earth.", "angles_and_demons.jpg", 10, 85.0, new DateTime(2005, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Angels and Demons" });

            migrationBuilder.InsertData(
                table: "BookGenre",
                columns: new[] { "BooksId", "GenresId" },
                values: new object[] { 3, 1 });

            migrationBuilder.InsertData(
                table: "BookGenre",
                columns: new[] { "BooksId", "GenresId" },
                values: new object[] { 4, 4 });

            migrationBuilder.InsertData(
                table: "BookGenre",
                columns: new[] { "BooksId", "GenresId" },
                values: new object[] { 4, 6 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}

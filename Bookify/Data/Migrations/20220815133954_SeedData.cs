using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookify.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Dan", "Brown" },
                    { 2, "J.K", "Rowling" },
                    { 3, "E.L", "James" },
                    { 4, "Stephenie", "Meyer" },
                    { 5, "Stieg", "Larsson" }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Romance" },
                    { 2, "Mystery" },
                    { 3, "Fantasy and science fiction" },
                    { 4, "Thrillers and horror" },
                    { 5, "Children’s fiction" },
                    { 6, "Crime" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "NumberOfCopies", "Price", "PublicationDate", "Title" },
                values: new object[] { 1, 1, "The Da Vinci Code follows symbologist Robert Langdon and cryptologist Sophie Neveu after a murder in the Louvre Museum in Paris causes them to become involved in a battle between the Priory of Sion and Opus Dei over the possibility of Jesus Christ and Mary Magdalene having had a child together.", 25, 150.0, new DateTime(2004, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Da Vinci Code" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "NumberOfCopies", "Price", "PublicationDate", "Title" },
                values: new object[] { 2, 2, "The Deathly Hallows is about Harry Potter and his friends finding ways to destroy Voldemort. They learn that even good contains a bit of evil, and vise versa. Even though the trio faces many difficulties, they persevere.", 45, 125.0, new DateTime(2007, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter and the Deathly Hallows " });

            migrationBuilder.InsertData(
                table: "BookGenre",
                columns: new[] { "BooksId", "GenresId" },
                values: new object[] { 1, 4 });

            migrationBuilder.InsertData(
                table: "BookGenre",
                columns: new[] { "BooksId", "GenresId" },
                values: new object[] { 1, 6 });

            migrationBuilder.InsertData(
                table: "BookGenre",
                columns: new[] { "BooksId", "GenresId" },
                values: new object[] { 2, 5 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}

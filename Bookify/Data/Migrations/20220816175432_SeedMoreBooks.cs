using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookify.Data.Migrations
{
    public partial class SeedMoreBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BookSoldCopies",
                columns: new[] { "Id", "BookId", "SoldCopies" },
                values: new object[,]
                {
                    { 1, 1, 12 },
                    { 2, 2, 45 },
                    { 3, 3, 8 },
                    { 4, 4, 75 }
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImagePath",
                value: "davinci.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImagePath",
                value: "harry_potter_deathly_hallow.jpg");

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "ImagePath", "NumberOfCopies", "Price", "PublicationDate", "Title" },
                values: new object[,]
                {
                    { 5, 4, "Twilight is a series of fantasy romance novels by Stephenie Meyer. It follows the life of Isabella 'Bella' Swan, a human teenager who moves to Forks, Washington and finds her life turned upside-down when she falls in love with a vampire named Edward Cullen.", "twilight.jpg", 35, 275.0, new DateTime(2011, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Twilight" },
                    { 6, 4, "The novel continues the story of Bella Swan and vampire Edward Cullen's relationship. When Edward leaves Bella after his brother attacks her, she is left heartbroken and depressed for months until Jacob Black becomes her best friend and helps her fight her pain.", "new_moon.jpg", 8, 113.0, new DateTime(2013, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Moon" },
                    { 7, 2, "It is a story about Harry Potter, an orphan brought up by his aunt and uncle because his parents were killed when he was a baby. Harry is unloved by his uncle and aunt but everything changes when he is invited to join Hogwarts School of Witchcraft and Wizardry and he finds out he's a wizard.", "harry_potter_philosopher_stone.jpg", 32, 125.0, new DateTime(1997, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter and the Philosopher's Stone" },
                    { 8, 2, "The book that took the world by storm. In his fifth year at Hogwarts, Harry faces challenges at every turn, from the dark threat of He-Who-Must-Not-Be-Named and the unreliability of the government of the magical world to the rise of Ron Weasley as the Keeper of the Gryffindor Quidditch Team", "harry_potter_order_of_phoenix.jpg", 15, 125.0, new DateTime(2003, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter and the Order of the Phoenix" },
                    { 9, 2, "The plot follows Harry's second year at Hogwarts School of Witchcraft and Wizardry, during which a series of messages on the walls of the school's corridors warn that the 'Chamber of Secrets' has been opened and that the 'heir of Slytherin' would kill all pupils who do not come from all-magical families.", "harry_potter_chamber_of_secrets.jpg", 7, 125.0, new DateTime(1998, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter and the Chamber of Secrets" },
                    { 10, 2, "The book follows Harry Potter, a young wizard, in his third year at Hogwarts School of Witchcraft and Wizardry. Along with friends Ronald Weasley and Hermione Granger, Harry investigates Sirius Black, an escaped prisoner from Azkaban, the wizard prison, believed to be one of Lord Voldemort's old allies", "harry_potter_prisoner_of_azkaban.jpg", 65, 125.0, new DateTime(1999, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter and the Prisoner of Azkaban" },
                    { 11, 2, "In this book, Harry Potter learns a lot about Lord Voldemort's past, and Harry Potter prepares for the final battle against his nemesis with the help of Headmaster Dumbledore. But in that time, Voldemort returns to power, and makes a plan to destroy Harry.", "harry_potter_half_blood_prince.jpg", 17, 125.0, new DateTime(2005, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter and the Half-blood Prince" },
                    { 12, 2, "It follows Harry Potter, a wizard in his fourth year at Hogwarts School of Witchcraft and Wizardry, and the mystery surrounding the entry of Harry's name into the Triwizard Tournament, in which he is forced to compete. The book was published in the United Kingdom by Bloomsbury and in the United States by Scholastic.", "harry_potter_goblet_of_fire.jpg", 45, 125.0, new DateTime(2000, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter and the Goblet of Fire" }
                });

            migrationBuilder.InsertData(
                table: "BookGenre",
                columns: new[] { "BooksId", "GenresId" },
                values: new object[,]
                {
                    { 5, 1 },
                    { 5, 3 },
                    { 6, 1 },
                    { 6, 3 },
                    { 7, 5 },
                    { 8, 5 },
                    { 9, 5 },
                    { 10, 5 },
                    { 11, 5 },
                    { 12, 5 }
                });

            migrationBuilder.InsertData(
                table: "BookSoldCopies",
                columns: new[] { "Id", "BookId", "SoldCopies" },
                values: new object[,]
                {
                    { 5, 5, 3 },
                    { 6, 6, 18 },
                    { 7, 7, 100 },
                    { 8, 8, 45 },
                    { 9, 9, 58 },
                    { 10, 10, 33 },
                    { 11, 11, 48 },
                    { 12, 12, 34 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 7, 5 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 8, 5 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 9, 5 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 10, 5 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 11, 5 });

            migrationBuilder.DeleteData(
                table: "BookGenre",
                keyColumns: new[] { "BooksId", "GenresId" },
                keyValues: new object[] { 12, 5 });

            migrationBuilder.DeleteData(
                table: "BookSoldCopies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BookSoldCopies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BookSoldCopies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BookSoldCopies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BookSoldCopies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BookSoldCopies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "BookSoldCopies",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "BookSoldCopies",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "BookSoldCopies",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "BookSoldCopies",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "BookSoldCopies",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "BookSoldCopies",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImagePath",
                value: "/img/davinci.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImagePath",
                value: "/img/harry_potter_deathly_hallow.jpg");
        }
    }
}

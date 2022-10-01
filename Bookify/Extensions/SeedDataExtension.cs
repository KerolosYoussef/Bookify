using System.Collections.ObjectModel;
using Bookify.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Extensions
{
    public static class SeedDataExtension
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            // Seed Genres Data
            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Romance" },
                new Genre { Id = 2, Name = "Mystery" },
                new Genre { Id = 3, Name = "Fantasy and science fiction" },
                new Genre { Id = 4, Name = "Thrillers and horror" },
                new Genre { Id = 5, Name = "Children’s fiction" },
                new Genre { Id = 6, Name = "Crime" }
            );


            // Seed Authors Data
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, FirstName = "Dan", LastName = "Brown" },
                new Author { Id = 2, FirstName = "J.K", LastName = "Rowling" },
                new Author { Id = 3, FirstName = "E.L", LastName = "James" },
                new Author { Id = 4, FirstName = "Stephenie", LastName = "Meyer" },
                new Author { Id = 5, FirstName = "Stieg", LastName = "Larsson" }
            );

            // Seed Books Data
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "Da Vinci Code",
                    ImagePath = "davinci.jpg",
                    Price = 150,
                    NumberOfCopies = 25,
                    Description = "The Da Vinci Code follows symbologist Robert Langdon and cryptologist Sophie Neveu after a murder in the Louvre Museum in Paris causes them to become involved in a battle between the Priory of Sion and Opus Dei over the possibility of Jesus Christ and Mary Magdalene having had a child together.",
                    AuthorId = 1,
                    PublicationDate = new DateTime(2004, 5, 1),
                },
                new Book
                {
                    Id = 2,
                    Title = "Harry Potter and the Deathly Hallows ",
                    ImagePath = "harry_potter_deathly_hallow.jpg",
                    Price = 125,
                    NumberOfCopies = 45,
                    Description = "The Deathly Hallows is about Harry Potter and his friends finding ways to destroy Voldemort. They learn that even good contains a bit of evil, and vise versa. Even though the trio faces many difficulties, they persevere.",
                    AuthorId = 2,
                    PublicationDate = new DateTime(2007, 7, 14),
                },
                new Book
                {
                    Id = 3,
                    Title = "Fifty Shades of Grey",
                    ImagePath = "fifty_shades_of_grey.jpg",
                    Price = 125,
                    NumberOfCopies = 10,
                    Description = "When literature student Anastasia Steele goes to interview young entrepreneur Christian Grey, she encounters a man who is beautiful, brilliant, and intimidating. The unworldly, innocent Ana is startled to realize she wants this man and, despite his enigmatic reserve, finds she is desperate to get close to him.",
                    AuthorId = 3,
                    PublicationDate = new DateTime(2012, 5, 3),
                },
                new Book
                {
                    Id = 4,
                    Title = "Angels and Demons",
                    ImagePath = "angles_and_demons.jpg",
                    Price = 125,
                    NumberOfCopies = 10,
                    Description = "When world-renowned Harvard symbologist Robert Langdon is summoned to a Swiss research facility to analyze a mysterious symbol — seared into the chest of a murdered physicist — he discovers evidence of the unimaginable: the resurgence of an ancient secret brotherhood known as the Illuminati… the most powerful underground organization ever to walk the earth.",
                    AuthorId = 1,
                    PublicationDate = new DateTime(2005, 2, 25),
                },
                new Book
                {
                    Id = 5,
                    Title = "Twilight",
                    ImagePath = "twilight.jpg",
                    Price = 275,
                    NumberOfCopies = 35,
                    Description = "Twilight is a series of fantasy romance novels by Stephenie Meyer. It follows the life of Isabella 'Bella' Swan, a human teenager who moves to Forks, Washington and finds her life turned upside-down when she falls in love with a vampire named Edward Cullen.",
                    AuthorId = 4,
                    PublicationDate = new DateTime(2011, 5, 3),
                },
                new Book
                {
                    Id = 6,
                    Title = "New Moon",
                    ImagePath = "new_moon.jpg",
                    Price = 113,
                    NumberOfCopies = 8,
                    Description = "The novel continues the story of Bella Swan and vampire Edward Cullen's relationship. When Edward leaves Bella after his brother attacks her, she is left heartbroken and depressed for months until Jacob Black becomes her best friend and helps her fight her pain.",
                    AuthorId = 4,
                    PublicationDate = new DateTime(2013, 8, 17),
                },
                new Book
                {
                    Id = 7,
                    Title = "Harry Potter and the Philosopher's Stone",
                    ImagePath = "harry_potter_philosopher_stone.jpg",
                    Price = 125,
                    NumberOfCopies = 32,
                    Description = "It is a story about Harry Potter, an orphan brought up by his aunt and uncle because his parents were killed when he was a baby. Harry is unloved by his uncle and aunt but everything changes when he is invited to join Hogwarts School of Witchcraft and Wizardry and he finds out he's a wizard.",
                    AuthorId = 2,
                    PublicationDate = new DateTime(1997, 6, 26),
                },
                new Book
                {
                    Id = 8,
                    Title = "Harry Potter and the Order of the Phoenix",
                    ImagePath = "harry_potter_order_of_phoenix.jpg",
                    Price = 125,
                    NumberOfCopies = 15,
                    Description = "The book that took the world by storm. In his fifth year at Hogwarts, Harry faces challenges at every turn, from the dark threat of He-Who-Must-Not-Be-Named and the unreliability of the government of the magical world to the rise of Ron Weasley as the Keeper of the Gryffindor Quidditch Team",
                    AuthorId = 2,
                    PublicationDate = new DateTime(2003, 7, 21),
                },
                new Book
                {
                    Id = 9,
                    Title = "Harry Potter and the Chamber of Secrets",
                    ImagePath = "harry_potter_chamber_of_secrets.jpg",
                    Price = 125,
                    NumberOfCopies = 7,
                    Description = "The plot follows Harry's second year at Hogwarts School of Witchcraft and Wizardry, during which a series of messages on the walls of the school's corridors warn that the 'Chamber of Secrets' has been opened and that the 'heir of Slytherin' would kill all pupils who do not come from all-magical families.",
                    AuthorId = 2,
                    PublicationDate = new DateTime(1998, 6, 2),
                },
                new Book
                {
                    Id = 10,
                    Title = "Harry Potter and the Prisoner of Azkaban",
                    ImagePath = "harry_potter_prisoner_of_azkaban.jpg",
                    Price = 125,
                    NumberOfCopies = 65,
                    Description = "The book follows Harry Potter, a young wizard, in his third year at Hogwarts School of Witchcraft and Wizardry. Along with friends Ronald Weasley and Hermione Granger, Harry investigates Sirius Black, an escaped prisoner from Azkaban, the wizard prison, believed to be one of Lord Voldemort's old allies",
                    AuthorId = 2,
                    PublicationDate = new DateTime(1999, 7, 8),
                },
                new Book
                {
                    Id = 11,
                    Title = "Harry Potter and the Half-blood Prince",
                    ImagePath = "harry_potter_half_blood_prince.jpg",
                    Price = 125,
                    NumberOfCopies = 17,
                    Description = "In this book, Harry Potter learns a lot about Lord Voldemort's past, and Harry Potter prepares for the final battle against his nemesis with the help of Headmaster Dumbledore. But in that time, Voldemort returns to power, and makes a plan to destroy Harry.",
                    AuthorId = 2,
                    PublicationDate = new DateTime(2005, 7, 16),
                },
                new Book
                {
                    Id = 12,
                    Title = "Harry Potter and the Goblet of Fire",
                    ImagePath = "harry_potter_goblet_of_fire.jpg",
                    Price = 125,
                    NumberOfCopies = 45,
                    Description = "It follows Harry Potter, a wizard in his fourth year at Hogwarts School of Witchcraft and Wizardry, and the mystery surrounding the entry of Harry's name into the Triwizard Tournament, in which he is forced to compete. The book was published in the United Kingdom by Bloomsbury and in the United States by Scholastic.",
                    AuthorId = 2,
                    PublicationDate = new DateTime(2000, 7, 8),
                }

            );

            // Seed Reviews Data
            modelBuilder.Entity<Review>().HasData(
                new Review
                {
                    Id = 1,
                    BookId = 1,
                    UserId = "221792ae-1c77-4446-969b-1daaf8d6eb30",
                    Rating = 4,
                    Comment = "Good Book"
                }
            );
            
            // Seed BookSoldCopies Data
            modelBuilder.Entity<BookSoldCopies>().HasData(
                new BookSoldCopies
                {
                    Id = 1,
                    BookId = 1,
                    SoldCopies = 12
                },
                new BookSoldCopies
                {
                    Id = 2,
                    BookId = 2,
                    SoldCopies = 45
                },
                new BookSoldCopies
                {
                    Id = 3,
                    BookId = 3,
                    SoldCopies = 8
                },
                new BookSoldCopies
                {
                    Id = 4,
                    BookId = 4,
                    SoldCopies = 75
                },
                new BookSoldCopies
                {
                    Id = 5,
                    BookId = 5,
                    SoldCopies = 3
                },
                new BookSoldCopies
                {
                    Id = 6,
                    BookId = 6,
                    SoldCopies = 18
                },
                new BookSoldCopies
                {
                    Id = 7,
                    BookId = 7,
                    SoldCopies = 100
                },
                new BookSoldCopies
                {
                    Id = 8,
                    BookId = 8,
                    SoldCopies = 45
                },
                new BookSoldCopies
                {
                    Id = 9,
                    BookId = 9,
                    SoldCopies = 58
                },
                new BookSoldCopies
                {
                    Id = 10,
                    BookId = 10,
                    SoldCopies = 33
                },
                new BookSoldCopies
                {
                    Id = 11,
                    BookId = 11,
                    SoldCopies = 48
                },
                new BookSoldCopies
                {
                    Id = 12,
                    BookId = 12,
                    SoldCopies = 34
                }
            );
            
            modelBuilder
                .Entity<Book>()
                .HasMany(b => b.Genres)
                .WithMany(b => b.Books)
                .UsingEntity(b => 
                    b.ToTable("BookGenre")
                        .HasData(new Collection<BookGenre>
                        {
                            new BookGenre {BooksId = 1, GenresId = 4},
                            new BookGenre {BooksId = 1, GenresId = 6},
                            new BookGenre {BooksId = 2, GenresId = 5},
                            new BookGenre {BooksId = 3, GenresId = 1},
                            new BookGenre {BooksId = 4, GenresId = 4},
                            new BookGenre {BooksId = 4, GenresId = 6},
                            new BookGenre {BooksId = 5, GenresId = 1},
                            new BookGenre {BooksId = 5, GenresId = 3},
                            new BookGenre {BooksId = 6, GenresId = 1},
                            new BookGenre {BooksId = 6, GenresId = 3},
                            new BookGenre {BooksId = 7, GenresId = 5},
                            new BookGenre {BooksId = 8, GenresId = 5},
                            new BookGenre {BooksId = 9, GenresId = 5},
                            new BookGenre {BooksId = 10, GenresId = 5},
                            new BookGenre {BooksId = 11, GenresId = 5},
                            new BookGenre {BooksId = 12, GenresId = 5}
                        })
                );
        }   
    }
}

﻿// <auto-generated />
using System;
using Bookify.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bookify.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220817132518_FixMigration")]
    partial class FixMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BookGenre", b =>
                {
                    b.Property<int>("BooksId")
                        .HasColumnType("int");

                    b.Property<int>("GenresId")
                        .HasColumnType("int");

                    b.HasKey("BooksId", "GenresId");

                    b.HasIndex("GenresId");

                    b.ToTable("BookGenre", (string)null);

                    b.HasData(
                        new
                        {
                            BooksId = 1,
                            GenresId = 4
                        },
                        new
                        {
                            BooksId = 1,
                            GenresId = 6
                        },
                        new
                        {
                            BooksId = 2,
                            GenresId = 5
                        },
                        new
                        {
                            BooksId = 3,
                            GenresId = 1
                        },
                        new
                        {
                            BooksId = 4,
                            GenresId = 4
                        },
                        new
                        {
                            BooksId = 4,
                            GenresId = 6
                        },
                        new
                        {
                            BooksId = 5,
                            GenresId = 1
                        },
                        new
                        {
                            BooksId = 5,
                            GenresId = 3
                        },
                        new
                        {
                            BooksId = 6,
                            GenresId = 1
                        },
                        new
                        {
                            BooksId = 6,
                            GenresId = 3
                        },
                        new
                        {
                            BooksId = 7,
                            GenresId = 5
                        },
                        new
                        {
                            BooksId = 8,
                            GenresId = 5
                        },
                        new
                        {
                            BooksId = 9,
                            GenresId = 5
                        },
                        new
                        {
                            BooksId = 10,
                            GenresId = 5
                        },
                        new
                        {
                            BooksId = 11,
                            GenresId = 5
                        },
                        new
                        {
                            BooksId = 12,
                            GenresId = 5
                        });
                });

            modelBuilder.Entity("Bookify.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Author");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Dan",
                            LastName = "Brown"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "J.K",
                            LastName = "Rowling"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "E.L",
                            LastName = "James"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Stephenie",
                            LastName = "Meyer"
                        },
                        new
                        {
                            Id = 5,
                            FirstName = "Stieg",
                            LastName = "Larsson"
                        });
                });

            modelBuilder.Entity("Bookify.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfCopies")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            Description = "The Da Vinci Code follows symbologist Robert Langdon and cryptologist Sophie Neveu after a murder in the Louvre Museum in Paris causes them to become involved in a battle between the Priory of Sion and Opus Dei over the possibility of Jesus Christ and Mary Magdalene having had a child together.",
                            ImagePath = "davinci.jpg",
                            NumberOfCopies = 25,
                            Price = 150.0,
                            PublicationDate = new DateTime(2004, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Da Vinci Code"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 2,
                            Description = "The Deathly Hallows is about Harry Potter and his friends finding ways to destroy Voldemort. They learn that even good contains a bit of evil, and vise versa. Even though the trio faces many difficulties, they persevere.",
                            ImagePath = "harry_potter_deathly_hallow.jpg",
                            NumberOfCopies = 45,
                            Price = 125.0,
                            PublicationDate = new DateTime(2007, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Harry Potter and the Deathly Hallows "
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 3,
                            Description = "When literature student Anastasia Steele goes to interview young entrepreneur Christian Grey, she encounters a man who is beautiful, brilliant, and intimidating. The unworldly, innocent Ana is startled to realize she wants this man and, despite his enigmatic reserve, finds she is desperate to get close to him.",
                            ImagePath = "fifty_shades_of_grey.jpg",
                            NumberOfCopies = 10,
                            Price = 125.0,
                            PublicationDate = new DateTime(2012, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Fifty Shades of Grey"
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 1,
                            Description = "When world-renowned Harvard symbologist Robert Langdon is summoned to a Swiss research facility to analyze a mysterious symbol — seared into the chest of a murdered physicist — he discovers evidence of the unimaginable: the resurgence of an ancient secret brotherhood known as the Illuminati… the most powerful underground organization ever to walk the earth.",
                            ImagePath = "angles_and_demons.jpg",
                            NumberOfCopies = 10,
                            Price = 125.0,
                            PublicationDate = new DateTime(2005, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Angels and Demons"
                        },
                        new
                        {
                            Id = 5,
                            AuthorId = 4,
                            Description = "Twilight is a series of fantasy romance novels by Stephenie Meyer. It follows the life of Isabella 'Bella' Swan, a human teenager who moves to Forks, Washington and finds her life turned upside-down when she falls in love with a vampire named Edward Cullen.",
                            ImagePath = "twilight.jpg",
                            NumberOfCopies = 35,
                            Price = 275.0,
                            PublicationDate = new DateTime(2011, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Twilight"
                        },
                        new
                        {
                            Id = 6,
                            AuthorId = 4,
                            Description = "The novel continues the story of Bella Swan and vampire Edward Cullen's relationship. When Edward leaves Bella after his brother attacks her, she is left heartbroken and depressed for months until Jacob Black becomes her best friend and helps her fight her pain.",
                            ImagePath = "new_moon.jpg",
                            NumberOfCopies = 8,
                            Price = 113.0,
                            PublicationDate = new DateTime(2013, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "New Moon"
                        },
                        new
                        {
                            Id = 7,
                            AuthorId = 2,
                            Description = "It is a story about Harry Potter, an orphan brought up by his aunt and uncle because his parents were killed when he was a baby. Harry is unloved by his uncle and aunt but everything changes when he is invited to join Hogwarts School of Witchcraft and Wizardry and he finds out he's a wizard.",
                            ImagePath = "harry_potter_philosopher_stone.jpg",
                            NumberOfCopies = 32,
                            Price = 125.0,
                            PublicationDate = new DateTime(1997, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Harry Potter and the Philosopher's Stone"
                        },
                        new
                        {
                            Id = 8,
                            AuthorId = 2,
                            Description = "The book that took the world by storm. In his fifth year at Hogwarts, Harry faces challenges at every turn, from the dark threat of He-Who-Must-Not-Be-Named and the unreliability of the government of the magical world to the rise of Ron Weasley as the Keeper of the Gryffindor Quidditch Team",
                            ImagePath = "harry_potter_order_of_phoenix.jpg",
                            NumberOfCopies = 15,
                            Price = 125.0,
                            PublicationDate = new DateTime(2003, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Harry Potter and the Order of the Phoenix"
                        },
                        new
                        {
                            Id = 9,
                            AuthorId = 2,
                            Description = "The plot follows Harry's second year at Hogwarts School of Witchcraft and Wizardry, during which a series of messages on the walls of the school's corridors warn that the 'Chamber of Secrets' has been opened and that the 'heir of Slytherin' would kill all pupils who do not come from all-magical families.",
                            ImagePath = "harry_potter_chamber_of_secrets.jpg",
                            NumberOfCopies = 7,
                            Price = 125.0,
                            PublicationDate = new DateTime(1998, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Harry Potter and the Chamber of Secrets"
                        },
                        new
                        {
                            Id = 10,
                            AuthorId = 2,
                            Description = "The book follows Harry Potter, a young wizard, in his third year at Hogwarts School of Witchcraft and Wizardry. Along with friends Ronald Weasley and Hermione Granger, Harry investigates Sirius Black, an escaped prisoner from Azkaban, the wizard prison, believed to be one of Lord Voldemort's old allies",
                            ImagePath = "harry_potter_prisoner_of_azkaban.jpg",
                            NumberOfCopies = 65,
                            Price = 125.0,
                            PublicationDate = new DateTime(1999, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Harry Potter and the Prisoner of Azkaban"
                        },
                        new
                        {
                            Id = 11,
                            AuthorId = 2,
                            Description = "In this book, Harry Potter learns a lot about Lord Voldemort's past, and Harry Potter prepares for the final battle against his nemesis with the help of Headmaster Dumbledore. But in that time, Voldemort returns to power, and makes a plan to destroy Harry.",
                            ImagePath = "harry_potter_half_blood_prince.jpg",
                            NumberOfCopies = 17,
                            Price = 125.0,
                            PublicationDate = new DateTime(2005, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Harry Potter and the Half-blood Prince"
                        },
                        new
                        {
                            Id = 12,
                            AuthorId = 2,
                            Description = "It follows Harry Potter, a wizard in his fourth year at Hogwarts School of Witchcraft and Wizardry, and the mystery surrounding the entry of Harry's name into the Triwizard Tournament, in which he is forced to compete. The book was published in the United Kingdom by Bloomsbury and in the United States by Scholastic.",
                            ImagePath = "harry_potter_goblet_of_fire.jpg",
                            NumberOfCopies = 45,
                            Price = 125.0,
                            PublicationDate = new DateTime(2000, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Harry Potter and the Goblet of Fire"
                        });
                });

            modelBuilder.Entity("Bookify.Models.BookSoldCopies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("SoldCopies")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.ToTable("BookSoldCopies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 1,
                            SoldCopies = 12
                        },
                        new
                        {
                            Id = 2,
                            BookId = 2,
                            SoldCopies = 45
                        },
                        new
                        {
                            Id = 3,
                            BookId = 3,
                            SoldCopies = 8
                        },
                        new
                        {
                            Id = 4,
                            BookId = 4,
                            SoldCopies = 75
                        },
                        new
                        {
                            Id = 5,
                            BookId = 5,
                            SoldCopies = 3
                        },
                        new
                        {
                            Id = 6,
                            BookId = 6,
                            SoldCopies = 18
                        },
                        new
                        {
                            Id = 7,
                            BookId = 7,
                            SoldCopies = 100
                        },
                        new
                        {
                            Id = 8,
                            BookId = 8,
                            SoldCopies = 45
                        },
                        new
                        {
                            Id = 9,
                            BookId = 9,
                            SoldCopies = 58
                        },
                        new
                        {
                            Id = 10,
                            BookId = 10,
                            SoldCopies = 33
                        },
                        new
                        {
                            Id = 11,
                            BookId = 11,
                            SoldCopies = 48
                        },
                        new
                        {
                            Id = 12,
                            BookId = 12,
                            SoldCopies = 34
                        });
                });

            modelBuilder.Entity("Bookify.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genre");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Romance"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Mystery"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Fantasy and science fiction"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Thrillers and horror"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Children’s fiction"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Crime"
                        });
                });

            modelBuilder.Entity("Bookify.Models.Identity.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Bookify.Models.Identity.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Bookify.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserId1")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId1");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("BookGenre", b =>
                {
                    b.HasOne("Bookify.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bookify.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bookify.Models.Book", b =>
                {
                    b.HasOne("Bookify.Models.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Bookify.Models.BookSoldCopies", b =>
                {
                    b.HasOne("Bookify.Models.Book", "Book")
                        .WithOne("BookSoldCopies")
                        .HasForeignKey("Bookify.Models.BookSoldCopies", "BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Bookify.Models.Identity.Address", b =>
                {
                    b.HasOne("Bookify.Models.Identity.User", "User")
                        .WithOne("Address")
                        .HasForeignKey("Bookify.Models.Identity.Address", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Bookify.Models.Review", b =>
                {
                    b.HasOne("Bookify.Models.Book", "Book")
                        .WithMany("Reviews")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bookify.Models.Identity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Bookify.Models.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Bookify.Models.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bookify.Models.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Bookify.Models.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bookify.Models.Book", b =>
                {
                    b.Navigation("BookSoldCopies");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("Bookify.Models.Identity.User", b =>
                {
                    b.Navigation("Address");
                });
#pragma warning restore 612, 618
        }
    }
}

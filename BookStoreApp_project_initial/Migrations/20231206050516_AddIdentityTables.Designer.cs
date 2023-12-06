﻿// <auto-generated />
using System;
using BookStoreApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookStoreApp.Migrations
{
    [DbContext(typeof(BookstoreContext))]
    [Migration("20231206050516_AddIdentityTables")]
    partial class AddIdentityTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BookStoreApp.Models.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorId"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            AuthorId = 1,
                            FirstName = "Stephen",
                            LastName = "King"
                        },
                        new
                        {
                            AuthorId = 2,
                            FirstName = "Agatha",
                            LastName = "Christie"
                        },
                        new
                        {
                            AuthorId = 3,
                            FirstName = "Danielle",
                            LastName = "Steel"
                        },
                        new
                        {
                            AuthorId = 11,
                            FirstName = "David",
                            LastName = "McCullough"
                        },
                        new
                        {
                            AuthorId = 12,
                            FirstName = "George",
                            LastName = "Orwell"
                        },
                        new
                        {
                            AuthorId = 13,
                            FirstName = "J.K.",
                            LastName = "Rowling"
                        },
                        new
                        {
                            AuthorId = 14,
                            FirstName = "J.R.R.",
                            LastName = "Tolkien"
                        },
                        new
                        {
                            AuthorId = 15,
                            FirstName = "Augusten",
                            LastName = "Burroughs"
                        },
                        new
                        {
                            AuthorId = 16,
                            FirstName = "Harper",
                            LastName = "Lee"
                        },
                        new
                        {
                            AuthorId = 17,
                            FirstName = "Leo",
                            LastName = "Tolstoy"
                        },
                        new
                        {
                            AuthorId = 18,
                            FirstName = "Jane",
                            LastName = "Austen"
                        },
                        new
                        {
                            AuthorId = 19,
                            FirstName = "F. Scott",
                            LastName = "Fitzgerald"
                        },
                        new
                        {
                            AuthorId = 20,
                            FirstName = "Agatha",
                            LastName = "Christie"
                        },
                        new
                        {
                            AuthorId = 21,
                            FirstName = "Dan",
                            LastName = "Brown"
                        },
                        new
                        {
                            AuthorId = 22,
                            FirstName = "Mark",
                            LastName = "Twain"
                        },
                        new
                        {
                            AuthorId = 23,
                            FirstName = "J.D.",
                            LastName = "Salinger"
                        },
                        new
                        {
                            AuthorId = 24,
                            FirstName = "Ernest",
                            LastName = "Hemingway"
                        },
                        new
                        {
                            AuthorId = 25,
                            FirstName = "Aldous",
                            LastName = "Huxley"
                        },
                        new
                        {
                            AuthorId = 26,
                            FirstName = "Herman",
                            LastName = "Melville"
                        },
                        new
                        {
                            AuthorId = 27,
                            FirstName = "Stephen",
                            LastName = "King"
                        },
                        new
                        {
                            AuthorId = 28,
                            FirstName = "J.R.R.",
                            LastName = "Tolkien"
                        },
                        new
                        {
                            AuthorId = 29,
                            FirstName = "Lewis",
                            LastName = "Carroll"
                        },
                        new
                        {
                            AuthorId = 30,
                            FirstName = "Andy",
                            LastName = "Weir"
                        });
                });

            modelBuilder.Entity("BookStoreApp.Models.Book", b =>
                {
                    b.Property<string>("ISBN")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("ISBN");

                    b.HasIndex("AuthorId");

                    b.HasIndex("GenreId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            ISBN = "978-0-385-08695-0",
                            AuthorId = 1,
                            BookId = 1,
                            GenreId = 4,
                            Price = 14.94,
                            Title = "Carrie"
                        },
                        new
                        {
                            ISBN = "978-0-670-22026-7",
                            AuthorId = 1,
                            BookId = 2,
                            GenreId = 1,
                            Price = 17.989999999999998,
                            Title = "Christine"
                        },
                        new
                        {
                            ISBN = "978-0-937986-50-9",
                            AuthorId = 1,
                            BookId = 3,
                            GenreId = 1,
                            Price = 11.619999999999999,
                            Title = "The Dark Tower: The Gunslinger"
                        },
                        new
                        {
                            ISBN = "0-670-81302-8",
                            AuthorId = 1,
                            BookId = 4,
                            GenreId = 4,
                            Price = 15.24,
                            Title = "It"
                        },
                        new
                        {
                            ISBN = "978-0-670-81364-3",
                            AuthorId = 1,
                            BookId = 5,
                            GenreId = 1,
                            Price = 13.69,
                            Title = "Misery"
                        },
                        new
                        {
                            ISBN = "978-0062073563",
                            AuthorId = 2,
                            BookId = 6,
                            GenreId = 5,
                            Price = 14.99,
                            Title = "The Murder of Roger Ackroyd"
                        },
                        new
                        {
                            ISBN = "978-0062074027",
                            AuthorId = 2,
                            BookId = 7,
                            GenreId = 5,
                            Price = 19.989999999999998,
                            Title = "Peril at End House"
                        },
                        new
                        {
                            ISBN = "978-0062073501",
                            AuthorId = 2,
                            BookId = 8,
                            GenreId = 5,
                            Price = 11.99,
                            Title = "Murder on the Orient Express"
                        },
                        new
                        {
                            ISBN = "978-0062073488",
                            AuthorId = 2,
                            BookId = 9,
                            GenreId = 5,
                            Price = 12.99,
                            Title = "And Then There Were None"
                        },
                        new
                        {
                            ISBN = "978-0062073587",
                            AuthorId = 2,
                            BookId = 10,
                            GenreId = 5,
                            Price = 20.870000000000001,
                            Title = "The ABC Murders"
                        },
                        new
                        {
                            ISBN = "978-1459745186",
                            AuthorId = 3,
                            BookId = 11,
                            GenreId = 3,
                            Price = 12.99,
                            Title = "Safe Harbour"
                        },
                        new
                        {
                            ISBN = "978-0552142458",
                            AuthorId = 3,
                            BookId = 12,
                            GenreId = 1,
                            Price = 25.739999999999998,
                            Title = "The Gift"
                        },
                        new
                        {
                            ISBN = "978-0593339169",
                            AuthorId = 3,
                            BookId = 13,
                            GenreId = 3,
                            Price = 27.800000000000001,
                            Title = "All That Glitters"
                        },
                        new
                        {
                            ISBN = "978-1984821461",
                            AuthorId = 3,
                            BookId = 14,
                            GenreId = 1,
                            Price = 24.73,
                            Title = "Finding Ashley"
                        },
                        new
                        {
                            ISBN = "978-0385334679",
                            AuthorId = 3,
                            BookId = 15,
                            GenreId = 3,
                            Price = 24.010000000000002,
                            Title = "His Bright Light"
                        },
                        new
                        {
                            ISBN = "00000006",
                            AuthorId = 14,
                            BookId = 16,
                            GenreId = 1,
                            Price = 10.99,
                            Title = "To Kill a Mockingbird"
                        },
                        new
                        {
                            ISBN = "00000007",
                            AuthorId = 15,
                            BookId = 17,
                            GenreId = 3,
                            Price = 16.989999999999998,
                            Title = "Romeo and Juliet"
                        },
                        new
                        {
                            ISBN = "00000008",
                            AuthorId = 16,
                            BookId = 18,
                            GenreId = 4,
                            Price = 35.780000000000001,
                            Title = "The Shining"
                        },
                        new
                        {
                            ISBN = "00000009",
                            AuthorId = 17,
                            BookId = 19,
                            GenreId = 6,
                            Price = 24.09,
                            Title = "A People's History of the United States"
                        },
                        new
                        {
                            ISBN = "00000010",
                            AuthorId = 18,
                            BookId = 20,
                            GenreId = 2,
                            Price = 19.989999999999998,
                            Title = "Dune"
                        },
                        new
                        {
                            ISBN = "00000011",
                            AuthorId = 19,
                            BookId = 11,
                            GenreId = 1,
                            Price = 12.99,
                            Title = "Pride and Prejudice"
                        },
                        new
                        {
                            ISBN = "00000012",
                            AuthorId = 15,
                            BookId = 22,
                            GenreId = 3,
                            Price = 50.890000000000001,
                            Title = "Hamlet"
                        },
                        new
                        {
                            ISBN = "00000013",
                            AuthorId = 20,
                            BookId = 23,
                            GenreId = 4,
                            Price = 14.99,
                            Title = "The Exorcist"
                        },
                        new
                        {
                            ISBN = "000000014",
                            AuthorId = 21,
                            BookId = 24,
                            GenreId = 6,
                            Price = 15.99,
                            Title = "Sapiens: A Brief History of Humankind"
                        },
                        new
                        {
                            ISBN = "00000015",
                            AuthorId = 22,
                            BookId = 25,
                            GenreId = 2,
                            Price = 21.25,
                            Title = "Neuromancer"
                        },
                        new
                        {
                            ISBN = "00000016",
                            AuthorId = 23,
                            BookId = 26,
                            GenreId = 1,
                            Price = 60.990000000000002,
                            Title = "The Great Gatsby"
                        },
                        new
                        {
                            ISBN = "00000017",
                            AuthorId = 15,
                            BookId = 27,
                            GenreId = 3,
                            Price = 28.0,
                            Title = "Macbeth"
                        },
                        new
                        {
                            ISBN = "00000018",
                            AuthorId = 16,
                            BookId = 28,
                            GenreId = 4,
                            Price = 16.5,
                            Title = "It"
                        },
                        new
                        {
                            ISBN = "00000019",
                            AuthorId = 14,
                            BookId = 29,
                            GenreId = 6,
                            Price = 32.990000000000002,
                            Title = "The Wright Brothers"
                        },
                        new
                        {
                            ISBN = "00000020",
                            AuthorId = 15,
                            BookId = 30,
                            GenreId = 2,
                            Price = 13.99,
                            Title = "Foundation"
                        },
                        new
                        {
                            ISBN = "000092",
                            AuthorId = 14,
                            BookId = 32,
                            GenreId = 7,
                            Price = 14.99,
                            Title = "The Lord of the Rings"
                        },
                        new
                        {
                            ISBN = "000096",
                            AuthorId = 14,
                            BookId = 33,
                            GenreId = 7,
                            Price = 17.989999999999998,
                            Title = "The Silmarillion"
                        },
                        new
                        {
                            ISBN = "00000095",
                            AuthorId = 19,
                            BookId = 34,
                            GenreId = 1,
                            Price = 18.989999999999998,
                            Title = "Love in the Night"
                        },
                        new
                        {
                            ISBN = "00000097",
                            AuthorId = 23,
                            BookId = 35,
                            GenreId = 1,
                            Price = 13.67,
                            Title = "The Catcher in the Rye"
                        });
                });

            modelBuilder.Entity("BookStoreApp.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenreId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            GenreId = 1,
                            Name = "Novel"
                        },
                        new
                        {
                            GenreId = 2,
                            Name = "SciFi"
                        },
                        new
                        {
                            GenreId = 3,
                            Name = "Drama"
                        },
                        new
                        {
                            GenreId = 4,
                            Name = "Horror"
                        },
                        new
                        {
                            GenreId = 5,
                            Name = "Mystery"
                        },
                        new
                        {
                            GenreId = 6,
                            Name = "history"
                        },
                        new
                        {
                            GenreId = 7,
                            Name = "Fantasy"
                        });
                });

            modelBuilder.Entity("BookStoreApp.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("BookStoreApp.Models.Book", b =>
                {
                    b.HasOne("BookStoreApp.Models.Author", "authorObject")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStoreApp.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("authorObject");
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
                    b.HasOne("BookStoreApp.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BookStoreApp.Models.User", null)
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

                    b.HasOne("BookStoreApp.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BookStoreApp.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

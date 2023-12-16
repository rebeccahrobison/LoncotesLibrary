﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LoncotesLibrary.Migrations
{
    [DbContext(typeof(LoncotesLibraryDbContext))]
    [Migration("20231215215000_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LoncotesLibrary.Models.Checkout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CheckoutDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("MaterialId")
                        .HasColumnType("integer");

                    b.Property<bool>("Paid")
                        .HasColumnType("boolean");

                    b.Property<int>("PatronId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("MaterialId");

                    b.HasIndex("PatronId");

                    b.ToTable("Checkouts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CheckoutDate = new DateTime(2021, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialId = 1,
                            Paid = true,
                            PatronId = 1,
                            ReturnDate = new DateTime(2021, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            CheckoutDate = new DateTime(2022, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialId = 2,
                            Paid = false,
                            PatronId = 2,
                            ReturnDate = new DateTime(2022, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            CheckoutDate = new DateTime(2022, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialId = 3,
                            Paid = true,
                            PatronId = 3,
                            ReturnDate = new DateTime(2022, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            CheckoutDate = new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialId = 4,
                            Paid = false,
                            PatronId = 4,
                            ReturnDate = new DateTime(2022, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            CheckoutDate = new DateTime(2022, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialId = 5,
                            Paid = true,
                            PatronId = 5,
                            ReturnDate = new DateTime(2022, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 6,
                            CheckoutDate = new DateTime(2022, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialId = 6,
                            Paid = false,
                            PatronId = 6,
                            ReturnDate = new DateTime(2022, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 7,
                            CheckoutDate = new DateTime(2022, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialId = 7,
                            Paid = true,
                            PatronId = 7,
                            ReturnDate = new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 8,
                            CheckoutDate = new DateTime(2022, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialId = 8,
                            Paid = false,
                            PatronId = 8,
                            ReturnDate = new DateTime(2022, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 9,
                            CheckoutDate = new DateTime(2022, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialId = 9,
                            Paid = true,
                            PatronId = 9,
                            ReturnDate = new DateTime(2022, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 10,
                            CheckoutDate = new DateTime(2022, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialId = 10,
                            Paid = false,
                            PatronId = 10,
                            ReturnDate = new DateTime(2022, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 11,
                            CheckoutDate = new DateTime(2022, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialId = 1,
                            Paid = true,
                            PatronId = 11,
                            ReturnDate = new DateTime(2022, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 12,
                            CheckoutDate = new DateTime(2022, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialId = 2,
                            Paid = false,
                            PatronId = 12,
                            ReturnDate = new DateTime(2022, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 13,
                            CheckoutDate = new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialId = 3,
                            Paid = true,
                            PatronId = 1,
                            ReturnDate = new DateTime(2022, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 14,
                            CheckoutDate = new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialId = 4,
                            Paid = false,
                            PatronId = 2,
                            ReturnDate = new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 15,
                            CheckoutDate = new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialId = 5,
                            Paid = true,
                            PatronId = 3,
                            ReturnDate = new DateTime(2023, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 16,
                            CheckoutDate = new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialId = 6,
                            Paid = false,
                            PatronId = 4,
                            ReturnDate = new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 17,
                            CheckoutDate = new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialId = 7,
                            Paid = true,
                            PatronId = 5,
                            ReturnDate = new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 18,
                            CheckoutDate = new DateTime(2023, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialId = 8,
                            Paid = false,
                            PatronId = 6,
                            ReturnDate = new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 19,
                            CheckoutDate = new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialId = 9,
                            Paid = true,
                            PatronId = 7,
                            ReturnDate = new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 20,
                            CheckoutDate = new DateTime(2023, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MaterialId = 10,
                            Paid = false,
                            PatronId = 8,
                            ReturnDate = new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("LoncotesLibrary.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Nonfiction"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Fiction"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Reference"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Biography"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Literature"
                        });
                });

            modelBuilder.Entity("LoncotesLibrary.Models.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("GenreId")
                        .HasColumnType("integer");

                    b.Property<string>("MaterialName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("MaterialTypeId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("OutofCirculationSince")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("MaterialTypeId");

                    b.ToTable("Materials");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GenreId = 5,
                            MaterialName = "Persuasion",
                            MaterialTypeId = 1
                        },
                        new
                        {
                            Id = 2,
                            GenreId = 3,
                            MaterialName = "The Dictionary",
                            MaterialTypeId = 1
                        },
                        new
                        {
                            Id = 3,
                            GenreId = 2,
                            MaterialName = "Interstellar",
                            MaterialTypeId = 2
                        },
                        new
                        {
                            Id = 4,
                            GenreId = 1,
                            MaterialName = "Blue Planet",
                            MaterialTypeId = 2
                        },
                        new
                        {
                            Id = 5,
                            GenreId = 2,
                            MaterialName = "Good Omens",
                            MaterialTypeId = 3
                        },
                        new
                        {
                            Id = 6,
                            GenreId = 4,
                            MaterialName = "Becoming",
                            MaterialTypeId = 1
                        },
                        new
                        {
                            Id = 7,
                            GenreId = 2,
                            MaterialName = "The Alchemist",
                            MaterialTypeId = 1
                        },
                        new
                        {
                            Id = 8,
                            GenreId = 2,
                            MaterialName = "Everything, Everywhere, All At Once",
                            MaterialTypeId = 2
                        },
                        new
                        {
                            Id = 9,
                            GenreId = 1,
                            MaterialName = "Mellon Collie",
                            MaterialTypeId = 3
                        },
                        new
                        {
                            Id = 10,
                            GenreId = 1,
                            MaterialName = "Song and Wind",
                            MaterialTypeId = 1,
                            OutofCirculationSince = new DateTime(2021, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("LoncotesLibrary.Models.MaterialType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CheckoutDays")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("MaterialTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CheckoutDays = 21,
                            Name = "Book"
                        },
                        new
                        {
                            Id = 2,
                            CheckoutDays = 7,
                            Name = "DVD/BluRay"
                        },
                        new
                        {
                            Id = 3,
                            CheckoutDays = 21,
                            Name = "CD"
                        });
                });

            modelBuilder.Entity("LoncotesLibrary.Models.Patron", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Patrons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "123 Byte St",
                            Email = "AdaL@gmail.com",
                            FirstName = "Ada",
                            IsActive = true,
                            LastName = "Lovelace"
                        },
                        new
                        {
                            Id = 2,
                            Address = "456 Crypto Dr",
                            Email = "AlanT@gmail.com",
                            FirstName = "Alan",
                            IsActive = false,
                            LastName = "Turing"
                        },
                        new
                        {
                            Id = 3,
                            Address = "789 Code Ave",
                            Email = "GraceH@gmail.com",
                            FirstName = "Grace",
                            IsActive = true,
                            LastName = "Hopper"
                        },
                        new
                        {
                            Id = 4,
                            Address = "1010 Algorithm Blvd",
                            Email = "JohnN@gmail.com",
                            FirstName = "John",
                            IsActive = false,
                            LastName = "von Neumann"
                        },
                        new
                        {
                            Id = 5,
                            Address = "1111 Software Ln",
                            Email = "MargaretH@gmail.com",
                            FirstName = "Margaret",
                            IsActive = true,
                            LastName = "Hamilton"
                        },
                        new
                        {
                            Id = 6,
                            Address = "1313 Typeset Cir",
                            Email = "DonaldK@gmail.com",
                            FirstName = "Donald",
                            IsActive = true,
                            LastName = "Knuth"
                        },
                        new
                        {
                            Id = 7,
                            Address = "1414 Inheritance Rd",
                            Email = "BarbaraL@gmail.com",
                            FirstName = "Barbara",
                            IsActive = false,
                            LastName = "Liskov"
                        },
                        new
                        {
                            Id = 8,
                            Address = "1616 Web St",
                            Email = "TimBL@gmail.com",
                            FirstName = "Tim",
                            IsActive = true,
                            LastName = "Berners-Lee"
                        },
                        new
                        {
                            Id = 9,
                            Address = "1717 Kernel Ave",
                            Email = "LinusT@gmail.com",
                            FirstName = "Linus",
                            IsActive = false,
                            LastName = "Torvalds"
                        },
                        new
                        {
                            Id = 10,
                            Address = "1919 Structure Dr",
                            Email = "AdaY@gmail.com",
                            FirstName = "Ada",
                            IsActive = true,
                            LastName = "Yonath"
                        },
                        new
                        {
                            Id = 11,
                            Address = "2020 Language Blvd",
                            Email = "BrianK@gmail.com",
                            FirstName = "Brian",
                            IsActive = true,
                            LastName = "Kernighan"
                        },
                        new
                        {
                            Id = 12,
                            Address = "2222 Navy St",
                            Email = "GraceM@gmail.com",
                            FirstName = "Grace",
                            IsActive = false,
                            LastName = "Murray"
                        });
                });

            modelBuilder.Entity("LoncotesLibrary.Models.Checkout", b =>
                {
                    b.HasOne("LoncotesLibrary.Models.Material", "Material")
                        .WithMany("Checkouts")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LoncotesLibrary.Models.Patron", "Patron")
                        .WithMany("Checkouts")
                        .HasForeignKey("PatronId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Material");

                    b.Navigation("Patron");
                });

            modelBuilder.Entity("LoncotesLibrary.Models.Material", b =>
                {
                    b.HasOne("LoncotesLibrary.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LoncotesLibrary.Models.MaterialType", "MaterialType")
                        .WithMany()
                        .HasForeignKey("MaterialTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("MaterialType");
                });

            modelBuilder.Entity("LoncotesLibrary.Models.Material", b =>
                {
                    b.Navigation("Checkouts");
                });

            modelBuilder.Entity("LoncotesLibrary.Models.Patron", b =>
                {
                    b.Navigation("Checkouts");
                });
#pragma warning restore 612, 618
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LoncotesLibrary.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaterialTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CheckoutDays = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patrons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patrons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MaterialName = table.Column<string>(type: "text", nullable: false),
                    MaterialTypeId = table.Column<int>(type: "integer", nullable: false),
                    GenreId = table.Column<int>(type: "integer", nullable: false),
                    OutofCirculationSince = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materials_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Materials_MaterialTypes_MaterialTypeId",
                        column: x => x.MaterialTypeId,
                        principalTable: "MaterialTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Checkouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MaterialId = table.Column<int>(type: "integer", nullable: false),
                    PatronId = table.Column<int>(type: "integer", nullable: false),
                    CheckoutDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Paid = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Checkouts_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Checkouts_Patrons_PatronId",
                        column: x => x.PatronId,
                        principalTable: "Patrons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Nonfiction" },
                    { 2, "Fiction" },
                    { 3, "Reference" },
                    { 4, "Biography" },
                    { 5, "Literature" }
                });

            migrationBuilder.InsertData(
                table: "MaterialTypes",
                columns: new[] { "Id", "CheckoutDays", "Name" },
                values: new object[,]
                {
                    { 1, 21, "Book" },
                    { 2, 7, "DVD/BluRay" },
                    { 3, 21, "CD" }
                });

            migrationBuilder.InsertData(
                table: "Patrons",
                columns: new[] { "Id", "Address", "Email", "FirstName", "IsActive", "LastName" },
                values: new object[,]
                {
                    { 1, "123 Byte St", "AdaL@gmail.com", "Ada", true, "Lovelace" },
                    { 2, "456 Crypto Dr", "AlanT@gmail.com", "Alan", false, "Turing" },
                    { 3, "789 Code Ave", "GraceH@gmail.com", "Grace", true, "Hopper" },
                    { 4, "1010 Algorithm Blvd", "JohnN@gmail.com", "John", false, "von Neumann" },
                    { 5, "1111 Software Ln", "MargaretH@gmail.com", "Margaret", true, "Hamilton" },
                    { 6, "1313 Typeset Cir", "DonaldK@gmail.com", "Donald", true, "Knuth" },
                    { 7, "1414 Inheritance Rd", "BarbaraL@gmail.com", "Barbara", false, "Liskov" },
                    { 8, "1616 Web St", "TimBL@gmail.com", "Tim", true, "Berners-Lee" },
                    { 9, "1717 Kernel Ave", "LinusT@gmail.com", "Linus", false, "Torvalds" },
                    { 10, "1919 Structure Dr", "AdaY@gmail.com", "Ada", true, "Yonath" },
                    { 11, "2020 Language Blvd", "BrianK@gmail.com", "Brian", true, "Kernighan" },
                    { 12, "2222 Navy St", "GraceM@gmail.com", "Grace", false, "Murray" }
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "GenreId", "MaterialName", "MaterialTypeId", "OutofCirculationSince" },
                values: new object[,]
                {
                    { 1, 5, "Persuasion", 1, null },
                    { 2, 3, "The Dictionary", 1, null },
                    { 3, 2, "Interstellar", 2, null },
                    { 4, 1, "Blue Planet", 2, null },
                    { 5, 2, "Good Omens", 3, null },
                    { 6, 4, "Becoming", 1, null },
                    { 7, 2, "The Alchemist", 1, null },
                    { 8, 2, "Everything, Everywhere, All At Once", 2, null },
                    { 9, 1, "Mellon Collie", 3, null },
                    { 10, 1, "Song and Wind", 1, new DateTime(2021, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Checkouts",
                columns: new[] { "Id", "CheckoutDate", "MaterialId", "Paid", "PatronId", "ReturnDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, 1, new DateTime(2021, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2022, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false, 2, new DateTime(2022, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2022, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, true, 3, new DateTime(2022, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, false, 4, new DateTime(2022, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2022, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, true, 5, new DateTime(2022, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2022, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, false, 6, new DateTime(2022, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2022, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, true, 7, new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2022, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, false, 8, new DateTime(2022, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2022, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, true, 9, new DateTime(2022, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(2022, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, false, 10, new DateTime(2022, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, new DateTime(2022, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, 11, new DateTime(2022, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, new DateTime(2022, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false, 12, new DateTime(2022, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, true, 1, new DateTime(2022, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, false, 2, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, true, 3, new DateTime(2023, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, false, 4, new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, true, 5, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, new DateTime(2023, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, false, 6, new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, true, 7, new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, new DateTime(2023, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, false, 8, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_MaterialId",
                table: "Checkouts",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_PatronId",
                table: "Checkouts",
                column: "PatronId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_GenreId",
                table: "Materials",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_MaterialTypeId",
                table: "Materials",
                column: "MaterialTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Checkouts");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Patrons");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "MaterialTypes");
        }
    }
}

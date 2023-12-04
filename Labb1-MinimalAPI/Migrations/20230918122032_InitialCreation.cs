using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Labb1_MinimalAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "Id", "Author", "Description", "Genre", "Title", "Year", "isAvailable" },
                values: new object[,]
                {
                    { new Guid("2cf1dd5f-d543-41cd-83ef-6ff723e27c4b"), "George R. R. Martin", "A Storm of Swords is the third of seven planned novels in A Song of Ice and Fire", "Political Fiction", "A Storm of Swords", "2000", false },
                    { new Guid("43f039ab-5585-4042-b0ec-b7fe32d6b47a"), "George R. R. Martin", "A Clash of Kings is the second of seven planned novels in A Song of Ice and Fire", "Political Fiction", "A Clash of Kings", "1998", true },
                    { new Guid("783c8e49-e992-46f5-922a-7d1528c4c4fd"), "George R. R. Martin", "A Game of Thrones is the first novel in A Song of Ice and Fire", "Political Fiction", "A Game of Thrones", "1996", true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "books");
        }
    }
}

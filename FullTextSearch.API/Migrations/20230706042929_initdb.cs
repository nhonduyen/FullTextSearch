using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FullTextSearch.API.Migrations
{
    /// <inheritdoc />
    public partial class initdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("3c41b86e-4840-434b-aced-1c564ba15ab1"), "Nói về triết học khắc kỷ", "Chủ nghĩa khắc kỷ" },
                    { new Guid("5849199d-d3d6-4f0b-a8a0-529acaec487b"), "Sách tình cảm", "Cuốn theo chiều gió" },
                    { new Guid("bdb055c5-c7b3-4a4a-99b3-aaf421e82fdb"), "Một cuốn sách xuất sác.", "Thép đã tôi thế đấy!" },
                    { new Guid("d93acb4e-0d55-42ed-9f1b-ccae83305d6d"), "Đây là một cuốn sách hay.", "Tôi tài giỏi, bạn cũng thế!" }
                });

            migrationBuilder.Sql(
                sql: "CREATE FULLTEXT CATALOG ftCatalog WITH ACCENT_SENSITIVITY = ON AS DEFAULT;",
                suppressTransaction: true);

            migrationBuilder.Sql(
                sql: "CREATE FULLTEXT INDEX ON dbo.Book(Name, Description) KEY INDEX PK_Book ON ftCatalog;",
                suppressTransaction: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");
        }
    }
}

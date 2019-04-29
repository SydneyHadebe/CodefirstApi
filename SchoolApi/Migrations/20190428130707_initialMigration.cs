using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolApi.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 255, nullable: false),
                    LastName = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 250, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    AuthorId = table.Column<Guid>(nullable: false),
                    developerAuthorId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_developerAuthorId",
                        column: x => x.developerAuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("d28888e9-2ba9-473e-a40f-e38cb54f9b35"), "Sydney", "Hadebe" },
                    { new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), "C# Developer", "Back-end Developer" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "Title", "developerAuthorId" },
                values: new object[,]
                {
                    { new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"), new Guid("d28888e9-2ba9-473e-a40f-e38cb54f9b35"), "Backend developers, i wish to work for Amazon South Africa", "C# and Java", null },
                    { new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7ee"), new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), "Backend developers, i wish to work for Amazon South Africa", "C# and Java", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_developerAuthorId",
                table: "Books",
                column: "developerAuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}

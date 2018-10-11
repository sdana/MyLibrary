using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyLibrary.Migrations
{
    public partial class SomethingElse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patron",
                columns: table => new
                {
                    PatronId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    LibraryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patron", x => x.PatronId);
                    table.ForeignKey(
                        name: "FK_Patron_Library_LibraryId",
                        column: x => x.LibraryId,
                        principalTable: "Library",
                        principalColumn: "LibraryId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_PatronId",
                table: "Book",
                column: "PatronId");

            migrationBuilder.CreateIndex(
                name: "IX_Patron_LibraryId",
                table: "Patron",
                column: "LibraryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Patron_PatronId",
                table: "Book",
                column: "PatronId",
                principalTable: "Patron",
                principalColumn: "PatronId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Patron_PatronId",
                table: "Book");

            migrationBuilder.DropTable(
                name: "Patron");

            migrationBuilder.DropIndex(
                name: "IX_Book_PatronId",
                table: "Book");
        }
    }
}

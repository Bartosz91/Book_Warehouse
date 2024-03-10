using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warehouse.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookCase_BookCaseId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookCase",
                table: "BookCase");

            migrationBuilder.RenameTable(
                name: "BookCase",
                newName: "BookCases");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "BookCases",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookCases",
                table: "BookCases",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Authors_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookCases_AuthorId",
                table: "BookCases",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_BookId",
                table: "Authors",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookCases_Authors_AuthorId",
                table: "BookCases",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookCases_BookCaseId",
                table: "Books",
                column: "BookCaseId",
                principalTable: "BookCases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCases_Authors_AuthorId",
                table: "BookCases");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookCases_BookCaseId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookCases",
                table: "BookCases");

            migrationBuilder.DropIndex(
                name: "IX_BookCases_AuthorId",
                table: "BookCases");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "BookCases");

            migrationBuilder.RenameTable(
                name: "BookCases",
                newName: "BookCase");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookCase",
                table: "BookCase",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookCase_BookCaseId",
                table: "Books",
                column: "BookCaseId",
                principalTable: "BookCase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

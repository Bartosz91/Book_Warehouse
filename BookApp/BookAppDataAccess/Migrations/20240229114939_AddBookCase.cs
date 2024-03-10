using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warehouse.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddBookCase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookCaseId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BookCase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCase", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookCaseId",
                table: "Books",
                column: "BookCaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookCase_BookCaseId",
                table: "Books",
                column: "BookCaseId",
                principalTable: "BookCase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookCase_BookCaseId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "BookCase");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookCaseId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookCaseId",
                table: "Books");
        }
    }
}

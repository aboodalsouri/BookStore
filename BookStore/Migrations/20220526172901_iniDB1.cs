using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Migrations
{
    public partial class iniDB1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Book_Gategory_id",
                table: "Book");

            migrationBuilder.CreateIndex(
                name: "IX_Book_Gategory_id",
                table: "Book",
                column: "Gategory_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Book_Gategory_id",
                table: "Book");

            migrationBuilder.CreateIndex(
                name: "IX_Book_Gategory_id",
                table: "Book",
                column: "Gategory_id",
                unique: true);
        }
    }
}

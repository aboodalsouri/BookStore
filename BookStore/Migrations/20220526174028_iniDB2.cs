using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Migrations
{
    public partial class iniDB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Country_id",
                table: "Auther",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auther_Country_id",
                table: "Auther",
                column: "Country_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Auther_Country_Country_id",
                table: "Auther",
                column: "Country_id",
                principalTable: "Country",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auther_Country_Country_id",
                table: "Auther");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropIndex(
                name: "IX_Auther_Country_id",
                table: "Auther");

            migrationBuilder.DropColumn(
                name: "Country_id",
                table: "Auther");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalExam.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Candies",
                columns: table => new
                {
                    CandyId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Author = table.Column<string>(type: "TEXT", nullable: true),
                    Publisher = table.Column<string>(type: "TEXT", nullable: true),
                    Isbn = table.Column<string>(type: "TEXT", nullable: true),
                    Classification = table.Column<string>(type: "TEXT", nullable: true),
                    PageCount = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candies", x => x.CandyId);
                    table.ForeignKey(
                        name: "FK_Candies_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 1, "Horror" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 2, "Adventure" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 3, "Comedy" });

            migrationBuilder.InsertData(
                table: "Candies",
                columns: new[] { "CandyId", "Author", "CategoryId", "Classification", "Isbn", "PageCount", "Price", "Publisher", "Title" },
                values: new object[] { 1, "Scott", 1, "Sales", "555-123-4567", 2, 25.0, "duh", "Michael" });

            migrationBuilder.InsertData(
                table: "Candies",
                columns: new[] { "CandyId", "Author", "CategoryId", "Classification", "Isbn", "PageCount", "Price", "Publisher", "Title" },
                values: new object[] { 2, "Bratton", 2, "Undeclared", "555-123-7890", 3, 20.0, "Jimbo", "Creed" });

            migrationBuilder.CreateIndex(
                name: "IX_Candies_CategoryId",
                table: "Candies",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candies");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

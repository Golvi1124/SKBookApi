using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SKBookApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Publisher = table.Column<string>(type: "TEXT", nullable: true),
                    Pages = table.Column<int>(type: "INTEGER", nullable: false),
                    notes = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Shorts",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    title = table.Column<string>(type: "TEXT", nullable: true),
                    type = table.Column<string>(type: "TEXT", nullable: true),
                    originallyPublishedIn = table.Column<string>(type: "TEXT", nullable: true),
                    collectedIn = table.Column<string>(type: "TEXT", nullable: true),
                    notes = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shorts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Villains",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    gender = table.Column<string>(type: "TEXT", nullable: true),
                    status = table.Column<string>(type: "TEXT", nullable: true),
                    notes = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villains", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "BookVillain",
                columns: table => new
                {
                    booksid = table.Column<int>(type: "INTEGER", nullable: false),
                    villainsid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookVillain", x => new { x.booksid, x.villainsid });
                    table.ForeignKey(
                        name: "FK_BookVillain_Books_booksid",
                        column: x => x.booksid,
                        principalTable: "Books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookVillain_Villains_villainsid",
                        column: x => x.villainsid,
                        principalTable: "Villains",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShortVillain",
                columns: table => new
                {
                    shortsid = table.Column<int>(type: "INTEGER", nullable: false),
                    villainsid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShortVillain", x => new { x.shortsid, x.villainsid });
                    table.ForeignKey(
                        name: "FK_ShortVillain_Shorts_shortsid",
                        column: x => x.shortsid,
                        principalTable: "Shorts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShortVillain_Villains_villainsid",
                        column: x => x.villainsid,
                        principalTable: "Villains",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookVillain_villainsid",
                table: "BookVillain",
                column: "villainsid");

            migrationBuilder.CreateIndex(
                name: "IX_ShortVillain_villainsid",
                table: "ShortVillain",
                column: "villainsid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookVillain");

            migrationBuilder.DropTable(
                name: "ShortVillain");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Shorts");

            migrationBuilder.DropTable(
                name: "Villains");
        }
    }
}

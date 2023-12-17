using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace udemyWeb1.Migrations
{
    /// <inheritdoc />
    public partial class migrationreinstall : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PoliklinikTurleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliklinikTurleri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doktorlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoktorAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bolum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unvan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DogumYili = table.Column<int>(type: "int", nullable: false),
                    PoliklinikTuruId = table.Column<int>(type: "int", nullable: false),
                    ResimUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doktorlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doktorlar_PoliklinikTurleri_PoliklinikTuruId",
                        column: x => x.PoliklinikTuruId,
                        principalTable: "PoliklinikTurleri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doktorlar_PoliklinikTuruId",
                table: "Doktorlar",
                column: "PoliklinikTuruId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doktorlar");

            migrationBuilder.DropTable(
                name: "PoliklinikTurleri");
        }
    }
}

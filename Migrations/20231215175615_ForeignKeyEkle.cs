using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace udemyWeb1.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyEkle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PoliklinikTuruId",
                table: "Doktorlar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Doktorlar_PoliklinikTuruId",
                table: "Doktorlar",
                column: "PoliklinikTuruId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doktorlar_PoliklinikTurleri_PoliklinikTuruId",
                table: "Doktorlar",
                column: "PoliklinikTuruId",
                principalTable: "PoliklinikTurleri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doktorlar_PoliklinikTurleri_PoliklinikTuruId",
                table: "Doktorlar");

            migrationBuilder.DropIndex(
                name: "IX_Doktorlar_PoliklinikTuruId",
                table: "Doktorlar");

            migrationBuilder.DropColumn(
                name: "PoliklinikTuruId",
                table: "Doktorlar");
        }
    }
}

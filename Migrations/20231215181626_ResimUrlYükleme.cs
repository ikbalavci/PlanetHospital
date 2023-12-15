using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace udemyWeb1.Migrations
{
    /// <inheritdoc />
    public partial class ResimUrlYükleme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResimUrl",
                table: "Doktorlar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResimUrl",
                table: "Doktorlar");
        }
    }
}

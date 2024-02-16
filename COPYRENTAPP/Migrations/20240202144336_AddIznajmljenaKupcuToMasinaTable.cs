using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjekatPPP.Migrations
{
    /// <inheritdoc />
    public partial class AddIznajmljenaKupcuToMasinaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "izdataKupcu",
                table: "Masine",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "izdataKupcu",
                table: "Masine");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjekatPPP.Migrations
{
    /// <inheritdoc />
    public partial class AddMasinaKupacFaktura : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kupac",
                columns: table => new
                {
                    idKupca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imeFirme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bankovniRacun = table.Column<int>(type: "int", nullable: false),
                    pib = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kupac", x => x.idKupca);
                });

            migrationBuilder.CreateTable(
                name: "Masine",
                columns: table => new
                {
                    idMasine = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    proizvodjac = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    brojKopija = table.Column<int>(type: "int", nullable: false),
                    cena = table.Column<float>(type: "real", nullable: false),
                    opis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Masine", x => x.idMasine);
                });

            migrationBuilder.CreateTable(
                name: "Faktura",
                columns: table => new
                {
                    idFakture = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pib = table.Column<int>(type: "int", nullable: false),
                    cena = table.Column<float>(type: "real", nullable: false),
                    idKupca = table.Column<int>(type: "int", nullable: false),
                    idMasine = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faktura", x => x.idFakture);
                    table.ForeignKey(
                        name: "FK_Faktura_Kupac_idKupca",
                        column: x => x.idKupca,
                        principalTable: "Kupac",
                        principalColumn: "idKupca");
                    table.ForeignKey(
                        name: "FK_Faktura_Masine_idMasine",
                        column: x => x.idMasine,
                        principalTable: "Masine",
                        principalColumn: "idMasine");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Faktura_idKupca",
                table: "Faktura",
                column: "idKupca");

            migrationBuilder.CreateIndex(
                name: "IX_Faktura_idMasine",
                table: "Faktura",
                column: "idMasine");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Faktura");

            migrationBuilder.DropTable(
                name: "Kupac");

            migrationBuilder.DropTable(
                name: "Masine");
        }
    }
}

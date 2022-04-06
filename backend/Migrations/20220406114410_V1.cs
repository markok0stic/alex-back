using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VremeIDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Starost = table.Column<int>(type: "int", nullable: false),
                    InstrumentILIPevanje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstrumentKojiSvira = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VremeProvedenoSviranjemInsturmenta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Obrazovanje = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RezultatiTesta",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Resenje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Odgovor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VremeReakcije = table.Column<int>(type: "int", nullable: false),
                    KorisnikID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RezultatiTesta", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RezultatiTesta_Korisnik_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RezultatiTesta_KorisnikID",
                table: "RezultatiTesta",
                column: "KorisnikID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RezultatiTesta");

            migrationBuilder.DropTable(
                name: "Korisnik");
        }
    }
}

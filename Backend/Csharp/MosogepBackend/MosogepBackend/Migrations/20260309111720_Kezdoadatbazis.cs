using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MosogepBackend.Migrations
{
    /// <inheritdoc />
    public partial class Kezdoadatbazis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gyartok",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nev = table.Column<string>(type: "TEXT", nullable: false),
                    Nepszeru = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gyartok", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Naplo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    JatitasKtsg = table.Column<int>(type: "INTEGER", nullable: false),
                    Szerelo = table.Column<string>(type: "TEXT", nullable: false),
                    Hibakod = table.Column<int>(type: "INTEGER", nullable: false),
                    FeliratkozasDatuma = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Gepadatai = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Naplo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gepek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HibaId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Datum = table.Column<DateTime>(type: "TEXT", nullable: false),
                    GepAraEuro = table.Column<int>(type: "INTEGER", nullable: false),
                    GepAraFt = table.Column<int>(type: "INTEGER", nullable: false),
                    Azonosito = table.Column<string>(type: "TEXT", nullable: false),
                    MaxToltotomeg = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxFordulat = table.Column<int>(type: "INTEGER", nullable: false),
                    GyartoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Tipus = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gepek", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gepek_Gyartok_GyartoId",
                        column: x => x.GyartoId,
                        principalTable: "Gyartok",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gepek_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hiba",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KulsoId = table.Column<int>(type: "INTEGER", nullable: false),
                    MosogepId = table.Column<int>(type: "INTEGER", nullable: false),
                    Hibakod = table.Column<int>(type: "INTEGER", nullable: false),
                    HibaKtsg = table.Column<int>(type: "INTEGER", nullable: false),
                    HibaDatuma = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hiba", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hiba_Gepek_MosogepId",
                        column: x => x.MosogepId,
                        principalTable: "Gepek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Javitas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    JavaJavitasId = table.Column<int>(type: "INTEGER", nullable: false),
                    Szerelo = table.Column<string>(type: "TEXT", nullable: false),
                    JavtiasDatum = table.Column<DateTime>(type: "TEXT", nullable: false),
                    JavitasKtsg = table.Column<int>(type: "INTEGER", nullable: false),
                    Munkaber = table.Column<int>(type: "INTEGER", nullable: false),
                    Nyereseg = table.Column<int>(type: "INTEGER", nullable: false),
                    HibaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Javitas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Javitas_Hiba_HibaId",
                        column: x => x.HibaId,
                        principalTable: "Hiba",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gepek_GyartoId",
                table: "Gepek",
                column: "GyartoId");

            migrationBuilder.CreateIndex(
                name: "IX_Gepek_UserId",
                table: "Gepek",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Hiba_MosogepId",
                table: "Hiba",
                column: "MosogepId");

            migrationBuilder.CreateIndex(
                name: "IX_Javitas_HibaId",
                table: "Javitas",
                column: "HibaId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Javitas");

            migrationBuilder.DropTable(
                name: "Naplo");

            migrationBuilder.DropTable(
                name: "Hiba");

            migrationBuilder.DropTable(
                name: "Gepek");

            migrationBuilder.DropTable(
                name: "Gyartok");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}

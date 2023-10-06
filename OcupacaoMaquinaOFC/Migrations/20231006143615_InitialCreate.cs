using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OcupacaoMaquinaOFC.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Maquina",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    limiteHoras = table.Column<double>(type: "float", nullable: false),
                    valorMaquina = table.Column<double>(type: "float", nullable: false),
                    valorHora = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maquina", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Projeto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataConclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lider = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projeto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AlocacaoHoras",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    qtdHoraPorMaquina = table.Column<int>(type: "int", nullable: false),
                    maquinaid = table.Column<int>(type: "int", nullable: false),
                    projetoid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlocacaoHoras", x => x.id);
                    table.ForeignKey(
                        name: "FK_AlocacaoHoras_Maquina_maquinaid",
                        column: x => x.maquinaid,
                        principalTable: "Maquina",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlocacaoHoras_Projeto_projetoid",
                        column: x => x.projetoid,
                        principalTable: "Projeto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlocacaoHoras_maquinaid",
                table: "AlocacaoHoras",
                column: "maquinaid");

            migrationBuilder.CreateIndex(
                name: "IX_AlocacaoHoras_projetoid",
                table: "AlocacaoHoras",
                column: "projetoid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlocacaoHoras");

            migrationBuilder.DropTable(
                name: "Maquina");

            migrationBuilder.DropTable(
                name: "Projeto");
        }
    }
}

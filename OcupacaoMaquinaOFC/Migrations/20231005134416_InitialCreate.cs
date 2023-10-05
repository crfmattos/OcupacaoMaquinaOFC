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
                    nome = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    limiteHoras = table.Column<double>(type: "float", nullable: false),
                    valorMaquina = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maquina", x => x.nome);
                });

            migrationBuilder.CreateTable(
                name: "Projeto",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    dataInicio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dataConclusao = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    qtdHoraPorMaquina = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    maquinanome = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    projetoid = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlocacaoHoras", x => x.qtdHoraPorMaquina);
                    table.ForeignKey(
                        name: "FK_AlocacaoHoras_Maquina_maquinanome",
                        column: x => x.maquinanome,
                        principalTable: "Maquina",
                        principalColumn: "nome",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlocacaoHoras_Projeto_projetoid",
                        column: x => x.projetoid,
                        principalTable: "Projeto",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlocacaoHoras_maquinanome",
                table: "AlocacaoHoras",
                column: "maquinanome");

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

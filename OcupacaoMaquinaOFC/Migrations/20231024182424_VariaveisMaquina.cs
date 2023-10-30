using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OcupacaoMaquinaOFC.Migrations
{
    public partial class VariaveisMaquina : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Projeto",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "lider",
                table: "Projeto",
                newName: "Lider");

            migrationBuilder.RenameColumn(
                name: "dataInicio",
                table: "Projeto",
                newName: "DataInicio");

            migrationBuilder.RenameColumn(
                name: "dataConclusao",
                table: "Projeto",
                newName: "DataConclusao");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Projeto",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "valorMaquina",
                table: "Maquina",
                newName: "ValorMaquina");

            migrationBuilder.RenameColumn(
                name: "valorHora",
                table: "Maquina",
                newName: "ValorHora");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Maquina",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "limiteHoras",
                table: "Maquina",
                newName: "LimiteHoras");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Maquina",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "qtdHoraPorMaquina",
                table: "AlocacaoHoras",
                newName: "QtdHoraPorMaquina");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AlocacaoHoras",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Projeto",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Lider",
                table: "Projeto",
                newName: "lider");

            migrationBuilder.RenameColumn(
                name: "DataInicio",
                table: "Projeto",
                newName: "dataInicio");

            migrationBuilder.RenameColumn(
                name: "DataConclusao",
                table: "Projeto",
                newName: "dataConclusao");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Projeto",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ValorMaquina",
                table: "Maquina",
                newName: "valorMaquina");

            migrationBuilder.RenameColumn(
                name: "ValorHora",
                table: "Maquina",
                newName: "valorHora");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Maquina",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "LimiteHoras",
                table: "Maquina",
                newName: "limiteHoras");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Maquina",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "QtdHoraPorMaquina",
                table: "AlocacaoHoras",
                newName: "qtdHoraPorMaquina");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AlocacaoHoras",
                newName: "id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OcupacaoMaquinaOFC.Migrations
{
    public partial class adicionaNomeEmProjeto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "nome",
                table: "Projeto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nome",
                table: "Projeto");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OcupacaoMaquinaOFC.Migrations
{
    public partial class DefinirChaveEstrangeiraModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlocacaoHoras_Maquina_maquinaid",
                table: "AlocacaoHoras");

            migrationBuilder.DropForeignKey(
                name: "FK_AlocacaoHoras_Projeto_projetoid",
                table: "AlocacaoHoras");

            migrationBuilder.RenameColumn(
                name: "projetoid",
                table: "AlocacaoHoras",
                newName: "ProjetoId");

            migrationBuilder.RenameColumn(
                name: "maquinaid",
                table: "AlocacaoHoras",
                newName: "MaquinaId");

            migrationBuilder.RenameIndex(
                name: "IX_AlocacaoHoras_projetoid",
                table: "AlocacaoHoras",
                newName: "IX_AlocacaoHoras_ProjetoId");

            migrationBuilder.RenameIndex(
                name: "IX_AlocacaoHoras_maquinaid",
                table: "AlocacaoHoras",
                newName: "IX_AlocacaoHoras_MaquinaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlocacaoHoras_Maquina_MaquinaId",
                table: "AlocacaoHoras",
                column: "MaquinaId",
                principalTable: "Maquina",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlocacaoHoras_Projeto_ProjetoId",
                table: "AlocacaoHoras",
                column: "ProjetoId",
                principalTable: "Projeto",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlocacaoHoras_Maquina_MaquinaId",
                table: "AlocacaoHoras");

            migrationBuilder.DropForeignKey(
                name: "FK_AlocacaoHoras_Projeto_ProjetoId",
                table: "AlocacaoHoras");

            migrationBuilder.RenameColumn(
                name: "ProjetoId",
                table: "AlocacaoHoras",
                newName: "projetoid");

            migrationBuilder.RenameColumn(
                name: "MaquinaId",
                table: "AlocacaoHoras",
                newName: "maquinaid");

            migrationBuilder.RenameIndex(
                name: "IX_AlocacaoHoras_ProjetoId",
                table: "AlocacaoHoras",
                newName: "IX_AlocacaoHoras_projetoid");

            migrationBuilder.RenameIndex(
                name: "IX_AlocacaoHoras_MaquinaId",
                table: "AlocacaoHoras",
                newName: "IX_AlocacaoHoras_maquinaid");

            migrationBuilder.AddForeignKey(
                name: "FK_AlocacaoHoras_Maquina_maquinaid",
                table: "AlocacaoHoras",
                column: "maquinaid",
                principalTable: "Maquina",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlocacaoHoras_Projeto_projetoid",
                table: "AlocacaoHoras",
                column: "projetoid",
                principalTable: "Projeto",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

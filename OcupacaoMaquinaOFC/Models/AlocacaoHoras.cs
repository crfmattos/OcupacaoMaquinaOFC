using System.ComponentModel.DataAnnotations;

namespace OcupacaoMaquinaOFC.Models;

public class AlocacaoHoras
{

    public AlocacaoHoras()
    {
        this.maquina = new Maquina();
        this.projeto = new Projeto();
    }

    public AlocacaoHoras(int qtdHoraPorMaquina, Maquina maquina, Projeto projeto)
    {
        this.qtdHoraPorMaquina = qtdHoraPorMaquina;
        this.maquina = maquina;
        this.projeto = projeto;
    }

    [Key]
    public int qtdHoraPorMaquina { get; set; }
    public Maquina maquina { get; set; }
    public Projeto projeto { get; set; }


}

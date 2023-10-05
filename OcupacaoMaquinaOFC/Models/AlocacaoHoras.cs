using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OcupacaoMaquinaOFC.Models;

public class AlocacaoHoras
{

    public AlocacaoHoras()
    {
        this.maquina = new Maquina();
        this.projeto = new Projeto();
    }

    public AlocacaoHoras(int id, int qtdHoraPorMaquina, Maquina maquina, Projeto projeto)
    {
        this.id = id;
        this.qtdHoraPorMaquina = qtdHoraPorMaquina;
        this.maquina = maquina;
        this.projeto = projeto;
    }

    [Key]
    public int id { get; set; }
    public int qtdHoraPorMaquina { get; set; }
    public Maquina maquina { get; set; }
    public Projeto projeto { get; set; }


}

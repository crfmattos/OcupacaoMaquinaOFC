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

    [Display(Name = "Horas por máquina")]
    public int qtdHoraPorMaquina { get; set; }

    [Display(Name = "Máquina")]
    [Required]
    public Maquina maquina { get; set; }

    [Display(Name = "Projeto")]
    [Required]
    public Projeto projeto { get; set; }


}

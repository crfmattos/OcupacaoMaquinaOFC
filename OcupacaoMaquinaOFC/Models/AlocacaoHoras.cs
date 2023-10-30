using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OcupacaoMaquinaOFC.Models;

public class AlocacaoHorasViewModel
{
    public int Id { get; set; }

    [Display(Name = "Horas por máquina")]
    public int QtdHoraPorMaquina { get; set; }

    public int MaquinaId { get; set; }

    public int ProjetoId { get; set; }

    public Projeto? Projeto { get; set; }

    public Maquina? Maquina { get; set; }
}


public class AlocacaoHoras
{

    public AlocacaoHoras()
    {
        this.Maquina = new Maquina();
        this.Projeto = new Projeto();
    }


    public AlocacaoHoras(int id, int qtdHoraPorMaquina, Maquina maquina, Projeto projeto)
    {
        this.Id = id;
        this.QtdHoraPorMaquina = qtdHoraPorMaquina;
        this.Maquina = maquina;
        this.Projeto = projeto;
    }

    [Key]
    public int Id { get; set; }

    [Display(Name = "Horas por máquina")]
    public int QtdHoraPorMaquina { get; set; }

    [Display(Name = "Máquina")]
    public Maquina Maquina { get; set; }

    public int MaquinaId { get; set; }

    [Display(Name = "Projeto")]
    public Projeto Projeto { get; set; }

    public int ProjetoId { get; set; }


}

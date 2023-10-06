using System.ComponentModel.DataAnnotations;

namespace OcupacaoMaquinaOFC.Models;
public class Projeto
{
    public Projeto()
    {
    }

    public Projeto(int id, DateTime dataInicio, DateTime dataConclusao, string lider)
    {
        this.id = id;
        this.dataInicio = dataInicio;
        this.dataConclusao = dataConclusao;
        this.lider = lider;
    }

    [Key]
    public int id { get; set; }
    public DateTime dataInicio { get; set; }
    public DateTime dataConclusao { get; set; }
    public string lider { get; set; }
    
}
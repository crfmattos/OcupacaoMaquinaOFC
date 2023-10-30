using System.ComponentModel.DataAnnotations;

namespace OcupacaoMaquinaOFC.Models;
public class Projeto
{
    public Projeto()
    {
    }

    public Projeto(int id, DateTime dataInicio, DateTime dataConclusao, string lider)
    {
        this.Id = id;
        this.DataInicio = dataInicio;
        this.DataConclusao = dataConclusao;
        this.Lider = lider;
    }

    [Key]
    [Display(Name = "Id")]
    public int Id { get; set; }

    [Display(Name ="Nome do projeto")]
    public string Nome {  get; set; }

    [Display(Name = "Data de início")]
    [DataType(DataType.Date)]
    public DateTime DataInicio { get; set; }

    [Display(Name = "Data de conclusão")]
    [DataType(DataType.Date)]
    public DateTime DataConclusao { get; set; }

    [Display(Name = "Líder do projeto")]
    public string Lider { get; set; }
    
}
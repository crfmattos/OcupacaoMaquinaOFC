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
    [Display(Name = "Id")]
    public int id { get; set; }

    [Display(Name ="Nome do projeto")]
    public string nome {  get; set; }

    [Display(Name = "Data de início")]
    [DataType(DataType.Date)]
    [Required]
    public DateTime dataInicio { get; set; }

    [Display(Name = "Data de conclusão")]
    [DataType(DataType.Date)]
    [Required]
    public DateTime dataConclusao { get; set; }

    [Display(Name = "Líder do projeto")]
    public string lider { get; set; }
    
}
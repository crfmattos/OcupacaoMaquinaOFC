using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OcupacaoMaquinaOFC.Models;
public class Maquina
{
    public Maquina()
    {
    }

    public Maquina(int id, string nome, double limiteHoras, double valorMaquina, double valorHora)
    {
        this.Id = id;
        this.Nome = nome;
        this.LimiteHoras = limiteHoras;
        this.ValorMaquina = valorMaquina;
        this.ValorHora = valorHora;
    }

    [Key]
    [Display(Name = "Id")]
    public int Id { get; set; }

    
    [Display(Name = "Nome da m�quina")]
    public string Nome { get; set; }

    [Display(Name = "Limite de horas")]
    [Column(TypeName = "decimal(18, 2)")]
    public double LimiteHoras { get; set; }

    [Display(Name = "Valor m�quina")]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    public double ValorMaquina { get; set; }

    [Display(Name = "Valor da hora-m�quina")]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    public double ValorHora { get; set; }



}



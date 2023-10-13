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
        this.id = id;
        this.nome = nome;
        this.limiteHoras = limiteHoras;
        this.valorMaquina = valorMaquina;
        this.valorHora = valorHora;
    }

    [Key]
    [Display(Name = "Id")]
    public int id { get; set; }

    
    [Display(Name = "Nome da máquina")]
    [Required]
    public string nome { get; set; }

    [Display(Name = "Limite de horas")]
    [Column(TypeName = "decimal(18, 2)")]
    public double limiteHoras { get; set; }

    [Display(Name = "Valor máquina")]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    public double valorMaquina { get; set; }

    [Display(Name = "Valor da hora-máquina")]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    public double valorHora { get; set; }



}



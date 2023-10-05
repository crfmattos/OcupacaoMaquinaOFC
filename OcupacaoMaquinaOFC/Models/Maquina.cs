using System.ComponentModel.DataAnnotations;

namespace OcupacaoMaquinaOFC.Models;
public class Maquina
{
    public Maquina()
    {
    }

    public Maquina(string nome, double limiteHoras, double valorMaquina)
    {
        this.nome = nome;
        this.limiteHoras = limiteHoras;
        this.valorMaquina = valorMaquina;
        this.valorHora = valorHora;
    }
    [Key]
    public string nome { get; set; }
    public double limiteHoras { get; set; }
    public double valorMaquina { get; set; }
    public double valorHora { get; set; }
    

    
}



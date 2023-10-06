using System.ComponentModel.DataAnnotations;

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
    public int id { get; set; }
    public string nome { get; set; }
    public double limiteHoras { get; set; }
    public double valorMaquina { get; set; }
    public double valorHora { get; set; }



}



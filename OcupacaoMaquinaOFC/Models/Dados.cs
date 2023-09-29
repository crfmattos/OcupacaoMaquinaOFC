namespace OcupacaoMaquinaOFC.Models;


public static class Dados
{

    public static List<Projeto> projetos = new();
    public static List<AlocacaoHoras> bancoDeHoras = new();
    public static List<Maquina> equipamentos = new();

    public static List<Maquina> LISTADEQUIPAMENTOS = new()
    {
        new Maquina("Mufla", 100, 100000),
        new Maquina("PHMETRO", 100, 800000),
        new Maquina("Balança Analítica", 100, 500000)
    };

    public static List<AlocacaoHoras> LISTADEHORAS = new()
    {
        new AlocacaoHoras(55, equipamentos[0], projetos[0]),
        new AlocacaoHoras(22, equipamentos[0], projetos[1]),
        new AlocacaoHoras(32, equipamentos[1], projetos[1]),
        new AlocacaoHoras(10, equipamentos[2], projetos[2])
    };

    public static List<Projeto> LISTAINFORMACOESPROJETOS = new()
    {
    new Projeto("Projeto_12345", "2023-03-01", "2024-03-01", "Leon"),
    new Projeto("Projeto_54321", "2022-03-01", "2024-03-01", "Joao"),
    new Projeto("Projeto_35241", "2023-03-01", "2024-01-01", "Henrique")
    };
}

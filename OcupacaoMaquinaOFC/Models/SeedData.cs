using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using OcupacaoMaquinaOFC.Data;

namespace OcupacaoMaquinaOFC.Models;


public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new OcupacaoMaquinaOFCContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<OcupacaoMaquinaOFCContext>>()))
        {
            if (context.Maquina.Any())
            {
                return;
            }
            context.Maquina.AddRange(
                new Maquina
                {
                     nome = "Mufla",
                     limiteHoras = 100,
                     valorMaquina = 100000,
                     valorHora = 1.141 // valorHora = ((valorMaquina * 0.10)/365)/24
                },
                new Maquina
                {
                    nome = "PHMETRO",
                    limiteHoras = 100,
                    valorMaquina = 800000,
                    valorHora = 9.132 // valorHora = ((valorMaquina * 0.10)/365)/24
                },
                new Maquina
                {
                    nome = "Balança Analítica",
                    limiteHoras = 100,
                    valorMaquina = 500000,
                    valorHora = 5.707 // valorHora = ((valorMaquina * 0.10)/365)/24
                }
            );
            context.SaveChanges();

            if (context.Projeto.Any())
            {
                return;
            }
            context.Projeto.AddRange(
                new Projeto
                {
                    dataInicio = new DateTime(2023, 03, 01),
                    dataConclusao = new DateTime(2024, 03, 01),
                    lider = "Leon"
                },
                new Projeto
                {
                    dataInicio = new DateTime(2022, 03, 01),
                    dataConclusao = new DateTime(2024, 03, 01),
                    lider = "Joao"
                },
                new Projeto
                {
                    dataInicio = new DateTime(2023, 03, 01),
                    dataConclusao = new DateTime(2024, 03, 01),
                    lider = "Henrique"
                }
            );
            context.SaveChanges();

            // ADICIONAR PELO SITE DEPOIS AS ALOCACOESHORAS
        }
    }
}

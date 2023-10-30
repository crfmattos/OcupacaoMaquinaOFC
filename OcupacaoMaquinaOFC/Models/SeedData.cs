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
                     Nome = "Mufla",
                     LimiteHoras = 100,
                     ValorMaquina = 100000,
                     ValorHora = 1.141 // valorHora = ((valorMaquina * 0.10)/365)/24
                },
                new Maquina
                {
                    Nome = "PHMETRO",
                    LimiteHoras = 100,
                    ValorMaquina = 800000,
                    ValorHora = 9.132 // valorHora = ((valorMaquina * 0.10)/365)/24
                },
                new Maquina
                {
                    Nome = "Balança Analítica",
                    LimiteHoras = 100,
                    ValorMaquina = 500000,
                    ValorHora = 5.707 // valorHora = ((valorMaquina * 0.10)/365)/24
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
                    DataInicio = new DateTime(2023, 03, 01),
                    DataConclusao = new DateTime(2024, 03, 01),
                    Lider = "Leon"
                },
                new Projeto
                {
                    DataInicio = new DateTime(2022, 03, 01),
                    DataConclusao = new DateTime(2024, 03, 01),
                    Lider = "Joao"
                },
                new Projeto
                {
                    DataInicio = new DateTime(2023, 03, 01),
                    DataConclusao = new DateTime(2024, 03, 01),
                    Lider = "Henrique"
                }
            );
            context.SaveChanges();

            // ADICIONAR PELO SITE DEPOIS AS ALOCACOESHORAS
        }
    }
}

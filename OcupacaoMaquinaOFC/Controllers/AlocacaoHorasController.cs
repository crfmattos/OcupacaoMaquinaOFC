using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OcupacaoMaquinaOFC.Models;
using System.Text.Encodings.Web;

namespace OcupacaoMaquinaOFC.Controllers;

public class AlocacaoHorasController : Controller
{
    

    List<AlocacaoHoras> CriarListaAlocacoes()
    {
        return Dados.LISTADEHORAS;
    }

    void PopularBancoDeHoras()
    {
        Dados.bancoDeHoras.AddRange(CriarListaAlocacoes());
    }

    int CalcularHoraMaquina(Maquina maquina)
    {
        int somaHora = Dados.bancoDeHoras.Where(m => m.maquina == maquina).Sum(hora => hora.qtdHoraPorMaquina);
        return somaHora;
    }

    List<AlocacaoHoras> FiltrarHorasPorMaquina(Maquina maquina)
    {
        List<AlocacaoHoras> HorasFiltradas = Dados.bancoDeHoras.Where((horaPercorrida) => horaPercorrida.maquina == maquina).ToList();
        return HorasFiltradas;
    }

    List<double> ListarPorcentagensFiltradas(List<AlocacaoHoras> horasFiltradas)
    {
        List<double> porcentagens = new();
        foreach (var hora in horasFiltradas)
        {
            porcentagens.Add(hora.qtdHoraPorMaquina / hora.maquina.limiteHoras);
        }
        return porcentagens;
    }

    int SomarHorasDeTodasMaquinas()
    {
        int horasTotais = Dados.bancoDeHoras.Sum(b => b.qtdHoraPorMaquina);
        return horasTotais;
    }

    double CalcularOcupacaoMaquina(Maquina maquina)
    {
        double ocupacaoMaquina = FiltrarHorasPorMaquina(maquina).Sum(x => x.qtdHoraPorMaquina) / maquina.limiteHoras;
        return ocupacaoMaquina * 100;

    }

    List<AlocacaoHoras> FiltrarPorProjeto(Projeto projeto)
    {
        List<AlocacaoHoras> projetosFiltrados = Dados.bancoDeHoras.Where((projetoPercorrido) => projetoPercorrido.projeto == projeto).ToList();
        return projetosFiltrados;
    }

    double calcularValorHorasAlocadas(Maquina maquina)
    {
        List<AlocacaoHoras> alocacoesDaMaquina = FiltrarHorasPorMaquina(maquina);
        int horasAlocadas = CalcularHoraMaquina(maquina);
        double valorHora = maquina.calcularValorHora();
        return horasAlocadas * valorHora;
    }



    // GET: AlocacaoHorasController
    public ActionResult Index()
    {
        return View();
    }

    // GET: AlocacaoHorasController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: AlocacaoHorasController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: AlocacaoHorasController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: AlocacaoHorasController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: AlocacaoHorasController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: AlocacaoHorasController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: AlocacaoHorasController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OcupacaoMaquinaOFC.Models;

namespace OcupacaoMaquinaOFC.Controllers;

public class MaquinaController : Controller
{

    List<Maquina> CriarListaEquipamentos()
    {
        return Dados.LISTADEQUIPAMENTOS;
    }



    void PopularBancoDeMaquinas()
    {
        Dados.equipamentos.AddRange(CriarListaEquipamentos());
    }

    void CriarNovaMaquina(string nome, double limiteHoras, double valorMaquina)
    {
        Dados.equipamentos.Add(new Maquina(nome, limiteHoras, valorMaquina));

        void CriarNovaMaquinaComInput()
        {
            Console.WriteLine("\nInsira os dados para cadastrar uma máquina abaixo:");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Limite de horas da máquina: ");
            double limiteHoras = Convert.ToDouble(Console.ReadLine());
            Console.Write("Valor da máquina: ");
            double valorMaquina = Convert.ToDouble(Console.ReadLine());
            CriarNovaMaquina(nome, limiteHoras, valorMaquina);

        }
        void ExibirEquipamentos()
        {
            foreach (var equipamento in Dados.equipamentos)
            {
                Console.WriteLine(equipamento.nome);
            }
        }
    }

    // GET: MaquinaController
    public ActionResult Index()
    {
        return View();
    }

    // GET: MaquinaController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: MaquinaController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: MaquinaController/Create
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

    // GET: MaquinaController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: MaquinaController/Edit/5
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

    // GET: MaquinaController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: MaquinaController/Delete/5
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

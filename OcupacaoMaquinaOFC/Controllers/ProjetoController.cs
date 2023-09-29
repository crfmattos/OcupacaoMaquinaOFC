using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OcupacaoMaquinaOFC.Models;
using System.Text.Encodings.Web;

namespace OcupacaoMaquinaOFC.Controllers
{
    public class ProjetoController : Controller
    {

        List<Projeto> CriarListaProjetos()
        {
            return Dados.LISTAINFORMACOESPROJETOS;
        }

        void PopularBancoDeProjetos()
        {
            Dados.projetos.AddRange(CriarListaProjetos());
        }

        void CriarNovoProjeto(string id, string dataInicio, string dataConclusao, string lider)
        {
            Dados.projetos.Add(new Projeto(id, dataInicio, dataConclusao, lider));
        }

        void CriarNovoProjetoComInput()
        {
            Console.WriteLine("\nInsira os dados para cadastrar um projeto abaixo:");
            Console.Write("Id do projeto: ");
            string id = Console.ReadLine();
            Console.Write("Data de Início: ");
            string dataInicio = Console.ReadLine();
            Console.Write("Data de conclusão: ");
            string dataConclusao = Console.ReadLine();
            Console.Write("Líder de projeto: ");
            string lider = Console.ReadLine();
            CriarNovoProjeto(id, dataInicio, dataConclusao, lider);

        }

        void ExibirProjetos()
        {
            foreach (var projeto in Dados.projetos)
            {
                Console.WriteLine(projeto.id);
            }
        }

        DateTime CalcularQtdDeMeses(DateTime data, int numeroDeMeses)
        {


            DateTime dataAtual = DateTime.Now;
            DateTime dataSubtraida = data.AddMonths(-numeroDeMeses);
            return dataSubtraida;
        }

        // GET: ProjetoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProjetoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProjetoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjetoController/Create
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

        // GET: ProjetoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProjetoController/Edit/5
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

        // GET: ProjetoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProjetoController/Delete/5
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
}

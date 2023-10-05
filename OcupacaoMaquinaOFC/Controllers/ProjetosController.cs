﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OcupacaoMaquinaOFC.Data;
using OcupacaoMaquinaOFC.Models;

namespace OcupacaoMaquinaOFC.Controllers
{
    public class ProjetosController : Controller
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

        private readonly OcupacaoMaquinaOFCContext _context;

        public ProjetosController(OcupacaoMaquinaOFCContext context)
        {
            _context = context;
        }

        // GET: Projetos
        public async Task<IActionResult> Index()
        {
              return _context.Projeto != null ? 
                          View(await _context.Projeto.ToListAsync()) :
                          Problem("Entity set 'OcupacaoMaquinaOFCContext.Projeto'  is null.");
        }

        // GET: Projetos/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Projeto == null)
            {
                return NotFound();
            }

            var projeto = await _context.Projeto
                .FirstOrDefaultAsync(m => m.id == id);
            if (projeto == null)
            {
                return NotFound();
            }

            return View(projeto);
        }

        // GET: Projetos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projetos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,dataInicio,dataConclusao,lider")] Projeto projeto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projeto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projeto);
        }

        // GET: Projetos/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Projeto == null)
            {
                return NotFound();
            }

            var projeto = await _context.Projeto.FindAsync(id);
            if (projeto == null)
            {
                return NotFound();
            }
            return View(projeto);
        }

        // POST: Projetos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("id,dataInicio,dataConclusao,lider")] Projeto projeto)
        {
            if (id != projeto.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projeto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjetoExists(projeto.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(projeto);
        }

        // GET: Projetos/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Projeto == null)
            {
                return NotFound();
            }

            var projeto = await _context.Projeto
                .FirstOrDefaultAsync(m => m.id == id);
            if (projeto == null)
            {
                return NotFound();
            }

            return View(projeto);
        }

        // POST: Projetos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Projeto == null)
            {
                return Problem("Entity set 'OcupacaoMaquinaOFCContext.Projeto'  is null.");
            }
            var projeto = await _context.Projeto.FindAsync(id);
            if (projeto != null)
            {
                _context.Projeto.Remove(projeto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjetoExists(string id)
        {
          return (_context.Projeto?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
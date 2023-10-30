using System;
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
    public class MaquinasController : Controller
    {

        //List<Maquina> CriarListaEquipamentos()
        //{
        //    return SeedData.LISTADEQUIPAMENTOS;
        //}


        //void PopularBancoDeMaquinas()
        //{
        //    SeedData.equipamentos.AddRange(CriarListaEquipamentos());
        //}

        //void CriarNovaMaquina(string nome, double limiteHoras, double valorMaquina)
        //{
        //    SeedData.equipamentos.Add(new Maquina(nome, limiteHoras, valorMaquina));
        //}

        //void CriarNovaMaquinaComInput()
        //{
        //    Console.WriteLine("\nInsira os dados para cadastrar uma máquina abaixo:");
        //    Console.Write("Nome: ");
        //    string nome = Console.ReadLine();
        //    Console.Write("Limite de horas da máquina: ");
        //    double limiteHoras = Convert.ToDouble(Console.ReadLine());
        //    Console.Write("Valor da máquina: ");
        //    double valorMaquina = Convert.ToDouble(Console.ReadLine());
        //    CriarNovaMaquina(nome, limiteHoras, valorMaquina);

        //}
        //    void ExibirEquipamentos()
        //    {
        //        foreach (var equipamento in SeedData.equipamentos)
        //        {
        //            Console.WriteLine(equipamento.nome);
        //        }
        //    }
        //}
        public void calcularValorHora(Maquina maquina)
        {
            maquina.ValorHora = ((maquina.ValorMaquina * 0.10) / 365) / 24;
        }

        private readonly OcupacaoMaquinaOFCContext _context;

        public MaquinasController(OcupacaoMaquinaOFCContext context)
        {
            _context = context;
        }

        // GET: Maquinas
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.Maquina == null)
            {
                return Problem("Entity set 'OcupacaoMaquinaOFCContext.Maquina'  is null.");
            }

            var maquinas = from m in _context.Maquina
                           select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                maquinas = maquinas.Where(s => s.Nome!.Contains(searchString));
            }

            return View(await maquinas.ToListAsync());

        }

        // GET: Maquinas/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (_context.Maquina == null)
            {
                return NotFound();
            }

            var maquina = await _context.Maquina
                .FirstOrDefaultAsync(m => m.Id == id);
            if (maquina == null)
            {
                return NotFound();
            }

            return View(maquina);
        }

        // GET: Maquinas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Maquinas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("nome,limiteHoras,valorMaquina")] Maquina maquina)
        {
            if (ModelState.IsValid)
            {
                calcularValorHora(maquina);

                _context.Add(maquina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(maquina);
            }
        }

        // GET: Maquinas/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (_context.Maquina == null)
            {
                return NotFound();
            }

            var maquina = await _context.Maquina.FindAsync(id);

            if (maquina == null)
            {
                return NotFound();
            }

            return View(maquina);
        }

        // POST: Maquinas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id, nome,limiteHoras,valorMaquina,valorHora")] Maquina maquina)
        {
            if (id != maquina.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(maquina);
                    calcularValorHora(maquina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaquinaExists(maquina.Id))
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
            return View(maquina);
        }

        // GET: Maquinas/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.Maquina == null)
            {
                return NotFound();
            }

            var maquina = await _context.Maquina
                .FirstOrDefaultAsync(m => m.Id == id);
            if (maquina == null)
            {
                return NotFound();
            }

            return View(maquina);
        }

        // POST: Maquinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Maquina == null)
            {
                return Problem("Entity set 'OcupacaoMaquinaOFCContext.Maquina'  is null.");
            }
            var maquina = await _context.Maquina.FindAsync(id);
            if (maquina != null)
            {
                _context.Maquina.Remove(maquina);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaquinaExists(int id)
        {
            return (_context.Maquina?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

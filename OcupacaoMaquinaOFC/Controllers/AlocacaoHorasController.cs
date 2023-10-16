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
    public class AlocacaoHorasController : Controller
    {
        private readonly OcupacaoMaquinaOFCContext _context;

        public AlocacaoHorasController(OcupacaoMaquinaOFCContext context)
        {
            _context = context;
        }

        // GET: AlocacaoHoras
        public async Task<IActionResult> Index()
        {
              return _context.AlocacaoHoras != null ? 
                          View(await _context.AlocacaoHoras.Include(alocacao => alocacao.maquina).Include(alocacao => alocacao.projeto).ToListAsync()) :
                          Problem("Entity set 'OcupacaoMaquinaOFCContext.AlocacaoHoras'  is null.");
        }

        // GET: AlocacaoHoras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (_context.AlocacaoHoras == null)
            {
                return NotFound();
            }

            var alocacaoHoras = await _context.AlocacaoHoras
                .FirstOrDefaultAsync(m => m.qtdHoraPorMaquina == id);
            if (alocacaoHoras == null)
            {
                return NotFound();
            }
                
            return View(alocacaoHoras);

        }

        // GET: AlocacaoHoras/Create
        public async Task<IActionResult> Create()
        {
            List<Maquina> maquina = await _context.Maquina.ToListAsync();
            List<Projeto> projeto = await _context.Projeto.ToListAsync();


            ViewData["Maquinas"] = new SelectList(maquina, "id", "nome");
            ViewData["Projetos"] = new SelectList(projeto, "id", "nome");

            return View();
        }

        // POST: AlocacaoHoras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id, qtdHoraPorMaquina, maquina, projeto")] AlocacaoHoras alocacaoHoras)
        {
            Maquina m = _context.Maquina.FirstOrDefault(n => n.id == alocacaoHoras.maquina.id);
            Projeto p = _context.Projeto.FirstOrDefault(n => n.id == alocacaoHoras.projeto.id);

            alocacaoHoras.maquina = m ?? new Maquina();
            alocacaoHoras.projeto = p ?? new Projeto();

            _context.Add(alocacaoHoras);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            
            return View(alocacaoHoras);
        }

        // GET: AlocacaoHoras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (_context.AlocacaoHoras == null)
            {
                return NotFound();
            }

            var alocacaoHoras = await _context.AlocacaoHoras.Include(alocacao => alocacao.maquina).Include(alocacao => alocacao.projeto).Where(a => a.id == id).FirstOrDefaultAsync();
            if (alocacaoHoras == null)
            {
                return NotFound();
            }

            List<Maquina> maquina = await _context.Maquina.ToListAsync();
            List<Projeto> projeto = await _context.Projeto.ToListAsync();


            ViewData["Maquinas"] = new SelectList(maquina, "id", "nome");
            ViewData["Projetos"] = new SelectList(projeto, "id", "nome");

            return View(alocacaoHoras);
        }

        // POST: AlocacaoHoras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id, qtdHoraPorMaquina, maquina, projeto")] AlocacaoHoras alocacaoHoras)
        {
            if (id != alocacaoHoras.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(alocacaoHoras);
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlocacaoHorasExists(alocacaoHoras.id))
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
            else
            {
                throw new Exception("Modelo inválido");
            }
        }

        // GET: AlocacaoHoras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (_context.AlocacaoHoras == null)
            {
                return NotFound();
            }

            var alocacaoHoras = await _context.AlocacaoHoras
                .FirstOrDefaultAsync(m => m.qtdHoraPorMaquina == id);
            if (alocacaoHoras == null)
            {
                return NotFound();
            }

            return View(alocacaoHoras);
        }

        // POST: AlocacaoHoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AlocacaoHoras == null)
            {
                return Problem("Entity set 'OcupacaoMaquinaOFCContext.AlocacaoHoras'  is null.");
            }
            var alocacaoHoras = await _context.AlocacaoHoras.FindAsync(id);
            if (alocacaoHoras != null)
            {
                _context.AlocacaoHoras.Remove(alocacaoHoras);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlocacaoHorasExists(int id)
        {
          return (_context.AlocacaoHoras?.Any(e => e.qtdHoraPorMaquina == id)).GetValueOrDefault();
        }
    }
}

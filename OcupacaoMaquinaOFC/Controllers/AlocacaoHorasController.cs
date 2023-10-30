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
            if (_context.AlocacaoHoras == null)
            {
                return NotFound();
            }
            else
            {
                List<AlocacaoHorasViewModel> alocacaoHoras = await _context.AlocacaoHoras
                    .Include(alocacao => alocacao.Maquina)
                    .Include(alocacao => alocacao.Projeto)
                    .Select(alocacao => new AlocacaoHorasViewModel
                    {
                        Id = alocacao.Id,
                        Maquina = alocacao.Maquina,
                        Projeto = alocacao.Projeto,
                        MaquinaId = alocacao.MaquinaId,
                        ProjetoId = alocacao.ProjetoId,
                        QtdHoraPorMaquina = alocacao.QtdHoraPorMaquina,
                    })
                    .ToListAsync();

                return View(alocacaoHoras);
            }
        }

        // GET: AlocacaoHoras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (_context.AlocacaoHoras == null)
            {
                return NotFound();
            }

            var alocacaoDb = await _context.AlocacaoHoras.Include(a => a.Projeto).Include(a => a.Maquina).FirstOrDefaultAsync(a => a.Id == id);

            if (alocacaoDb != null)
            {
                AlocacaoHorasViewModel alocacaoHoras = new AlocacaoHorasViewModel
                {
                    Id = alocacaoDb.Id,
                    Maquina = alocacaoDb.Maquina,
                    MaquinaId = alocacaoDb.MaquinaId,
                    Projeto = alocacaoDb.Projeto,
                    ProjetoId = alocacaoDb.ProjetoId,
                    QtdHoraPorMaquina = alocacaoDb.QtdHoraPorMaquina,
                };

                return View(alocacaoHoras);
            }
            else
            {
                return NotFound();
            }

            return NotFound();

        }

        // GET: AlocacaoHoras/Create
        public async Task<IActionResult> Create()
        {
            List<Maquina> maquina = await _context.Maquina.ToListAsync();
            List<Projeto> projeto = await _context.Projeto.ToListAsync();


            ViewData["Maquinas"] = maquina;
            ViewData["Projetos"] = projeto;

            return View();
        }

        // POST: AlocacaoHoras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QtdHoraPorMaquina, MaquinaId, ProjetoId")] AlocacaoHoras alocacaoHoras)
        {
            Maquina m = _context.Maquina.FirstOrDefault(n => n.Id == alocacaoHoras.MaquinaId);
            Projeto p = _context.Projeto.FirstOrDefault(n => n.Id == alocacaoHoras.ProjetoId);

            alocacaoHoras.Maquina = m ?? new Maquina();
            alocacaoHoras.Projeto = p ?? new Projeto();

            _context.Add(alocacaoHoras);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: AlocacaoHoras/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            List<Maquina> maquina = await _context.Maquina.ToListAsync();
            List<Projeto> projeto = await _context.Projeto.ToListAsync();

            ViewData["Maquinas"] = new SelectList(maquina, "Id", "Nome");
            ViewData["Projetos"] = new SelectList(projeto, "Id", "Nome");

            var alocacaoHoras = await _context.AlocacaoHoras.Include(alocacao => alocacao.Maquina).Include(alocacao => alocacao.Projeto).Where(a => a.Id == id).FirstOrDefaultAsync();
            if (alocacaoHoras == null)
            {
                ViewData["Maquinas"] = new SelectList(maquina, "Id", "Nome");
                ViewData["Projetos"] = new SelectList(projeto, "Id", "Nome");

                return NotFound();
            }
            else
            {
                AlocacaoHorasViewModel alocacaoHorasViewModel = new AlocacaoHorasViewModel
                {
                    Id = alocacaoHoras.Id,
                    Maquina = alocacaoHoras.Maquina,
                    MaquinaId = alocacaoHoras.MaquinaId,
                    Projeto = alocacaoHoras.Projeto,
                    ProjetoId = alocacaoHoras.ProjetoId,
                    QtdHoraPorMaquina = alocacaoHoras.QtdHoraPorMaquina
                };

                ViewData["Maquinas"] = new SelectList(maquina, "Id", "Nome");
                ViewData["Projetos"] = new SelectList(projeto, "Id", "Nome");

                return View(alocacaoHorasViewModel);
            }
        }

        // POST: AlocacaoHoras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, QtdHoraPorMaquina, MaquinaId, ProjetoId")] AlocacaoHorasViewModel alocacaoHorasViewModel)
        {
            if (id != alocacaoHorasViewModel.Id)
            {
                return NotFound();
            }

            if (!AlocacaoHorasExists(id))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (alocacaoHorasViewModel != null)
                    {
                        AlocacaoHoras alocacaoHoras = new AlocacaoHoras
                        {
                            Id = alocacaoHorasViewModel.Id,
                            Maquina = alocacaoHorasViewModel.Maquina,
                            MaquinaId = alocacaoHorasViewModel.MaquinaId,
                            Projeto = alocacaoHorasViewModel.Projeto,
                            ProjetoId = alocacaoHorasViewModel.ProjetoId,
                            QtdHoraPorMaquina = alocacaoHorasViewModel.QtdHoraPorMaquina
                        };

                        _context.Update(alocacaoHoras);
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlocacaoHorasExists(id))
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

            return View(alocacaoHorasViewModel);

        }

        // GET: AlocacaoHoras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (_context.AlocacaoHoras == null)
            {
                return NotFound();
            }


            var alocacaoHoras = await _context.AlocacaoHoras.Include(a => a.Projeto).Include(a => a.Maquina)
                .FirstOrDefaultAsync(m => m.Id == id);

            AlocacaoHorasViewModel alocacaoHorasViewModel = new AlocacaoHorasViewModel
            {
                Id = alocacaoHoras.Id,
                Maquina = alocacaoHoras.Maquina,
                MaquinaId = alocacaoHoras.MaquinaId,
                Projeto = alocacaoHoras.Projeto,
                ProjetoId = alocacaoHoras.ProjetoId,
                QtdHoraPorMaquina = alocacaoHoras.QtdHoraPorMaquina
            };

            if (alocacaoHorasViewModel == null)
            {
                return NotFound();
            }

            return View(alocacaoHorasViewModel);
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
            return (_context.AlocacaoHoras?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

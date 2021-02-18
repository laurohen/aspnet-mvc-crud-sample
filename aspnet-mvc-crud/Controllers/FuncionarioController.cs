using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using aspnet_mvc_crud.Models;
using static aspnet_mvc_crud.Helper;

namespace aspnet_mvc_crud.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly FuncionarioDbContext _context;

        public FuncionarioController(FuncionarioDbContext context)
        {
            _context = context;
        }

        // GET: Funcionario
        public async Task<IActionResult> Index()
        {
            return View(await _context.Funcionarios.ToListAsync());
        }


        // GET: Funcionario/AddOrEdit(Insert)
        // GET: Funcionario/AddOrEdit/2(Update)
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new FuncionarioModel());
            else
            {
                var funcionarioModel = await _context.Funcionarios.FindAsync(id);
                if (funcionarioModel == null)
                {
                    return NotFound();
                }
                return View(funcionarioModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("FuncionarioId,Nome,Email,DataNascimento,Salario,FK_Estado")] FuncionarioModel funcionarioModel)
        {
            if (ModelState.IsValid)
            {
                //Insert
                if (id == 0)
                {
                    _context.Add(funcionarioModel);
                    await _context.SaveChangesAsync();

                }
                //Update
                else
                {
                    try
                    {
                        _context.Update(funcionarioModel);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!FuncionarioModelExists(funcionarioModel.FuncionarioId))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Funcionarios.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", funcionarioModel) });
        }

        // GET: Funcionario/Delete/2
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionarioModel = await _context.Funcionarios
                .FirstOrDefaultAsync(m => m.FuncionarioId == id);
            if (funcionarioModel == null)
            {
                return NotFound();
            }

            return View(funcionarioModel);
        }

        // POST: Funcionario/Delete/2
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funcionarioModel = await _context.Funcionarios.FindAsync(id);
            _context.Funcionarios.Remove(funcionarioModel);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Funcionarios.ToList()) });
        }

        private bool FuncionarioModelExists(int id)
        {
            return _context.Funcionarios.Any(e => e.FuncionarioId == id);
        }

    }
}

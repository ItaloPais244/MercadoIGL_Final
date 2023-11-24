using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MercadoIGL.Models;

namespace MercadoIGL.Controllers
{
    public class VendasController : Controller
    {
        private readonly Contexto _context;

        public VendasController(Contexto context)
        {
            _context = context;
        }

        // GET: Vendas
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Vendas.Include(v => v.cliente).Include(v => v.funcionario).Include(v => v.produto);
            return View(await contexto.ToListAsync());
        }

        // GET: Vendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vendas == null)
            {
                return NotFound();
            }

            var venda = await _context.Vendas
                .Include(v => v.cliente)
                .Include(v => v.funcionario)
                .Include(v => v.produto)
                .FirstOrDefaultAsync(m => m.idVenda == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // GET: Vendas/Create
        public IActionResult Create()
        {
            ViewData["idCliente"] = new SelectList(_context.Clientes, "idCliente", "nome");
            ViewData["idFuncionario"] = new SelectList(_context.Funcionarios, "idFuncionario", "nome");
            ViewData["idProduto"] = new SelectList(_context.Produtos, "idProduto", "descricao");
            return View();
        }

        // POST: Vendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idVenda,idProduto,idCliente,idFuncionario,quantidade,valorTotal,data")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                Produto produto = _context.Produtos.Find(venda.idProduto);

                if (produto != null)
                {
                    venda.valorTotal = produto.calcularTotal(venda.quantidade);
                    produto.descontarEstoque(venda.quantidade);

                    _context.Add(venda);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["idCliente"] = new SelectList(_context.Clientes, "idCliente", "nome", venda.idCliente);
            ViewData["idFuncionario"] = new SelectList(_context.Funcionarios, "idFuncionario", "nome", venda.idFuncionario);
            ViewData["idProduto"] = new SelectList(_context.Produtos, "idProduto", "descricao", venda.idProduto);
            return View(venda);
        }

        // GET: Vendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vendas == null)
            {
                return NotFound();
            }

            var venda = await _context.Vendas.FindAsync(id);
            if (venda == null)
            {
                return NotFound();
            }
            ViewData["idCliente"] = new SelectList(_context.Clientes, "idCliente", "nome", venda.idCliente);
            ViewData["idFuncionario"] = new SelectList(_context.Funcionarios, "idFuncionario", "nome", venda.idFuncionario);
            ViewData["idProduto"] = new SelectList(_context.Produtos, "idProduto", "descricao", venda.idProduto);
            return View(venda);
        }

        // POST: Vendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idVenda,idProduto,idCliente,idFuncionario,quantidade,valorTotal,data")] Venda venda)
        {
            if (id != venda.idVenda)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendaExists(venda.idVenda))
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
            ViewData["idCliente"] = new SelectList(_context.Clientes, "idCliente", "nome", venda.idCliente);
            ViewData["idFuncionario"] = new SelectList(_context.Funcionarios, "idFuncionario", "nome", venda.idFuncionario);
            ViewData["idProduto"] = new SelectList(_context.Produtos, "idProduto", "descricao", venda.idProduto);
            return View(venda);
        }

        // GET: Vendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vendas == null)
            {
                return NotFound();
            }

            var venda = await _context.Vendas
                .Include(v => v.cliente)
                .Include(v => v.funcionario)
                .Include(v => v.produto)
                .FirstOrDefaultAsync(m => m.idVenda == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vendas == null)
            {
                return Problem("Entity set 'Contexto.Vendas'  is null.");
            }
            var venda = await _context.Vendas.FindAsync(id);
            if (venda != null)
            {
                _context.Vendas.Remove(venda);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendaExists(int id)
        {
          return _context.Vendas.Any(e => e.idVenda == id);
        }
    }
}

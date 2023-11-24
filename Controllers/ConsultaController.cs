using MercadoIGL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MercadoIGL.Controllers
{
    public class ConsultaController : Controller
    {
        private readonly Contexto contexto;

        public ConsultaController(Contexto context)
        {
            contexto = context;
        }

        public IActionResult consultaVenda()
        {
            var listaVenda = contexto.Vendas.Include(prod=>prod.produto)
                                            .Include(func=>func.funcionario)
                                            .Include(cli=>cli.cliente)
                                            .Where(o => o.produto.descricao == "celular");
            return View(listaVenda);
        }
    }
}

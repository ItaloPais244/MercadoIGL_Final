using MercadoIGL.Models;
using Microsoft.AspNetCore.Mvc;
using MercadoIGL.Models.Consulta;

namespace MercadoIGL.Controllers
{
    public class QueryController : Controller
    {
        private readonly Contexto contexto;

        public QueryController(Contexto context)
        {
            contexto = context;
        }

        public IActionResult Pesquisa()
        {
            return View();
        }

        public IActionResult grpByVendas()
        {
            IEnumerable<QuerryVenda> lstVenda = new List<QuerryVenda>();
            lstVenda = from item in contexto.Vendas
                       .ToList()
                       select new QuerryVenda
                       {
                           produto = item.idProduto,
                           cliente = item.idCliente,
                           Funcionario = item.idFuncionario,
                           quantidade = item.quantidade,
                           valorTotal = item.valorTotal,
                       };

            IEnumerable<VendaGrpOperaçoes> lstGrpOperacoes =
            from linha in lstVenda
            .ToList()
            group linha by new { linha.cliente, linha.Funcionario }
            into grupo
            orderby grupo.Key.cliente
            select new VendaGrpOperaçoes
            {
                cliente = grupo.Key.cliente,
                funcionario = grupo.Key.Funcionario,
                valor = grupo.Sum(o => o.valorTotal)
            };
            return View(lstGrpOperacoes);
        }
    }
}

using Lanches.MVC.Context;
using Lanches.MVC.Models;

namespace Lanches.MVC.Areas.Admin.Servicos
{
    public class GraficosVendasServico
    {
        private readonly AppDbContext _context;

        public GraficosVendasServico(AppDbContext context)
        {
            _context = context;
        }

        public List<LancheGrafico> GetVendasLanches(int dias = 360)
        {
            var data = DateTime.Now.AddDays(-dias);

            var lanches = (from pd in _context.PedidoDetalhes
                           join l in _context.Lanches on pd.LancheId equals l.LancheId
                           where pd.Pedido.PedidoEnviado >= data
                           group pd by new { pd.LancheId, l.Nome, pd.Quantidade }
                           into g
                           select new
                           {
                               LancheNome = g.Key.Nome,
                               LanchesQuantidade = g.Sum(q => q.Quantidade),
                               LanchesValorTotal = g.Sum(a => a.Preco * a.Quantidade)
                           });

            var lista = new List<LancheGrafico>();

            foreach(var item in lanches)
            {
                var lanche = new LancheGrafico()
                {
                    LancheNome = item.LancheNome,
                    LanchesQuantidade = item.LanchesQuantidade,
                    LanchesValorTotal = item.LanchesValorTotal
                };
                lista.Add(lanche);

            }

            return lista;
        }
    }
}

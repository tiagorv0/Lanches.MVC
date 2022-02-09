using Lanches.MVC.Models;

namespace Lanches.MVC.Repositories.Interfaces
{
    public interface IPedidoRepository
    {
        void CriarPedido(Pedido pedido);
    }
}

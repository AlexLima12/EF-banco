using System.Linq;
using BancoLojaEF.Dados;
using BancoLojaEF.Models;

namespace BancoLojaEF
{
    public class IniciarBanco
    {
        public static void Inicializar(LojaContexto contexto)
        {
            contexto.Database.EnsureCreated();
            if(contexto.Cliente.Any()) {
                return;
            }

            var cliente = new Cliente("Pedro", "pedro@terra.com.br", 23);
            contexto.Cliente.Add(cliente);

            var produto = new Produto("Mouse", "Mouse Microsoft", 20, 10);
            contexto.Produto.Add(produto);

            var pedido = new Pedido(produto.IdProduto, cliente.IdCliente, 1);
            contexto.Pedido.Add(pedido);

            contexto.SaveChanges();
        }
    }
}
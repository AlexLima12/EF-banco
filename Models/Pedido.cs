using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoLojaEF.Models
{
    public class Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPedido { get; set; }
        
        [Required]
        public int IdProduto { get; set; }
        
        [Required]
        public int IdCliente { get; set; }
        
        [Required]
        public int Quantidade { get; set; }
        
        public Produto Produto { get; set; }
        
        public Cliente Cliente { get; set; }
        
        public Pedido()
        {
            
        }

        public Pedido(int IdProdudo, int IdCliente, int Quantidade)
        {
            this.IdProduto = IdProduto;
            this.IdCliente = IdCliente;
            this.Quantidade = Quantidade;
        }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoLojaEF.Models
{
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProduto { get; set; }
        
        [Required(ErrorMessage="O campo não nome não pode ficar vazio.")]
        [StringLength(50, MinimumLength=2)]
        public string Nome { get; set; }
        
        [Required(ErrorMessage="O campo descricao não pode ficar vazio.")]
        [DataType(DataType.Text)]
        public string Descricao { get; set; }
        
        [Required(ErrorMessage="O campo preci não pode ficar vazio.")]
        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }
        
        [Required(ErrorMessage="O campo quantidade não pode ficar vazio.")]
        public int Quantidade { get; set; }
        
        public ICollection<Pedido> Pedido { get; set; }
        
        public Produto()
        {
            
        }

        public Produto(string Nome, string Descricao, decimal Preco, int Quantidade)
        {
            this.Nome = Nome;
            this.Descricao = Descricao;
            this.Preco = Preco;
            this.Quantidade = Quantidade;
        }
    }
}
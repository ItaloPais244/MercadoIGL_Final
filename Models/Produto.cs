using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MercadoIGL.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int idProduto { get; set; }

        [Required(ErrorMessage = "Descrição do Produto Obrigatorio")]
        [StringLength(100)]
        [Display(Name = "Descricao")]
        public string descricao { get; set; }

        [Required(ErrorMessage = "Campo Fornecedor é OBRIGATORIO")]
        [Display(Name = "Fornecedor")]
        public int idFornecedor { get; set; }
        [ForeignKey("idFornecedor")]
        public Fornecedor fornecedor { get; set; }

        [Required(ErrorMessage = "Valor do Produto Obrigatorio")]
        [Display(Name = "Valor (UNID)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float valorUnitario { get; set; }

        [Required(ErrorMessage = "Estoque do Produto Obrigatorio")]
        [Display(Name = "Estoque")]
        public int estoque { get; set; }

        public float calcularTotal(int qtde)
        {
            float total = qtde * valorUnitario;
            return total;
        }
    }
}
